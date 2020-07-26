﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//查找子节点: usedPanel.GetChild (i).gameObject; usedPanel是Transform类型
//不继承MonoBehaviour的脚本,不能直接实例化,销毁,调用协程

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
        public Transform popup = GameAsst._Inst.game.transform.Find ("UI_PopUp");

        //public List<GameObject> skillCard = new List<GameObject> ( );
        //public GameObject [ ] skillCardArr = new GameObject [ 2 ];

        public int FixCounter { set; get; } = 5;  ///每回合默认发牌张数
        public GameObject skillCard;
        private Vector3 pos;
        private readonly int offset = 30;
        public List<GameObject> tarsList = new List<GameObject> ( );    ///存放战中对象
        public List<GameObject> liveList = new List<GameObject> ( );    ///用于检查是否还有存活
        public int block;
        public UI_Battle uiBattle = GameAsst._Inst.game.transform.Find ("UI_Battle").GetComponent<UI_Battle> ( );



        ///洗牌
        public void DisOrder ( )
        {
            List<GameObject> disOrderList = new List<GameObject> ( );
            for ( int i = 0; i < used.childCount; i++ )
                disOrderList.Add (used.GetChild (i).gameObject);

            for ( int i = disOrderList.Count; i > 0; i-- )
            {
                int num = GameAsst._Rd.Next (0 , disOrderList.Count);
                disOrderList [ num ].transform.SetParent (unused);
                pos = disOrderList [ num ].transform.position;
                pos.x = 1000;
                pos.y = -400;
                disOrderList [ num ].transform.position = pos;
                disOrderList.RemoveAt (num);
            }

            //将子节点添加进list,已被usedPanel.GetChild (i).gameObject替代
            //List<CardInitial> cardList = new List<CardInitial> ( );
            //cardList.AddRange (usedPanel.gameObject.GetComponentsInChildren<CardInitial> ( ));
            //foreach ( CardInitial card in cardList )
            //    disOrderList.Add (card.gameObject);
        }

        ///player回合开始时发牌.distribution:分配
        public IEnumerator Distribution ( )
        {
            if ( unused.childCount < FixCounter )
                DisOrder ( );
            for ( int i = FixCounter - 1; i >= 0; i-- )
            {
                yield return new WaitForSeconds (0.2f);
                unused.GetChild (i).SetParent (inhand);
            }
        }

        ///选择技能卡.
        public void ChooseCard ( )
        {
            pos = skillCard.transform.position;
            pos.y += offset;
            skillCard.transform.position = pos;
            //Debug.LogFormat ("当前选择的技能卡:{0}!" , skillCard.name);
        }

        ///撤销技能卡.revoke,撤销
        public void RevokeCard ( )
        {
            pos = skillCard.transform.position;
            pos.y -= offset;
            skillCard.transform.position = pos;
        }

        ///出牌
        public void UseCard ( )
        {
            if ( GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).Mana >= skillCard.GetComponent<CardInitial> ( ).ManaCast )
            {
                for ( int i = 0; i < tarsList.Count; i++ )
                    skillCard.GetComponent<CardInitial> ( ).SkillResult (tarsList [ i ]);
            }
        }

        ///将卡牌移动到弃牌堆
        public void RemoveToUsed ( )
        {
            skillCard.transform.SetParent (used);
            pos = skillCard.transform.position;
            pos.x = -1000;
            pos.y = -400;
            skillCard.transform.position = pos;
            skillCard = null;
            tarsList.Clear ( );
        }

        ///每回合开始重置防御值和蓝量
        public void ResetBlockAndMana ( )
        {
            block = 0;
            GameAsst._Inst.player.transform.parent.parent.parent.Find ("Block/Text").GetComponent<Text> ( ).text = Convert.ToString (block);
            GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).Mana = GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).MaxMana;
            GameAsst._Inst.player.transform.parent.parent.parent.Find ("Mana/Text").GetComponent<Text> ( ).text =
                Convert.ToString (GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).MaxMana);
        }

        ///player回合结束,重置参数,并将剩余手牌移动到弃牌堆
        public void ClearHand ( )
        {
            skillCard = null;
            tarsList.Clear ( );
            ResetBlockAndMana ( );
            //block = 0;
            //GameAsst._Inst.player.transform.parent.parent.parent.Find ("Block/Text").GetComponent<Text> ( ).text = Convert.ToString (block);
            //GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).Mana =GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).MaxMana;
            //GameAsst._Inst.player.transform.parent.parent.parent.Find ("Mana/Text").GetComponent<Text> ( ).text =
            //    Convert.ToString (GameAsst._Inst.player.GetComponent<PlayerInitial> ( ).MaxMana);
            for ( int i = inhand.childCount - 1; i >= 0; i-- )
            {
                pos = inhand.GetChild (i).position;
                pos.x = -1000;
                inhand.GetChild (i).position = pos;
                inhand.GetChild (i).SetParent (used);
            }
            //Debug.Log ("剩余手牌移动到Used节点!!!");
        }

        ///当前关卡结束,清理牌堆
        public void ClearGlv ( )
        {
            skillCard = null;
            tarsList.Clear ( );
            for ( int i = inhand.childCount - 1; i >= 0; i-- )
            {
                pos = inhand.GetChild (i).position;
                pos.x = -1000;
                inhand.GetChild (i).position = pos;
                inhand.GetChild (i).SetParent (used);
            }
            for ( int i = unused.childCount - 1; i >= 0; i-- )
            {
                pos = unused.GetChild (i).position;
                pos.x = -1000;
                unused.GetChild (i).position = pos;
                unused.GetChild (i).SetParent (used);
            }
        }

        ///选择卡牌战利品
        public void SelectRewardCard ( )
        {
            GameAsst._Inst.game.transform.Find ("UI_PopUp").gameObject.SetActive (true);
            GameAsst._Inst.game.transform.Find ("UI_PopUp/Reward").gameObject.SetActive (true);
            UIMgr._Inst.btnJump = popup.Find ("Reward/Next").GetComponent<Button> ( );
            UIMgr._Inst.btnJump.onClick.AddListener (NextGlv);
            Transform parent = GameAsst._Inst.game.gameObject.transform.Find ("UI_PopUp/Reward/Select");
            GameObject card;
            int cardNum = 0;
            while ( cardNum != 3 )
            {
                int rd = GameAsst._Rd.Next (0 , uiBattle.cardPrefabArray.Length);
                card= uiBattle.BuildRewardCard (rd);
                card.transform.SetParent (parent);
                cardNum++;
            }

        }

        ///进入下一关卡
        public void NextGlv ( )
        {
            skillCard.tag = "Card";
            skillCard.transform.SetParent (used);
            skillCard.transform.position = new Vector3 (-1000 , -400 , uiBattle.transform.position.z);
            skillCard.transform.localScale = new Vector3 (1 , 1 , 1);
            skillCard = null;
            for ( int i = popup.Find ("Reward/Select").childCount - 1; i >= 0; i-- )
                uiBattle.DestroyCard (popup.Find ("Reward/Select").GetChild (i).gameObject);

            GameAsst._Inst.game.transform.Find ("UI_PopUp/Reward").gameObject.SetActive (false);
            GameAsst._Inst.game.transform.Find ("UI_PopUp").gameObject.SetActive (false);
            GameAsst._Inst.BuildGamelevle ( );
            ResetBlockAndMana ( );
            DisOrder ( );
            uiBattle.CallCoroutine ( );
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

        //选择技能.废弃的方法2,更改操作逻辑
        //当前方法实现的效果:同一张牌点击第一次,向上偏移;第二次点击,完成出牌;不能实现选择目标
        //public void ChooseSkill ( )
        //{
        //    if ( skillCardArr [ 0 ] != null && skillCardArr [ 1 ] == null )
        //    {
        //        if ( skillCardArr [ 0 ].transform.parent == inhand )
        //        {
        //            pos = skillCardArr [ 0 ].transform.position;
        //            pos.y += offset;
        //            skillCardArr [ 0 ].transform.position = pos;
        //            Debug.LogFormat ("{0}被选择!" , skillCardArr [ 0 ].name);
        //        }
        //    }
        //    if ( skillCardArr [ 0 ] != null && skillCardArr [ 1 ] != null )
        //    {
        //        if ( skillCardArr [ 0 ] != skillCardArr [ 1 ] )
        //        {
        //            if ( skillCardArr [ 1 ].transform.parent == inhand )
        //            {
        //                pos = skillCardArr [ 0 ].transform.position;
        //                pos.y -= offset;
        //                skillCardArr [ 0 ].transform.position = pos;
        //                pos = skillCardArr [ 1 ].transform.position;
        //                pos.y += offset;
        //                skillCardArr [ 1 ].transform.position = pos;
        //                skillCardArr [ 0 ] = skillCardArr [ 1 ];
        //                skillCardArr [ 1 ] = null;
        //            }
        //        }
        //        else
        //        {
        //            Debug.LogFormat ("出牌:{0}!" , skillCardArr [ 1 ].name);
        //            skillCardArr [ 1 ].transform.SetParent (used);
        //            pos = skillCardArr [ 1 ].transform.position;
        //            pos.x = -1000;
        //            skillCardArr [ 0 ].transform.position = pos;
        //            skillCardArr [ 0 ] = null;
        //            skillCardArr [ 1 ] = null;
        //        }
        //    }

        //    选择技能.废弃的方法1,用数组代替列表
        //            if ( skillcard.count == 1 )
        //    {
        //        if ( skillcard [ 0 ].comparetag ("card") && skillcard [ 0 ].transform.parent == inhand )
        //        {
        //            pos = skillcard [ 0 ].transform.position;
        //            pos.y += offset;
        //            skillcard [ 0 ].transform.position = pos;
        //            debug.logformat ("{0}被点击!" , skillcard [ 0 ].name);
        //        }
        //    }
        //    else if ( skillcard.count == 2 )
        //    {
        //        if ( skillcard [ 0 ] != skillcard [ 1 ] )
        //        {
        //            pos = skillcard [ 0 ].transform.position;
        //            pos.y -= offset;
        //            skillcard [ 0 ].transform.position = pos;
        //            if ( skillcard [ 1 ].comparetag ("card") && skillcard [ 1 ].transform.parent == inhand )
        //            {
        //                pos = skillcard [ 1 ].transform.position;
        //                pos.y += offset;
        //                skillcard [ 1 ].transform.position = pos;
        //                skillcard.removeat (0);
        //            }
        //        }
        //    }
        //}

    }

}
