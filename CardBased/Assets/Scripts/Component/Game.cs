using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardBased;

public class Game : MonoBehaviour
{
    ///prefab
    public GameObject playerPrefab;
    public Sprite strengthSprite;
    public Sprite agilitySprite;
    public Sprite weakSprite;
    public Sprite fragileSprite;
    public Sprite woundenSprite;
    public GameObject [ ] enemyPrefabArray;



    public void Start ( )
    {
        UIMgr.Inst.StartUILogin ( );
    }

    ///实例化player.约定UI_RoleInform的第一个子节点存放player
    public void BuildPlayer ( )
    {
        Transform parent = GameObject.Find ("Launch").transform.Find ("UI_RoleInform/Player/Pos").transform;
        GameAsst.Inst.player = Instantiate (playerPrefab , parent).transform.GetChild (0).gameObject;
        GameAsst.Inst.player.transform.parent.parent.parent.gameObject.SetActive (true);
        GameAsst.Inst.player.GetComponent<PlayerInitial> ( ).Initial ( );
        GameAsst.Inst.player.AddComponent<OnClickObj> ( );
        UIMgr.Inst.InitUIInform (GameAsst.Inst.player);

        //GameObject.Find ("Player(Clone)").transform.SetParent (parent);
    }

    



}


