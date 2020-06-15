using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace CardBased_V1
{
    public class PlayerInit : RoleBase
    {
        public void Init( GameObject node )
        {
            int hp = playerInfo [ node.name ];
            Debug.LogFormat ("++++++++初始化角色{0},Hp:{1}" , node.name , hp);
        }


    }
}

