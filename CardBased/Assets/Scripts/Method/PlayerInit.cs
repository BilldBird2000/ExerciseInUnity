using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardBased_V1;


public class PlayerInit : MonoBehaviour, IRoleBase
{
    public void Init ( GameObject node )
    {
        int hp = 0;
        Debug.LogFormat ("++++++++初始化角色{0},Hp:{1}" , node.name , hp);
    }


}


