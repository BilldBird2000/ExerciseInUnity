using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardBased;

//技能卡50005:伤害值等于player当前格挡值
public class Card50005 : IUniqueCard
{
    //[HideInInspector]
    private CardInitial card;

    public override bool Redefine ( )
    {
        card = transform.GetComponent<CardInitial> ( );
        int block = GameAsst.Inst.player.GetComponent<PlayerInitial> ( ).Block;
        card.Attack = block;
        return true;
    }



}
