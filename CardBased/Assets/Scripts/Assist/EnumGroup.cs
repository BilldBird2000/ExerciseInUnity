using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardBased_V1
{
    public enum RoleType
    {
        Player,
        Enemy,
        Summon,
        NPC,
        None,
    }

    public enum RoleStatus
    {
        Alive,
        Dead,
        Controlled,
        None,
    }

    //关卡类型
    public enum GamelevelType
    {
        Battle,
        Room,
        Shop,
        Boos,
    }

    //关卡状态
    public enum GamelevelStatus
    {
        Done,
        Undone,
    }

    //卡牌类型
    public enum CardTpye
    {
        Attack,     //攻击牌
        Skill,      //技能牌
        Ability,    //能力牌
        Colorless,  //无色牌
        Curse,      //诅咒牌=状态牌:不能被打出,战斗结束时被移除
        //Negative,
    }

    //卡牌稀有度
    public enum CardRare
    {
        A,  //金卡
        B,  //蓝卡
        C,  //白卡
    }

    //卡牌等级
    public enum CardLevel
    {
        A,  //高级
        B,  //初级
    }

    public enum SkillType
    {
        Single,
        Multi,
        All,
        None,
        Region,
    }
}
