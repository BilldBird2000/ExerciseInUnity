using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardBased_V1
{
    public class GameAsst
    {
        public static GameAsst _Inst = new GameAsst ( );
        public Game game = GameObject.Find ("Launch").GetComponent<Game> ( );
        public GameObject player;
        public int checkId = -1;

        public Dictionary<string , int> playerDict = new Dictionary<string , int>
        {
            {"Sally",10001 },
            {"Brown",10002 },
            {"Coney",10003 }
        };

        public string playerDataPath = Application.streamingAssetsPath + "/Csv/PlayerTable.csv";
        //public string enemyDataPath = "";

        //集中管理表路径



    }
}

