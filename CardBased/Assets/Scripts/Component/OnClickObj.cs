using CardBased;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickObj : MonoBehaviour, IPointerClickHandler
{
    //Transform inhand;
    //Vector3 pos;
    //readonly int offset = 30;

    //public void Awake ( )
    //{
    //    inhand = GameAsst._Inst.game.transform.Find ("UI_Battle/Inhand").transform;
    //}

    public void OnPointerClick ( PointerEventData eventData )
    {
        if ( BattleMgr.Inst.skillCard [ 0 ] == null )
        {
            BattleMgr.Inst.skillCard [ 0 ] = eventData.pointerEnter;
            BattleMgr.Inst.ChooseSkill ( );
        }
        else
        {
            BattleMgr.Inst.skillCard [ 1 ] = eventData.pointerEnter;
            BattleMgr.Inst.ChooseSkill ( );
        }


    }


}
