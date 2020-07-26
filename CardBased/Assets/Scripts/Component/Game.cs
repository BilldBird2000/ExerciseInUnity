using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardBased;

public class Game : MonoBehaviour
{
    ///prefab
    public GameObject playerPrefab;
    public GameObject [ ] enemyPrefabArray;

    
    public void Start ( )
    {
        UIMgr._Inst.StartUILogin ( );
    }

    ///实例化player.约定UI_RoleInform的第一个子节点存放player
    public void BuildPlayer ( )
    {
        Transform parent = GameObject.Find ("Launch").transform.Find ("UI_RoleInform/Player/Pos").transform;
        GameAsst._Inst.player = Instantiate (playerPrefab , parent).transform.GetChild (0).gameObject;
        GameAsst._Inst.player.transform.parent.parent.parent.gameObject.SetActive (true);
        GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).Initial ( );
        GameAsst._Inst.player.AddComponent<OnClickObj> ( );
        UIMgr._Inst.InitUIInform (GameAsst._Inst.player);

        //GameObject.Find ("Player(Clone)").transform.SetParent (parent);
    }

    



}


