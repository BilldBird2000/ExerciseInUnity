using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardBased;
using System.Reflection;

public class CardInitial : MonoBehaviour//, ICardBase
{
    public int Id { set; get; } = 0;
    public string Name { set; get; } = "";
    public CardTpye Cardtype { set; get; } = CardTpye.Attack;
    public SkillType Skilltype { set; get; } = SkillType.Single;
    public CardRare Cardrare { set; get; } = CardRare.LvC;
    public CardLevel Cardlevel { set; get; } = CardLevel.LvB;
    public CardTarget Cardtarget { set; get; } = CardTarget.Enemy;
    public int ManaCast { set; get; } = 0;      //蓝耗
    public int MaxCounter { set; get; } = 0;    //最大重复数量,超出将不能被实例化,涉及到写表
    public int Attack { set; get; } = 0;        //攻击力
    public int Block { set; get; } = 0;         //格挡值
    public int Strength { set; get; } = 0;      //力量buff,当前回合额外增加攻击力
    public int Agility { set; get; } = 0;       //敏捷buff,当前回合额外增加格挡值
    public float Weak { set; get; } = 0;        //虚弱buff,减少25%攻击力
    public int WeakRnd { set; get; } = 0;       //虚弱buff持续回合
    public float Fragile { set; get; } = 0;     //脆弱buff;减少25%格挡值
    public int FragileRnd { set; get; } = 0;    //脆弱buff持续回合
    public float Wounded { set; get; } = 0;     //易伤buff,受到的伤害增加50%
    public int WndRnd { set; get; } = 0;        //易伤buff持续回合
    public int Repeat { set; get; } = 0;        //多段伤害次数
    public int DrawNum { set; get; } = 0;       //抽牌数量
    public int RandomTars { set; get; } = 0;    //随机目标数量
    public bool WithScript { set; get; } = false;   //带脚本的特殊技能

    //表之外的属性
    private Game game;
    private readonly string strengthName = "Strength";
    private readonly string agilitythName = "Agility";
    private readonly string weakName = "Weak";
    private readonly string fragileName = "Fragile";
    private readonly string woundedName = "Wounded";
    public int rdTars;
    public bool CanGet { set; get; } = true;
    private int counter = 1;
    public int Counter
    {
        set
        {
            if ( value >= MaxCounter )
            {
                counter = MaxCounter;
                CanGet = false;
            }
            else if ( value > 0 && value < MaxCounter )
                counter = value;
            else
                counter = 0;
        }
        get { return counter; }
    }

    ///初始化卡牌属性值
    public void Initial ( int index )
    {
        Dictionary<string , string> rowDict = CsvReader.Inst.GetRowDict (GameAsst.Inst.cardWrrDataPath , index);
        List<string> header = CsvReader.Inst.GetHeaderList (rowDict);

        Id = index;
        Name = rowDict [ header [ 1 ] ];
        Cardtype = ( CardTpye ) ( Enum.Parse (typeof (CardTpye) , rowDict [ header [ 2 ] ]) );
        Skilltype = ( SkillType ) ( Enum.Parse (typeof (SkillType) , rowDict [ header [ 3 ] ]) );
        Cardrare = ( CardRare ) ( Enum.Parse (typeof (CardRare) , rowDict [ header [ 4 ] ]) );
        Cardlevel = ( CardLevel ) ( Enum.Parse (typeof (CardLevel) , rowDict [ header [ 5 ] ]) );
        Cardtarget = ( CardTarget ) ( Enum.Parse (typeof (CardTarget) , rowDict [ header [ 6 ] ]) );
        ManaCast = Convert.ToInt32 (rowDict [ header [ 7 ] ]);
        //MaxCounter = Convert.ToInt32 (rowDict [ header [ 7 ] ]);
        Attack = Convert.ToInt32 (rowDict [ header [ 8 ] ]);
        Block = Convert.ToInt32 (rowDict [ header [ 9 ] ]);
        Strength = Convert.ToInt32 (rowDict [ header [ 10 ] ]);
        Agility = Convert.ToInt32 (rowDict [ header [ 11 ] ]);
        Weak = Convert.ToSingle (rowDict [ header [ 12 ] ]);
        WeakRnd = Convert.ToInt32 (rowDict [ header [ 13 ] ]);
        Fragile = Convert.ToSingle (rowDict [ header [ 14 ] ]);
        FragileRnd = Convert.ToInt32 (rowDict [ header [ 15 ] ]);
        Wounded = Convert.ToSingle (rowDict [ header [ 16 ] ]);
        WndRnd = Convert.ToInt32 (rowDict [ header [ 17 ] ]);
        Repeat = Convert.ToInt32 (rowDict [ header [ 18 ] ]);
        DrawNum = Convert.ToInt32 (rowDict [ header [ 19 ] ]);
        RandomTars = Convert.ToInt32 (rowDict [ header [ 20 ] ]);
        WithScript = Convert.ToBoolean (rowDict [ header [ 21 ] ]);
        rdTars = RandomTars - 1;
    }

    ///使用卡牌技能,得到结果
    public void SkillResult ( GameObject tar )
    {
        if ( WithScript )
        {
            //继承接口,重写方法,多态!!
            transform.GetComponent<IUniqueCard> ( ).Redefine ( );

            ///废弃方法1
            //string scriptName = "Card" + Id.ToString ( );
            //var unique = transform.GetComponent (scriptName);
            //Debug.Log (unique);
            //unique.SendMessage ("ReDefine");
            ///废弃方法2
            //string scriptName = "Card" + Id.ToString ( );
            //Type type = Type.GetType (scriptName);
            ////var obj = type.Assembly.CreateInstance (scriptName);
            //MethodInfo method = type.GetMethod ("ReDefine");
            //method.Invoke (this.gameObject , null);
            
        }
        game = GameObject.Find ("Launch").GetComponent<Game> ( );
        PlayerInitial plrInit = GameAsst.Inst.player.GetComponent<PlayerInitial> ( );
        Transform playerRoot = GameAsst.Inst.player.transform.parent.parent.parent;

        plrInit.Strength += Strength;
        if ( plrInit.Strength > 0 )
            CheckBuff (playerRoot , strengthName , game.strengthSprite , 1);
        plrInit.Agility += Agility;
        if ( plrInit.Agility > 0 )
            CheckBuff (playerRoot , agilitythName , game.agilitySprite , 1);

        if ( tar.CompareTag ("Enemy") )
        {
            EnemyInitial enmInit = tar.GetComponent<EnemyInitial> ( );
            Transform enmRoot = tar.transform.parent.parent.parent;

            enmInit.WeakRnd += WeakRnd;
            if ( enmInit.WeakRnd > 0 )
            {
                enmInit.Weak = 0.25f;
                CheckBuff (enmRoot , weakName , game.weakSprite , enmInit.WeakRnd);
            }
            else
                enmInit.Weak = 0;

            enmInit.FragileRnd += FragileRnd;
            if ( enmInit.FragileRnd > 0 )
            {
                enmInit.Fragile = 0.25f;
                CheckBuff (enmRoot , fragileName , game.fragileSprite , enmInit.FragileRnd);
            }
            else
                enmInit.Fragile = 0;

            enmInit.WndRnd += WndRnd;
            if ( enmInit.WndRnd > 0 )
            {
                enmInit.Wounded = 0.5f;
                CheckBuff (enmRoot , woundedName , game.woundedSprite , enmInit.WndRnd);
            }
            else
                enmInit.Wounded = 0;

            float dmg = ( Attack + plrInit.Strength ) * ( 1 - plrInit.Weak ) * ( 1 + enmInit.Wounded ) * Repeat;
            int damage = Convert.ToInt32 (Math.Floor (dmg));
            dmg -= damage;
            if ( dmg >= 0.5 )
                damage++;
            int tarHp = enmInit.Hp;
            tarHp -= damage;
            enmInit.Hp = tarHp;
            UpdateEnemyUiInform (tar , tarHp);
        }

        float blc = ( Block + plrInit.Agility ) * ( 1 - plrInit.Fragile );
        int block = Convert.ToInt32 (Math.Floor (blc));
        blc -= block;
        if ( blc >= 0.5 )
            block++;
        plrInit.Block += block;
        string blockToStr = Convert.ToString (plrInit.Block);
        playerRoot.Find ("Block/Text").GetComponent<Text> ( ).text = blockToStr;


        if ( rdTars > 0 )
        {
            rdTars--;
            BattleMgr.Inst.tarsList.Clear ( );
            if ( BattleMgr.Inst.liveList.Count != 0 )
            {
                BattleMgr.Inst.ChooseRandomTar ( );
                BattleMgr.Inst.UseCard ( );
            }
        }

        //int mana = plrInit.Mana;
        //mana -= ManaCast;
        //plrInit.Mana = mana;
        //UpdatePlayerUiInform (mana);

        BattleMgr.Inst.RemoveToUsed ( );

        if ( DrawNum > 0 )
            BattleMgr.Inst.PickUpCard (DrawNum);

        if ( BattleMgr.Inst.liveList.Count == 0 )
            GameAsst.Inst.lvPass = true;

    }

    ///判断是否添加buff,叠加buff回合数
    public void CheckBuff ( Transform roleRoot , string buffName , Sprite icon , int rnd )
    {
        Transform findBuff = null;
        try { findBuff = roleRoot.transform.Find ("BuffGroup" + "/" + buffName); }
        catch { }
        if ( findBuff == null )
            roleRoot.GetComponent<Buff> ( ).AddBuff (buffName , icon , rnd);
        else
            roleRoot.GetComponent<Buff> ( ).UpDateBuff (buffName , rnd);
    }

    ///更新player面板信息
    public void UpdatePlayerUiInform ( )
    {
        int plrMana = GameAsst.Inst.player.GetComponent<PlayerInitial> ( ).Mana;
        plrMana -= ManaCast;
        GameAsst.Inst.player.GetComponent<PlayerInitial> ( ).Mana = plrMana;
        string manaToStr = Convert.ToString (plrMana);
        GameAsst.Inst.player.transform.parent.parent.parent.Find ("Mana/Text").GetComponent<Text> ( ).text = manaToStr;
    }

    ///更新Enemy面板信息
    public void UpdateEnemyUiInform ( GameObject tar , int hp )
    {
        string hpToStr = Convert.ToString (hp);
        string maxhpToStr = Convert.ToString (tar.GetComponent<EnemyInitial> ( ).MaxHp);
        tar.transform.parent.parent.parent.Find ("Hp").GetComponent<Text> ( ).text = hpToStr + "/" + maxhpToStr;

    }






    //废弃的方法,减少判断条件,抽象成通用性更高的结构--------------------------------
    //public void SkillResult ( GameObject tar )
    //{
    //    if ( tar.CompareTag ("Enemy") && Cardtarget == CardTarget.Enemy )
    //    {
    //        float dmg = Attack * ( 1 + tar.GetComponent<EnemyInitial> ( ).atkrdc ) + Strength;
    //        int damage = Convert.ToInt32 (Math.Floor (dmg));
    //        dmg -= damage;
    //        if ( dmg >= 0.5 )
    //            damage++;

    //        int tarHp = tar.GetComponent<EnemyInitial> ( ).Hp;
    //        tarHp -= damage;
    //        int mana = GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).Mana;
    //        mana -= ManaCast;

    //        tar.GetComponent<EnemyInitial> ( ).Hp = tarHp;
    //        UpdateEnemyUiInform (tar , tarHp);
    //        GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).Mana = mana;
    //        UpdatePlayerUiInform (mana);
    //        BattleMgr.Inst.RemoveToUsed ( );
    //    }
    //    else if ( tar.CompareTag ("Player") && Cardtarget == CardTarget.Player )
    //    {
    //        int mana = GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).Mana;
    //        mana -= ManaCast;
    //        GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).Mana = mana;
    //        UpdatePlayerUiInform (mana);
    //        BattleMgr.Inst.block += Block;
    //        string blockToStr = Convert.ToString (BattleMgr.Inst.block);
    //        GameAsst._Inst.player.transform.parent.Find ("Block/Text").GetComponent<Text> ( ).text = blockToStr;
    //        BattleMgr.Inst.RemoveToUsed ( );
    //    }
    //}
    //---------------------------------------------------------------------------------

    //下面两个方法合并为SkillResult();--------------------------------------------------
    //public void SkillToEnemy ( GameObject tar )
    //{
    //    int damage = Attack;
    //    int tarHp = tar.GetComponent<EnemyInitial> ( ).Hp;
    //    int mana = GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).Mana;
    //    tarHp -= damage;
    //    mana -= ManaCast;
    //    Debug.LogFormat ("{0}向{1}施放技能{2}!!!" , GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).Name , tar.GetComponent<EnemyInitial> ( ).Name , Name);

    //    tar.GetComponent<EnemyInitial> ( ).Hp = tarHp;
    //    UpdateEnemyUiInform (tar , tarHp);
    //    GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).Mana = mana;
    //    UpdatePlayerUiInform (mana);
    //}
    //public void SkillToPlayer ( )
    //{
    //    BattleMgr.Inst.block += Block;
    //    string blockToStr = Convert.ToString (BattleMgr.Inst.block);
    //    GameAsst._Inst.player.transform.parent.Find ("Block").GetComponent<Text> ( ).text = blockToStr;
    //}
    //---------------------------------------------------------------------------------


}
