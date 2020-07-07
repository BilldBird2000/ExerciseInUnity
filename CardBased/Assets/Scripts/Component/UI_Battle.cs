using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CardBased;

//因为有了实例对象,Id的作用被弱化了

public class UI_Battle : MonoBehaviour
{
    //prefab
    public GameObject [ ] cardArray;
    void Start()
    {
        StartCard ( );
    }

    public void StartCard ( )
    {
        BattleMgr.Inst.extractList = new List<GameObject> ( );
        BattleMgr.Inst.unusedList = new List<GameObject> ( );
        Transform parent = GameObject.Find ("Launch/UI_Battle/Unused").transform;
        int index;

        for ( int i = 0; i < 5; i++ )
        {
            GameObject card = Instantiate (cardArray [ 0 ] , new Vector3 (10 , 0 , 0) , Quaternion.Euler (0 , 0 , 0) , parent);
            index = Convert.ToInt32 (cardArray [ 0 ].name);
            card.GetComponent<CardInitial> ( ).Initial (index);
            card.GetComponent<CardInitial> ( ).Id += i;
            card.AddComponent<OnClickObj> ( );
            BattleMgr.Inst.extractList.Add (card);
        }
        for ( int i = 0; i < 5; i++ )
        {
            GameObject card = Instantiate (cardArray [ 1 ] , new Vector3 (10 , 0 , 0) , Quaternion.Euler (0 , 0 , 0) , parent);
            index = Convert.ToInt32 (cardArray [ 1 ].name);
            card.GetComponent<CardInitial> ( ).Initial (index);
            card.GetComponent<CardInitial> ( ).Id += i;
            card.AddComponent<OnClickObj> ( );
            BattleMgr.Inst.extractList.Add (card);
        }
        BattleMgr.Inst.unusedList = BattleMgr.Inst.DisOrder (BattleMgr.Inst.extractList);
        Debug.Log ("起手牌实例化完成!!");
    }

    public void BuildCard ( int index )
    {

    }



}
