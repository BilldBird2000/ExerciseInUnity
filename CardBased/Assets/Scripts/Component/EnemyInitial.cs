using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardBased;

public class EnemyInitial : MonoBehaviour, IRoleBase
{
    public int Counter { set; get; } = 1;   //表外属性
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
            else if ( value > 0 && value < MaxHp )
                hp = value;
            else
            {
                hp = 0;
                Rolestatus = RoleStatus.Dead;
                Die ( );
                BattleMgr.Inst.liveList.Remove (transform.parent.gameObject);
                Destroy (transform.parent.gameObject , 0.1f);
                transform.parent.parent.parent.gameObject.SetActive (false);
            }
        }
        get { return hp; }
    }
    public int Mana { get; set; } = 0;
    public int Gold { get; set; } = 0;
    public RoleType Roletype { get; set; } = RoleType.Enemy;
    public RoleStatus Rolestatus { get; set; } = RoleStatus.Alive;

    public void Die ( )
    {
        Debug.LogFormat ("{0}Die..." , Name);
    }

    public void UseSkill ( )
    {
        Debug.Log ("UseSkill...");
    }

    public void Initial ( int enemyId )
    {
        Dictionary<string , string> rowData = CsvReader.Inst.GetRowDict (GameAsst._Inst.enemyDataPath , enemyId);
        List<string> header = CsvReader.Inst.GetHeaderList (rowData);
        Id = enemyId;
        Name = rowData [ header [ 1 ] ];
        MaxHp = Convert.ToInt32 (rowData [ header [ 2 ] ]);
        Hp = Convert.ToInt32 (rowData [ header [ 3 ] ]);
        Mana = Convert.ToInt32 (rowData [ header [ 4 ] ]);
        Gold = Convert.ToInt32 (rowData [ header [ 5 ] ]);
        Roletype = ( RoleType ) ( Enum.Parse (typeof (RoleType) , rowData [ header [ 6 ] ]) );
        Rolestatus = ( RoleStatus ) ( Enum.Parse (typeof (RoleStatus) , rowData [ header [ 7 ] ]) );

        //Debug.LogFormat ("++++++++初始化敌人{0},{1},{2},{3},{4},{5},{6},{7}" , Name , Id , MaxHp , Hp , Mana , Gold , Roletype , Rolestatus);
    }


    //战中角色携带的buff
    public int Block { set; get; } = 0;
    public int Strength { set; get; } = 0;
    public int StrengthRnd { set; get; } = 0;
    public int Agility { set; get; } = 0;
    public int AgilityRnd { set; get; } = 0;
    public float Weak { set; get; } = 0;
    public int WeakRnd { set; get; } = 0;
    public float Fragile { set; get; } = 0;
    public int FragileRnd { set; get; } = 0;
    public float Wounded { set; get; } = 0;
    public int WndRnd { set; get; } = 0;

}
