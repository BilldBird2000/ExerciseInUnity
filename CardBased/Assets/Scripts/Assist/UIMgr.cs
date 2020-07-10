﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UI管理器,实现界面之间跳转
//btnJump按钮在每个界面是唯一的,so只声明一个,try反复赋值
//必要且启动早,so直接单例实例化


namespace CardBased
{
    public class UIMgr
    {
        public static UIMgr _Inst = new UIMgr ( );
        public Button btnJump = null;
        public List<Button> btnList = new List<Button> ( );


        //启动游戏后加载的第一个界面
        public void StartUILogin ( )
        {
            GameObject.Find ("Launch").transform.Find ("UI_Login").gameObject.SetActive (true);
            Debug.Log ("成功加载角色选择界面>>>>>>>>>>");
        }

        //跳转到战斗界面,实例化player,实例化关卡
        //清空之前界面中的不会再被调用的数据,将指针准备好,给其他界面使用,减少新开辟内存
        public void JumpToUIBattle ( )
        {
            GameObject.Find ("Launch").transform.Find ("UI_Battle").gameObject.SetActive (true);
            Debug.Log ("成功加载战斗界面>>>>>>>>>>");

            GameAsst._Inst.checkId = GameAsst._Inst.playerDict [ GameAsst._Inst.player.name ];
            GameAsst._Inst.game.BuildPlayer ( );

            GameAsst._Inst.game.gameObject.AddComponent<GamelvlInitial> ( );
            GameAsst._Inst.BuildGamelevle ( );

            btnList = null;
            btnJump = null;
        }




    }
}
