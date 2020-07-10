using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardBased
{
    public class BattleMgr
    {
        private static BattleMgr _battleMgr = null;
        public static BattleMgr Inst
        {
            get
            {
                if ( _battleMgr == null )
                    _battleMgr = new BattleMgr ( );
                return _battleMgr;
            }
        }

        //洗牌,两个list是否需要变更为成员变量???待定
        public void DisOrder ( )
        {
            Transform usedPanel = GameObject.Find ("Launch/UI_Battle/Used").transform;
            Transform unusedPanel = GameObject.Find ("Launch/UI_Battle/Unused").transform;
            List<CardInitial> cardList = new List<CardInitial> ( );
            List<GameObject> disOrderList = new List<GameObject> ( );

            cardList.AddRange (usedPanel.gameObject.GetComponentsInChildren<CardInitial> ( ));
            foreach ( CardInitial card in cardList )
                disOrderList.Add (card.gameObject);

            for ( int i = disOrderList.Count; i > 0; i-- )
            {
                int num = GameAsst._Rd.Next (0 , disOrderList.Count);
                disOrderList [ num ].transform.SetParent (unusedPanel);
                disOrderList.RemoveAt (num);
            }

        }






        //洗牌,废弃的方法,由更换父节点代替列表切换
        //public int maxEnemies = 5;
        //public List<GameObject> extractList;    //抽到的牌
        //public List<GameObject> unusedList;     //发牌堆
        //public void DisOrder ( List<GameObject> cardList )
        //{
        //    List<GameObject> tempList = new List<GameObject> ( );
        //    foreach ( GameObject card in cardList )
        //        tempList.Add (card);
        //    List<GameObject> disOrderList = new List<GameObject> ( );
        //    for ( int i = tempList.Count; i > 0; i-- )
        //    {
        //        int num = GameAsst._Rd.Next (0 , tempList.Count);
        //        disOrderList.Add (tempList [ num ]);
        //        tempList.RemoveAt (num);
        //    }
        //    //return disOrderList;
        //}


    }

}
