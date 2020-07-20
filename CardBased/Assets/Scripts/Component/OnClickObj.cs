using CardBased;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickObj : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick ( PointerEventData eventData )
    {
        if ( eventData.pointerEnter.CompareTag ("Card") )
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
        else if ( eventData.pointerEnter.CompareTag ("Enemy") )
        {
            if ( BattleMgr.Inst.skillCard != null )
            {
                BattleMgr.Inst.tarsList.Add (eventData.pointerEnter);
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
