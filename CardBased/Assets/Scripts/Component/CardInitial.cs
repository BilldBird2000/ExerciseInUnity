using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardBased;

public class CardInitial : MonoBehaviour, ICardBase
{
    public int Id { set; get; } = 0;
    public string Name { set; get; } = "";
    public CardTpye Cardtype { set; get; } = CardTpye.Attack;
    public SkillType Skilltype { set; get; } = SkillType.Single;
    public CardRare Cardrare { set; get; } = CardRare.LvC;
    public CardLevel Cardlevel { set; get; } = CardLevel.LvB;
    public int ManaCast { set; get; } = 0;      //蓝耗
    public int MaxCounter { set; get; } = 0;    //最大重复数量,超出将不能被实例化
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

    //初始化卡牌属性值
    public void Initial ( int index )
    {
        Dictionary<string , string> rowDict = CsvReader.Inst.GetRowDict (GameAsst._Inst.cardWrrDataPath , index);
        List<string> header = CsvReader.Inst.GetHeaderList (rowDict);

        Id = index;
        Name = rowDict [ header [ 1 ] ];
        Cardtype = ( CardTpye ) ( Enum.Parse (typeof (CardTpye) , rowDict [ header [ 2 ] ]) );
        Skilltype = ( SkillType ) ( Enum.Parse (typeof (SkillType) , rowDict [ header [ 3 ] ]) );
        Cardrare = ( CardRare ) ( Enum.Parse (typeof (CardRare) , rowDict [ header [ 4 ] ]) );
        Cardlevel = ( CardLevel ) ( Enum.Parse (typeof (CardLevel) , rowDict [ header [ 5 ] ]) );
        ManaCast = Convert.ToInt32 (rowDict [ header [ 6 ] ]);
        MaxCounter = Convert.ToInt32 (rowDict [ header [ 7 ] ]);
        Attack = Convert.ToInt32 (rowDict [ header [ 8 ] ]);
        Block = Convert.ToInt32 (rowDict [ header [ 9 ] ]);
        Strength = Convert.ToInt32 (rowDict [ header [ 10 ] ]);
        Agility = Convert.ToInt32 (rowDict [ header [ 11 ] ]);
        Wounded = Convert.ToSingle (rowDict [ header [ 12 ] ]);
        WndRnd = Convert.ToInt32 (rowDict [ header [ 13 ] ]);
        Weak = Convert.ToSingle (rowDict [ header [ 14 ] ]);
        WeakRnd = Convert.ToInt32 (rowDict [ header [ 15 ] ]);
        Fragile = Convert.ToSingle (rowDict [ header [ 16 ] ]);
        FragileRnd = Convert.ToInt32 (rowDict [ header [ 17 ] ]);
        Repeat = Convert.ToInt32 (rowDict [ header [ 18 ] ]);
        DrawNum = Convert.ToInt32 (rowDict [ header [ 19 ] ]);
        RandomTars = Convert.ToInt32 (rowDict [ header [ 20 ] ]);
        WithScript = Convert.ToBoolean (rowDict [ header [ 21 ] ]);
    }

    //使用卡牌技能,得到结果
    public void SkillResult ( GameObject tar )
    {
        PlayerInitial plrInit = GameAsst._Inst.player.GetComponent<PlayerInitial> ( );
        plrInit.Strength += Strength;
        plrInit.Agility += Agility;
        plrInit.Weak = Weak;
        plrInit.WeakRnd += WeakRnd;
        plrInit.Fragile = Fragile;
        plrInit.FragileRnd += FragileRnd;

        if ( tar.CompareTag ("Enemy") )
        {
            EnemyInitial enmInit = tar.GetComponent<EnemyInitial> ( );
            enmInit.Wounded = Wounded;
            enmInit.WndRnd += WndRnd;
            float dmg = ( Attack + Strength ) * ( 1 - plrInit.Weak ) * ( 1 + enmInit.Wounded );
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
        BattleMgr.Inst.block += block;
        string blockToStr = Convert.ToString (BattleMgr.Inst.block);
        GameAsst._Inst.player.transform.parent.Find ("Block/Text").GetComponent<Text> ( ).text = blockToStr;

        int mana = plrInit.Mana;
        mana -= ManaCast;
        plrInit.Mana = mana;
        UpdatePlayerUiInform (mana);
        BattleMgr.Inst.RemoveToUsed ( );

        if ( BattleMgr.Inst.liveList.Count == 0 )
            GameAsst._Inst.lvPass = true;

    }

    //更新player面板信息
    public void UpdatePlayerUiInform ( int mana )
    {
        string manaToStr = Convert.ToString (mana);
        GameAsst._Inst.player.transform.parent.Find ("Mana/Text").GetComponent<Text> ( ).text = manaToStr;
    }

    //更新Enemy面板信息
    public void UpdateEnemyUiInform ( GameObject tar , int hp )
    {
        string hpToStr = Convert.ToString (hp);
        string maxhpToStr = Convert.ToString (tar.GetComponent<EnemyInitial> ( ).MaxHp);
        tar.transform.parent.Find ("Hp").GetComponent<Text> ( ).text = hpToStr + "/" + maxhpToStr;

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
