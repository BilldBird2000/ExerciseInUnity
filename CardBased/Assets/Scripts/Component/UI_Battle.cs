using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using CardBased;

//Id:作为表内行数据的索引,在表内是唯一的;当场景中实例多个相同元素时,Id有没有必要做差别处理???

public class UI_Battle : MonoBehaviour
{
    //prefab
    public GameObject [ ] cardArray;

    public void Start ( )
    {
        OnClickBtn ( );
        BuildStartCard ( );
    }

    //public void Update ( )
    //{
    //    if ( BattleMgr.Inst.liveList.Count == 0 )
    //    {
    //        BattleMgr.Inst.ClearHand ( );
    //        Debug.Log ("当前关卡结束,获得奖励,即将进入下一关!!!");
    //        GameAsst._Inst.game.gameObject.transform.Find ("UI_PopUp").gameObject.SetActive (true);
    //        GameAsst._Inst.game.gameObject.transform.Find ("UI_PopUp/Reward").gameObject.SetActive (true);
    //        BattleMgr.Inst.SelectReward ( );

    //        BattleMgr.Inst.liveList.Add (GameAsst._Inst.player);
    //        //GameAsst._Inst.BuildGamelevle ( );
    //    }
    //}

    //添加Battle界面的按钮点击事件
    public void OnClickBtn ( )
    {
        Button btnRound = transform.Find ("Round").GetComponent<Button> ( );
        btnRound.onClick.AddListener (NextRound);
    }

    //结束player行动
    public void NextRound ( )
    {
        Debug.Log ("Player行动结束!!!");
        BattleMgr.Inst.ClearHand ( );
        Debug.Log ("Enemy开始行动...Enemy行动结束...开始下一回合!!!!");
        StartCoroutine (BattleMgr.Inst.Distribution ( ));
    }

    //战斗开始,生成起手的10张牌,重新排序,发5张牌
    public void BuildStartCard ( )
    {
        //BattleMgr.Inst.extractList = new List<GameObject> ( );
        Transform parent = GameObject.Find ("Launch/UI_Battle/Used").transform;
        Vector3 pos;
        int index;

        for ( int i = 0; i < 5; i++ )
        {
            //GameObject card = Instantiate (cardArray [ 0 ] , new Vector3 (1000 , 0 , 0) , Quaternion.Euler (0 , 0 , 0) , parent);
            GameObject card = Instantiate (cardArray [ 0 ] , parent);
            pos = card.transform.position;
            pos.x = 1000;
            pos.y = 0;
            card.transform.position = pos;
            card.AddComponent<CardInitial> ( );
            index = Convert.ToInt32 (cardArray [ 0 ].name);
            card.GetComponent<CardInitial> ( ).Initial (index);
            card.GetComponent<CardInitial> ( ).Counter += i;
            //card.GetComponent<CardInitial> ( ).Cardstatus = CardStatus.Unused;
            card.AddComponent<OnClickObj> ( );
            //BattleMgr.Inst.extractList.Add (card);
            if ( card.GetComponent<CardInitial> ( ).Counter == card.GetComponent<CardInitial> ( ).MaxCounter )
            {
                Debug.LogFormat ("卡牌<{0}>已经达到最大数量,不能继续实例化.........." , card.GetComponent<CardInitial> ( ).Name);
                //缺少一个核心操作:写表;把CanGet改写为false.
                break;
            }
        }
        for ( int i = 0; i < 5; i++ )
        {
            //GameObject card = Instantiate (cardArray [ 1 ] , new Vector3 (1000 , 0 , 0) , Quaternion.Euler (0 , 0 , 0) , parent);
            GameObject card = Instantiate (cardArray [ 1 ] , parent);
            pos = card.transform.position;
            pos.x = 1000;
            pos.y = -400;
            card.transform.position = pos;
            card.AddComponent<CardInitial> ( );
            index = Convert.ToInt32 (cardArray [ 1 ].name);
            card.GetComponent<CardInitial> ( ).Initial (index);
            card.GetComponent<CardInitial> ( ).Counter += i;
            //card.GetComponent<CardInitial> ( ).Cardstatus = CardStatus.Unused;
            card.AddComponent<OnClickObj> ( );
            //BattleMgr.Inst.extractList.Add (card);
            if ( card.GetComponent<CardInitial> ( ).Counter == card.GetComponent<CardInitial> ( ).MaxCounter )
            {
                Debug.LogFormat ("卡牌<{0}>已经达到最大数量,不能继续实例化.........." , card.GetComponent<CardInitial> ( ).Name);
                //缺少一个核心操作:写表;把CanGet改写为false.
                break;
            }
        }
        Debug.Log ("10张起手牌实例化完成++++++++");

        BattleMgr.Inst.DisOrder ( );
        Debug.Log ("洗牌完成~~~~~~~~");

        StartCoroutine (BattleMgr.Inst.Distribution ( ));
    }

    public void BuildCard ( int index )
    {

    }



}
