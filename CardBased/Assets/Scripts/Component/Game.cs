using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardBased_V1;

public class Game : MonoBehaviour
{
    //prefab
    public GameObject player;
    public GameObject [ ] enemyArray;

    
    public void Start ( )
    {
        UIMgr._Inst.PlayerChoose ( );

    }

    //3.5;5;6.5
    public void BuildPlayer (  )
    {
        Transform parent = GameObject.Find ("Launch").transform.Find ("Role").transform;
        GameAsst._Inst.player = Instantiate (player , new Vector3 (-3 , 2 , 0) , Quaternion.Euler (0 , 0 , 0) , parent);
        //GameObject.Find ("Player(Clone)").transform.SetParent (parent);
    }

    public void BuildEnemy ( )
    {

    }



}


