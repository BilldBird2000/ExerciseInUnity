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

        public List<GameObject> extractList;    //抽到的牌
        public List<GameObject> unusedList;     //发牌堆

        //洗牌
        public List<GameObject> DisOrder ( List<GameObject> cardList )
        {
            List<GameObject> disOrderList = new List<GameObject> ( );
            for ( int i = cardList.Count; i > 0; i-- )
            {
                int num = GameAsst._Rd.Next (0 , cardList.Count);
                disOrderList.Add (cardList [ num ]);
                cardList.RemoveAt (num);
            }
            return disOrderList;
        }


        





    }

}
