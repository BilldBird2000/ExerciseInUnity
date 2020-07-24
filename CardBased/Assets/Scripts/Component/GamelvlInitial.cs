using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardBased;
using System;


public class GamelvlInitial : MonoBehaviour, IGamelvBase
{
    public int Id { set; get; } = 0;
    public string Name { set; get; } = "";
    public bool NotPass { set; get; } = true;
    public GamelevelType Glvtype { set; get; } = GamelevelType.Battle;
    public GamelevelStatus Glvstatus { set; get; } = GamelevelStatus.Undone;
    public int NPCId { set; get; } = 0;
    public int Enemy1Id { set; get; } = 0;
    public int Enemy1Num { set; get; } = 0;
    public int Enemy2Id { set; get; } = 0;
    public int Enemy2Num { set; get; } = 0;
    public int Enemy3Id { set; get; } = 0;
    public int Enemy3Num { set; get; } = 0;
    public int Enemy4Id { set; get; } = 0;
    public int Enemy4Num { set; get; } = 0;
    public int Enemy5Id { set; get; } = 0;
    public int Enemy5Num { set; get; } = 0;


    public void Update ( )
    {
        if ( GameAsst._Inst.lvPass )
        {
            Glvstatus = GamelevelStatus.Done;
            BattleMgr.Inst.ClearHand ( );
            Debug.Log ("当前关卡结束,获得奖励,即将进入下一关!!!");
            
            BattleMgr.Inst.SelectReward ( );
            //GameAsst._Inst.BuildGamelevle ( );
            GameAsst._Inst.lvPass = false;
        }
    }

    public void Initial ( int glvIndex )
    {
        Dictionary<string , string> rowData = CsvReader.Inst.GetRowDict (GameAsst._Inst.gamelvDataPath , glvIndex);
        List<string> header = CsvReader.Inst.GetHeaderList (rowData);

        Id = glvIndex;
        Name = rowData [ header [ 1 ] ];
        NotPass = Convert.ToBoolean (rowData [ header [ 2 ] ]);
        Glvtype = ( GamelevelType ) ( Enum.Parse (typeof (GamelevelType) , rowData [ header [ 3 ] ]) );
        Glvstatus = ( GamelevelStatus ) ( Enum.Parse (typeof (GamelevelStatus) , rowData [ header [ 4 ] ]) );
        NPCId = Convert.ToInt32 (rowData [ header [ 5 ] ]);
        Enemy1Id = Convert.ToInt32 (rowData [ header [ 6 ] ]);
        Enemy1Num = Convert.ToInt32 (rowData [ header [ 7 ] ]);
        Enemy2Id = Convert.ToInt32 (rowData [ header [ 8 ] ]);
        Enemy2Num = Convert.ToInt32 (rowData [ header [ 9 ] ]);
        Enemy3Id = Convert.ToInt32 (rowData [ header [ 10 ] ]);
        Enemy3Num = Convert.ToInt32 (rowData [ header [ 11 ] ]);
        Enemy4Id = Convert.ToInt32 (rowData [ header [ 12 ] ]);
        Enemy4Num = Convert.ToInt32 (rowData [ header [ 13 ] ]);
        Enemy5Id = Convert.ToInt32 (rowData [ header [ 14 ] ]);
        Enemy5Num = Convert.ToInt32 (rowData [ header [ 15 ] ]);

        //Debug.LogFormat ("关卡信息:{0}_{1},{2}_{3},{4}_{5},{6}_{7},{8}_{9}" ,
        //    Enemy1Id , Enemy1Num , Enemy2Id , Enemy2Num , Enemy3Id , Enemy3Num , Enemy4Id , Enemy4Num , Enemy5Id , Enemy5Num);

    }

    public void BuildEnemy ( )
    {
        int childNum = 1;
        Transform parent;

        for ( int i = 0; i < Enemy1Num; i++ )
        {
            parent = GameAsst._Inst.game.gameObject.transform.Find ("UI_RoleInform").transform.GetChild (childNum).Find ("Pos");
            GameObject enemy = Instantiate (GameAsst._Inst.game.enemyPrefabArray [ 0 ] , parent).transform.GetChild (0).gameObject;
            enemy.transform.parent.parent.parent.gameObject.SetActive (true);
            childNum++;
            enemy.AddComponent<EnemyInitial> ( );
            enemy.GetComponent<EnemyInitial> ( ).Initial (Enemy1Id);
            enemy.GetComponent<EnemyInitial> ( ).Counter += i;
            enemy.GetComponent<EnemyInitial> ( ).Gold = GameAsst._Rd.Next (1 , 5);
            enemy.AddComponent<OnClickObj> ( );
            UIMgr._Inst.InitUIInform (enemy);
            BattleMgr.Inst.liveList.Add (enemy.transform.parent.gameObject);

            //Debug.LogFormat ("++++初始化敌人{0},ID:{1}_{4},Tpye:{2},Gold:{3}." , enemy.GetComponent<EnemyInitial> ( ).Name , enemy.GetComponent<EnemyInitial> ( ).Id ,
            //    enemy.GetComponent<EnemyInitial> ( ).Roletype , enemy.GetComponent<EnemyInitial> ( ).Gold , enemy.GetComponent<EnemyInitial> ( ).Counter);
        }

        for ( int i = 0; i < Enemy2Num; i++ )
        {
            parent = GameAsst._Inst.game.gameObject.transform.Find ("UI_RoleInform").transform.GetChild (childNum).Find ("Pos");
            GameObject enemy = Instantiate (GameAsst._Inst.game.enemyPrefabArray [ 1 ] , parent).transform.GetChild (0).gameObject;
            enemy.transform.parent.parent.parent.gameObject.SetActive (true);
            childNum++;
            enemy.AddComponent<EnemyInitial> ( );
            enemy.GetComponent<EnemyInitial> ( ).Initial (Enemy2Id);
            enemy.GetComponent<EnemyInitial> ( ).Counter += i;
            enemy.GetComponent<EnemyInitial> ( ).Gold = GameAsst._Rd.Next (5 , 8);
            enemy.AddComponent<OnClickObj> ( );
            UIMgr._Inst.InitUIInform (enemy);
            BattleMgr.Inst.liveList.Add (enemy.transform.parent.gameObject);

            //Debug.LogFormat ("++++初始化敌人{0},ID:{1}_{4},Tpye:{2},Gold:{3}." , enemy.GetComponent<EnemyInitial> ( ).Name , enemy.GetComponent<EnemyInitial> ( ).Id ,
            //    enemy.GetComponent<EnemyInitial> ( ).Roletype , enemy.GetComponent<EnemyInitial> ( ).Gold , enemy.GetComponent<EnemyInitial> ( ).Counter);
        }



    }



}
