using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardBased;
using System;

public class PlayerInitial : MonoBehaviour, IRoleBase
{
    //public int Counter { set; get; } = 1;
    public int Id { get; set; } = 0;
    public string Name { get; set; } = "";
    public int MaxHp { get; set; } = 0;
    private int hp = 9999;
    public int Hp
    {
        set
        {
            if ( value >= MaxHp )
                hp = MaxHp;
            else if ( value >= 0 && value < MaxHp )
                hp = value;
            else
            {
                hp = 0;
                Rolestatus = RoleStatus.Dead;
                Die ( );
            }
        }
        get { return hp; }
    }
    public int MaxMana { set; get; } = 3;   //表外,用于每回合初始化蓝量
    private int mana = 0;
    public int Mana
    {
        set
        {
            if ( value > 0 )
                mana = value;
            else
            {
                mana = 0;
                Debug.Log ("魔法值为0...");
            }
        }
        get { return mana; }
    }
    public int Gold { get; set; } = 0;
    public RoleType Roletype { get; set; } = RoleType.Player;
    public RoleStatus Rolestatus { get; set; } = RoleStatus.Alive;

    public void Die ( )
    {
        Debug.LogFormat ("{0}挂了..." , Name);
    }
    public void UseSkill ( )
    {
        Debug.Log ("UseSkill...");
    }

    //使用技能思路调整:卡牌技能放到CardInitial类中,因为user一定是player,而且可以直接调用卡牌的各项属性值,更方便
    //public void UseSkill ( GameObject tar )
    //{
    //    Debug.LogFormat ("Player UseSkill to {0}..." , tar.name);
    //}


    public void Initial ( )
    {
        //查表赋值
        Dictionary<string , string> rowData = CsvReader.Inst.GetRowDict (GameAsst._Inst.playerDataPath , GameAsst._Inst.checkId);
        List<string> header = CsvReader.Inst.GetHeaderList (rowData);
        Id = GameAsst._Inst.checkId;
        Name = rowData [ header [ 1 ] ];
        MaxHp = Convert.ToInt32 (rowData [ header [ 2 ] ]);
        Hp = Convert.ToInt32 (rowData [ header [ 3 ] ]);
        Mana = Convert.ToInt32 (rowData [ header [ 4 ] ]);
        Gold = Convert.ToInt32 (rowData [ header [ 5 ] ]);
        Roletype = ( RoleType ) ( Enum.Parse (typeof (RoleType) , rowData [ header [ 6 ] ]) );
        Rolestatus = ( RoleStatus ) ( Enum.Parse (typeof (RoleStatus) , rowData [ header [ 7 ] ]) );

        Debug.Log ("++++++++初始化角色:" + Name);
        //Debug.LogFormat ("{0},{1},{2},{3},{4},{5},{6},{7}" , Id , Name , MaxHp , Hp , Mana , Gold , Roletype , Rolestatus);
    }


    //战中角色携带的buff
    public float atkadd;
    public int atkaddrnd;
    public float atkrdc;
    public int atkrdcrnd;
    public float blcadd;
    public int blcaddrnd;
    public float blcrdc;
    public int blcrdcrnd;
    public float wounded;
    public int wndrnd;
    public int poison;
    public int psnrnd;


}


