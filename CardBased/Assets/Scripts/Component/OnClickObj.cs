using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using CardBased;

public class OnClickObj : MonoBehaviour, IPointerClickHandler
{
    //private List<GameObject> tempList = new List<GameObject> ( );
    private List<EnemyInitial> tempList = new List<EnemyInitial> ( );
    public void OnPointerClick ( PointerEventData eventData )
    {
        if ( eventData.pointerEnter.CompareTag ("Card") && eventData.pointerEnter.transform.parent == BattleMgr.Inst.inhand )
        {
            if ( BattleMgr.Inst.skillCard == null )
            {
                BattleMgr.Inst.skillCard = eventData.pointerEnter;
                BattleMgr.Inst.ChooseCard ( );
            }
            else
            {
                BattleMgr.Inst.RevokeCard ( );
                BattleMgr.Inst.skillCard = eventData.pointerEnter;
                BattleMgr.Inst.ChooseCard ( );
            }
        }
        if ( eventData.pointerEnter.CompareTag ("Card") &&
            eventData.pointerEnter.transform.parent == GameAsst._Inst.game.transform.Find ("UI_PopUp/Reward/Select") )
        {
            if ( BattleMgr.Inst.skillCard == null )
            {
                BattleMgr.Inst.skillCard = eventData.pointerEnter;
                BattleMgr.Inst.ChooseCard ( );
            }
            else
            {
                BattleMgr.Inst.RevokeCard ( );
                BattleMgr.Inst.skillCard = eventData.pointerEnter;
                BattleMgr.Inst.ChooseCard ( );
            }
        }

        else if ( eventData.pointerEnter.CompareTag ("Enemy") || eventData.pointerEnter.CompareTag ("Player") )
        {
            if ( BattleMgr.Inst.skillCard != null )
            {
                if ( BattleMgr.Inst.skillCard.GetComponent<CardInitial> ( ).Skilltype == SkillType.Single )
                    BattleMgr.Inst.tarsList.Add (eventData.pointerEnter);
                else if ( BattleMgr.Inst.skillCard.GetComponent<CardInitial> ( ).Skilltype == SkillType.All )
                {
                    tempList.AddRange (GameAsst._Inst.game.transform.Find ("UI_RoleInform").GetComponentsInChildren<EnemyInitial> ( ));
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
