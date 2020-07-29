using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using CardBased;

public class OnClickObj : MonoBehaviour, IPointerClickHandler
{
    private List<EnemyInitial> tempList = new List<EnemyInitial> ( );
    public void OnPointerClick ( PointerEventData eventData )
    {
        if ( eventData.pointerEnter.CompareTag ("Card") )
        {
            if ( BattleMgr.Inst.skillCard == null )
            {
                BattleMgr.Inst.skillCard = eventData.pointerEnter.transform.parent.gameObject;
                //BattleMgr.Inst.skillCard = eventData.pointerEnter;
                BattleMgr.Inst.ChooseCard ( );
            }
            else
            {
                BattleMgr.Inst.RevokeCard ( );
                BattleMgr.Inst.skillCard = eventData.pointerEnter.transform.parent.gameObject;
                //BattleMgr.Inst.skillCard = eventData.pointerEnter;
                BattleMgr.Inst.ChooseCard ( );
            }
        }
        else if ( eventData.pointerEnter.CompareTag ("Reward") )
        {
            if ( BattleMgr.Inst.skillCard == null )
            {
                BattleMgr.Inst.skillCard = eventData.pointerEnter.transform.parent.gameObject;
                eventData.pointerEnter.transform.parent.localScale = new Vector3 (1.2f , 1.2f , 1);
            }
            else
            {
                BattleMgr.Inst.skillCard.transform.localScale = new Vector3 (1 , 1 , 1);
                BattleMgr.Inst.skillCard = eventData.pointerEnter.transform.parent.gameObject;
                eventData.pointerEnter.transform.parent.localScale = new Vector3 (1.2f , 1.2f , 1);
            }
        }

        else if ( eventData.pointerEnter.CompareTag ("Enemy") )
        {
            if ( BattleMgr.Inst.skillCard != null )
            {
                if ( BattleMgr.Inst.skillCard.GetComponent<CardInitial> ( ).Skilltype == SkillType.Single )
                    BattleMgr.Inst.tarsList.Add (eventData.pointerEnter);
                else if ( BattleMgr.Inst.skillCard.GetComponent<CardInitial> ( ).Skilltype == SkillType.All )
                {
                    tempList.AddRange (GameAsst.Inst.launch.transform.Find ("UI_RoleInform").GetComponentsInChildren<EnemyInitial> ( ));
                    for ( int i = 0; i < tempList.Count; i++ )
                        BattleMgr.Inst.tarsList.Add (tempList [ i ].gameObject);
                    tempList.Clear ( );
                }
                else if ( BattleMgr.Inst.skillCard.GetComponent<CardInitial> ( ).Skilltype == SkillType.Random )
                {

                }
                BattleMgr.Inst.UseCard ( );
            }
        }
        else if ( eventData.pointerEnter.CompareTag ("Player") )
        {

            if ( BattleMgr.Inst.skillCard != null )
            {
                if ( BattleMgr.Inst.skillCard.GetComponent<CardInitial> ( ).Cardtarget == CardTarget.Player )
                {
                    if ( BattleMgr.Inst.skillCard.GetComponent<CardInitial> ( ).Skilltype == SkillType.Single )
                        BattleMgr.Inst.tarsList.Add (eventData.pointerEnter);
                    else if ( BattleMgr.Inst.skillCard.GetComponent<CardInitial> ( ).Skilltype == SkillType.All )
                    {
                        tempList.AddRange (GameAsst.Inst.launch.transform.Find ("UI_RoleInform").GetComponentsInChildren<EnemyInitial> ( ));
                        for ( int i = 0; i < tempList.Count; i++ )
                            BattleMgr.Inst.tarsList.Add (tempList [ i ].gameObject);
                        tempList.Clear ( );
                    }
                    else if ( BattleMgr.Inst.skillCard.GetComponent<CardInitial> ( ).Skilltype == SkillType.Random )
                    {

                    }
                    BattleMgr.Inst.UseCard ( );
                }
            }

        }


    }


    //废弃的方法,逻辑更改
    //当前方法可以实现:点击两次同一张牌后立刻出牌
    //public void OnPointerClick ( PointerEventData eventData )
    //{
    //    if ( eventData.pointerEnter.CompareTag ("Card") )
    //    {
    //        if ( BattleMgr.Inst.skillCardArr [ 0 ] == null )
    //        {
    //            BattleMgr.Inst.skillCardArr [ 0 ] = eventData.pointerEnter;
    //            BattleMgr.Inst.ChooseSkill ( );
    //        }
    //        else if ( BattleMgr.Inst.skillCardArr [ 0 ] != null )
    //        {
    //            BattleMgr.Inst.skillCardArr [ 1 ] = eventData.pointerEnter;
    //            BattleMgr.Inst.ChooseSkill ( );
    //        }
    //    }
    //}


}
