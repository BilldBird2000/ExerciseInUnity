using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

//Game管理器
//代理关卡管理器,简化关卡逻辑,能读出表即可

namespace CardBased
{
    public class GameAsst
    {
        public static GameAsst _Inst = new GameAsst ( );
        public static System.Random _Rd = new System.Random ( );
        public Game game = GameObject.Find ("Launch").GetComponent<Game> ( );
        public GameObject player;
        public int checkId = -1;

        public int glvIndex = 1001;
        public bool lvPass = false;

        public Dictionary<string , int> playerDict = new Dictionary<string , int>
        {
            {"Sally",10001 },
            {"Brown",10002 },
            {"Coney",10003 }
        };

        //集中管理表路径
        public string playerDataPath = Application.streamingAssetsPath + "/Csv/PlayerTable.csv";
        public string enemyDataPath = Application.streamingAssetsPath + "/Csv/EnemyTable.csv";
        public string gamelvDataPath = Application.streamingAssetsPath + "/Csv/GamelevelTable.csv";
        public string cardWarriorDataPath = Application.streamingAssetsPath + "Csv/CardWarrior.csv";

        public void BuildGamelevle ( )
        {
            game.gameObject.AddComponent<GamelvlInitial> ( );
        }

        public void CompleteGamelevel ( )
        {
            //Destroy (game.gameObject.GetComponent<GamelvlInitial> ( ));
        }


    }
}

