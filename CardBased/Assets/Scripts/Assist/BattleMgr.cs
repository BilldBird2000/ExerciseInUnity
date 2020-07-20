using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//查找子节点: usedPanel.GetChild (i).gameObject; usedPanel是Transform类型


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

        public Transform used = GameObject.Find ("Launch/UI_Battle/Used").transform;
        public Transform unused = GameObject.Find ("Launch/UI_Battle/Unused").transform;
        public Transform inhand = GameObject.Find ("Launch/UI_Battle/Inhand").transform;

        public int FixCounter { set; get; } = 5;  //每回合默认发牌张数
        //public List<GameObject> skillCard = new List<GameObject> ( );
        public GameObject [ ] skillCardArr = new GameObject [ 2 ];
        public GameObject skillCard;
        private Vector3 pos;
        private readonly int offset = 30;


        //洗牌
        public void DisOrder ( )
        {
            List<GameObject> disOrderList = new List<GameObject> ( );
            for ( int i = 0; i < used.childCount; i++ )
                disOrderList.Add (used.GetChild (i).gameObject);

            for ( int i = disOrderList.Count; i > 0; i-- )
            {
                int num = GameAsst._Rd.Next (0 , disOrderList.Count);
                disOrderList [ num ].transform.SetParent (unused);
                disOrderList.RemoveAt (num);
            }

            //将子节点添加进list,已被usedPanel.GetChild (i).gameObject替代
            //List<CardInitial> cardList = new List<CardInitial> ( );
            //cardList.AddRange (usedPanel.gameObject.GetComponentsInChildren<CardInitial> ( ));
            //foreach ( CardInitial card in cardList )
            //    disOrderList.Add (card.gameObject);
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


        //player回合开始时发牌.distribution:分配
        public IEnumerator Distribution ( )
        {
            if ( unused.childCount <= FixCounter )
                DisOrder ( );
            else
            {
                for ( int i = 0; i < FixCounter; i++ )
                {
                    yield return new WaitForSeconds (0.5f);
                    unused.GetChild (i).SetParent (inhand);
                }
            }

        }

        //选择技能
        public void ChooseSkill ( )
        {
            if ( skillCardArr [ 0 ] != null && skillCardArr [ 1 ] == null )
            {
                if ( skillCardArr [ 0 ].transform.parent == inhand )
                {
                    pos = skillCardArr [ 0 ].transform.position;
                    pos.y += offset;
                    skillCardArr [ 0 ].transform.position = pos;
                    Debug.LogFormat ("{0}被选择!" , skillCardArr [ 0 ].name);
                }
            }
            if ( skillCardArr [ 0 ] != null && skillCardArr [ 1 ] != null )
            {
                if ( skillCardArr [ 0 ] != skillCardArr [ 1 ] )
                {
                    if ( skillCardArr [ 1 ].transform.parent == inhand )
                    {
                        pos = skillCardArr [ 0 ].transform.position;
                        pos.y -= offset;
                        skillCardArr [ 0 ].transform.position = pos;
                        pos = skillCardArr [ 1 ].transform.position;
                        pos.y += offset;
                        skillCardArr [ 1 ].transform.position = pos;
                        skillCardArr [ 0 ] = skillCardArr [ 1 ];
                        skillCardArr [ 1 ] = null;
                    }
                }
                else
                {
                    Debug.LogFormat ("出牌:{0}!" , skillCardArr [ 1 ].name);
                    skillCardArr [ 1 ].transform.SetParent (used);
                    pos = skillCardArr [ 1 ].transform.position;
                    pos.x = -1000;
                    skillCardArr [ 0 ].transform.position = pos;
                    skillCardArr [ 0 ] = null;
                    skillCardArr [ 1 ] = null;
                }
            }

            //选择技能.废弃的方法,用数组代替列表
            //if ( skillCard.Count == 1 )
            //{
            //    if ( skillCard [ 0 ].CompareTag ("Card") && skillCard [ 0 ].transform.parent == inhand )
            //    {
            //        pos = skillCard [ 0 ].transform.position;
            //        pos.y += offset;
            //        skillCard [ 0 ].transform.position = pos;
            //        Debug.LogFormat ("{0}被点击!" , skillCard [ 0 ].name);
            //    }
            //}
            //else if( skillCard.Count == 2 )
            //{
            //    if ( skillCard [ 0 ] != skillCard [ 1 ] )
            //    {
            //        pos = skillCard [ 0 ].transform.position;
            //        pos.y -= offset;
            //        skillCard [ 0 ].transform.position = pos;
            //        if ( skillCard [ 1 ].CompareTag ("Card") && skillCard [ 1 ].transform.parent == inhand )
            //        {
            //            pos = skillCard [ 1 ].transform.position;
            //            pos.y += offset;
            //            skillCard [ 1 ].transform.position = pos;
            //            skillCard.RemoveAt (0);
            //        }
            //    }
            //}
        }



        //出牌
        public void UseCard ( )
        {

        }

    }

}
