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

    //实例化player
    public void BuildPlayer ( )
    {
        Transform parent = GameObject.Find ("Launch").transform.Find ("UI_RoleInform/Player").transform;
        GameAsst._Inst.player = Instantiate (player , new Vector3 (-3 , 2 , 0) , Quaternion.Euler (0 , 0 , 0) , parent);
        GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).Initial ( );
        GameAsst._Inst.player.AddComponent<OnClickObj> ( );
        UIMgr._Inst.InitUIInform (GameAsst._Inst.player);

        //GameObject.Find ("Player(Clone)").transform.SetParent (parent);
    }

    



}


