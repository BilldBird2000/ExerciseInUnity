using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//界面管理器,负责界面之间跳转
//先实现简单逻辑,从选择角色跳转到战斗界面
//必须&启动早>>直接单例实例化


namespace CardBased_V1
{
    public class UIMgr
    {
        public static UIMgr _Inst = new UIMgr ( );
        public Button btnJump = null;

        public void PlayerChoose ( )
        {
            GameObject.Find ("Launch").transform.Find ("UI_Login").gameObject.SetActive (true);
            Debug.Log ("成功加载角色选择界面...");
        }

        


    }
}

