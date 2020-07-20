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
            if ( BattleMgr.Inst.skillCardArr [ 0 ] == null )
            {
                BattleMgr.Inst.skillCardArr [ 0 ] = eventData.pointerEnter;
                BattleMgr.Inst.ChooseSkill ( );
            }
            else if ( BattleMgr.Inst.skillCardArr [ 0 ] != null )
            {
                BattleMgr.Inst.skillCardArr [ 1 ] = eventData.pointerEnter;
                BattleMgr.Inst.ChooseSkill ( );
            }
        }
        


    }


}
