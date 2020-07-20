using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using CardBased;

public class CardInitial : MonoBehaviour, ICardBase
{
    public bool CanGet { set; get; } = true;
    public int MaxCounter { set; get; } = 0;
    private int counter = 1;
    public int Counter
    {
        set
        {
            if ( counter >= MaxCounter )
            {
                counter = MaxCounter;
                CanGet = false;
            }
            else if ( counter >= 1 && counter < MaxCounter )
                counter = value;
            else
                counter = 0;
        }
        get { return counter; }
    }
    public int Id { set; get; } = 0;
    public string Name { set; get; } = "";
    public CardTpye Cardtype { set; get; } = CardTpye.Attack;
    public CardStatus Cardstatus { set; get; } = CardStatus.Unused;
    public CardRare Cardrare { set; get; } = CardRare.LvC;
    public CardLevel Cardlevel { set; get; } = CardLevel.LvB;
    public int ManaCast { set; get; } = 0;
    public int Attack { set; get; } = 0;
    public float AtkAdd { set; get; } = 0;
    public int AtkAddRnd { set; get; } = 0;
    public float AtkRdc { set; get; } = 0;
    public int AtkRdcRnd { set; get; } = 0;
    public int Block { set; get; } = 0;
    public float BlcAdd { set; get; } = 0;
    public int BlcAddRnd { set; get; } = 0;
    public float BlcRdc { set; get; } = 0;
    public int BlcRdcRnd { set; get; } = 0;
    public float Wounded { set; get; } = 0;
    public int WndRnd { set; get; } = 0;
    public int Poison { set; get; } = 0;
    public int PsnRnd { set; get; } = 0;

    public void Initial ( int index )
    {
        Dictionary<string , string> rowDict = CsvReader.Inst.GetRowDict (GameAsst._Inst.cardWrrDataPath , index);
        List<string> header = CsvReader.Inst.GetHeaderList (rowDict);

        Id = index;
        Name = rowDict [ header [ 1 ] ];
        Cardtype = ( CardTpye ) ( Enum.Parse (typeof (CardTpye) , rowDict [ header [ 2 ] ]) );
        Cardstatus = ( CardStatus ) ( Enum.Parse (typeof (CardStatus) , rowDict [ header [ 3 ] ]) );
        Cardrare = ( CardRare ) ( Enum.Parse (typeof (CardRare) , rowDict [ header [ 4 ] ]) );
        Cardlevel = ( CardLevel ) ( Enum.Parse (typeof (CardLevel) , rowDict [ header [ 5 ] ]) );
        ManaCast = Convert.ToInt32 (rowDict [ header [ 6 ] ]);
        Attack = Convert.ToInt32 (rowDict [ header [ 7 ] ]);
        AtkAdd = Convert.ToSingle (rowDict [ header [ 8 ] ]);
        AtkAddRnd = Convert.ToInt32 (rowDict [ header [ 9 ] ]);
        AtkRdc = Convert.ToSingle (rowDict [ header [ 10 ] ]);
        AtkRdcRnd = Convert.ToInt32 (rowDict [ header [ 11 ] ]);
        Block = Convert.ToInt32 (rowDict [ header [ 12 ] ]);
        BlcAdd = Convert.ToSingle (rowDict [ header [ 13 ] ]);
        BlcAddRnd = Convert.ToInt32 (rowDict [ header [ 14 ] ]);
        BlcRdc = Convert.ToSingle (rowDict [ header [ 15 ] ]);
        BlcRdcRnd = Convert.ToInt32 (rowDict [ header [ 16 ] ]);
        Wounded = Convert.ToSingle (rowDict [ header [ 17 ] ]);
        WndRnd = Convert.ToInt32 (rowDict [ header [ 18 ] ]);
        Poison = Convert.ToInt32 (rowDict [ header [ 19 ] ]);
        PsnRnd = Convert.ToInt32 (rowDict [ header [ 20 ] ]);
        MaxCounter = Convert.ToInt32 (rowDict [ header [ 21 ] ]);

    }

    public void SkillFormula ( GameObject tar )
    {
        int damage = Attack;
        int tarHp = tar.GetComponent<EnemyInitial> ( ).Hp;
        int mana = GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).Mana;
        tarHp -= damage;
        mana -= ManaCast;
        Debug.LogFormat ("{0}向{1}施放技能{2}!!!" , GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).Name , tar.GetComponent<EnemyInitial> ( ).Name , Name);

        tar.GetComponent<EnemyInitial> ( ).Hp = tarHp;
        UpdateEnemyUiInform (tar , tarHp);
        GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).Mana = mana;
        UpdatePlayerUiInform (mana);
    }

    public void UpdatePlayerUiInform ( int mana )
    {
        string manaToStr = Convert.ToString (mana);
        GameAsst._Inst.player.transform.parent.Find ("Hp").GetComponent<Text> ( ).text = manaToStr;
    }

    public void UpdateEnemyUiInform ( GameObject tar , int hp )
    {
        string hpToStr = Convert.ToString (hp);
        string maxhpToStr = Convert.ToString (tar.GetComponent<EnemyInitial> ( ).MaxHp);
        tar.transform.parent.Find ("Hp").GetComponent<Text> ( ).text = hpToStr + "/" + maxhpToStr;

    }
}
