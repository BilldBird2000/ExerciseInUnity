using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Game管理器
//代理关卡管理器,简化关卡逻辑,能读出表即可

namespace CardBased
{
    public class GameAsst
    {
        public static GameAsst Inst = new GameAsst ( );
        public static System.Random _Rd = new System.Random ( );
        public Game launch = GameObject.Find ("Launch").GetComponent<Game> ( );
        public GameObject player;
        public int checkId = -1;

        public int glvIndex = 40001;
        public bool lvPass = false;

        //从角色选择界面获取player的名字,然后查字典得到playerId
        //可以被替代,把界面中角色节点名字直接换成Id,获取gameobject.name然后转换成int,直接得到id
        public Dictionary<string , int> playerDict = new Dictionary<string , int>
        {
            {"Sally",10001 },
            {"Brown",10002 },
            {"Coney",10003 }
        };

        ///集中管理表路径
        public string playerDataPath = Application.streamingAssetsPath + "/Csv/PlayerTable.csv";
        public string enemyDataPath = Application.streamingAssetsPath + "/Csv/EnemyTable.csv";
        public string gamelvDataPath = Application.streamingAssetsPath + "/Csv/GamelevelTable.csv";
        public string cardWrrDataPath = Application.streamingAssetsPath + "/Csv/CardWarriorTableV2.csv";

        ///创建关卡
        public void BuildGamelevle ( )
        {
            launch.gameObject.GetComponent<GamelvInitial> ( ).Initial (glvIndex);
            BattleMgr.Inst.ShowGlvCount ( );
            launch.gameObject.GetComponent<GamelvInitial> ( ).BuildEnemy ( );
            glvIndex++;
        }


        //1.销毁脚本未实现
        //2.思路不可取,被废弃.应该采用初始化脚本中的数值的方法,而不是反复添加再销毁
        //public void CompleteGamelevel ( )
        //{
        //    Destroy (game.gameObject.GetComponent<GamelvlInitial> ( ));
        //}


    }
}

