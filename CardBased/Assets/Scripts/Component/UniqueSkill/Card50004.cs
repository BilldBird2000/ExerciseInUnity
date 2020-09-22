using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardBased;

//技能卡50004: 当手牌全部是攻击类型的牌时,可以使用当前卡牌
public class Card50004 : IUniqueCard
{
    public override bool Redefine ( )
    {
        Transform inhand = GameAsst.Inst.launch.transform.Find ("UI_Battle/Inhand");
        bool canUseSkill = true;
        for ( int i = 0; i < inhand.childCount; i++ )
        {
            if ( inhand.GetChild (i).GetComponent<CardInitial> ( ).Cardtype != CardTpye.Attack )
            {
                canUseSkill = false;
                break;
            }

        }
        return canUseSkill;
    }


}
