using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CardBased;

//Id:作为表内行数据的索引,在表内是唯一的;当场景中实例多个相同元素时,Id有没有必要做差别处理???

public class UI_Battle : MonoBehaviour
{
    //prefab
    public GameObject [ ] cardArray;

    void Start()
    {
        BuildStartCard ( );
    }


    //战斗开始,生成起手的10张牌
    public void BuildStartCard ( )
    {
        //BattleMgr.Inst.extractList = new List<GameObject> ( );
        Transform parent = GameObject.Find ("Launch/UI_Battle/Used").transform;
        int index;

        for ( int i = 0; i < 5; i++ )
        {
            GameObject card = Instantiate (cardArray [ 0 ] , new Vector3 (10 , 0 , 0) , Quaternion.Euler (0 , 0 , 0) , parent);
            card.AddComponent<CardInitial> ( );
            index = Convert.ToInt32 (cardArray [ 0 ].name);
            card.GetComponent<CardInitial> ( ).Initial (index);
            card.GetComponent<CardInitial> ( ).Counter += i;
            card.GetComponent<CardInitial> ( ).Cardstatus = CardStatus.Unused;
            card.AddComponent<OnClickObj> ( );
            //BattleMgr.Inst.extractList.Add (card);
            if ( card.GetComponent<CardInitial> ( ).Counter == card.GetComponent<CardInitial> ( ).MaxCounter )
            {
                Debug.LogFormat ("卡牌{0}已经达到最大数量,不能继续实例化!!!" , card.GetComponent<CardInitial> ( ).Name);
                //缺少一个核心操作:写表;把CanGet改写为false.
                break;
            }
        }
        for ( int i = 0; i < 5; i++ )
        {
            GameObject card = Instantiate (cardArray [ 1 ] , new Vector3 (10 , 0 , 0) , Quaternion.Euler (0 , 0 , 0) , parent);
            card.AddComponent<CardInitial> ( );
            index = Convert.ToInt32 (cardArray [ 1 ].name);
            card.GetComponent<CardInitial> ( ).Initial (index);
            card.GetComponent<CardInitial> ( ).Counter += i;
            card.GetComponent<CardInitial> ( ).Cardstatus = CardStatus.Unused;
            card.AddComponent<OnClickObj> ( );
            //BattleMgr.Inst.extractList.Add (card);
            if ( card.GetComponent<CardInitial> ( ).Counter == card.GetComponent<CardInitial> ( ).MaxCounter )
            {
                Debug.LogFormat ("卡牌<{0}>已经达到最大数量,不能继续实例化!!!" , card.GetComponent<CardInitial> ( ).Name);
                //缺少一个核心操作:写表;把CanGet改写为false.
                break;
            }
        }
        Debug.Log ("10张起手牌实例化完成++++++++");

        BattleMgr.Inst.DisOrder ( );
        Debug.Log ("洗牌完成~~~~~~~~");
    }

    public void BuildCard ( int index )
    {

    }



}
