using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardBased_V1;
using System;

public class PlayerInitial : MonoBehaviour, IRoleBase
{
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
    public int Mana { get; set; } = 0;
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


    public void Start ( )
    {
        Initial ( );
    }

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

        Debug.LogFormat ("++++++++初始化角色{0}" , Name);
        Debug.LogFormat ("{0},{1},{2},{3},{4},{5},{6},{7}" , Id , Name , MaxHp , Hp , Mana , Gold , Roletype , Rolestatus);
    }

    
}


