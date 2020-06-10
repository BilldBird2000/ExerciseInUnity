using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//界面管理器,负责界面之间跳转
//先实现简单逻辑,从选择角色跳转到战斗界面


namespace CardBased_V1
{
    public class InterfaceMgr
    {
        private static InterfaceMgr _interfaceMgr = null;
        public static InterfaceMgr Ins
        {
            get
            {
                if ( _interfaceMgr == null )
                    _interfaceMgr = new InterfaceMgr ( );
                return _interfaceMgr;
            }
        }

        public void CanvasJump ( )
        {
            Debug.Log ("成功加载角色选择界面...");


        }




    }
}

