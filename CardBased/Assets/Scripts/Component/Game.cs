using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardBased;

public class Game : MonoBehaviour
{
    //prefab
    public GameObject player;
    public GameObject [ ] enemyArray;

    
    public void Start ( )
    {
        UIMgr._Inst.StartUILogin ( );
    }

    //3.5;5;6.5
    public void BuildPlayer ( )
    {
        Transform parent = GameObject.Find ("Launch").transform.Find ("Role").transform;
        GameAsst._Inst.player = Instantiate (player , new Vector3 (-3 , 2 , 0) , Quaternion.Euler (0 , 0 , 0) , parent);
        GameAsst._Inst.player.AddComponent<OnClickObj> ( );

        //GameObject.Find ("Player(Clone)").transform.SetParent (parent);
    }

    



}


