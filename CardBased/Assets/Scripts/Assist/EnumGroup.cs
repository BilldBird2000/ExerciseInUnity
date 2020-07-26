using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardBased
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
        Boss,
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

    //技能对象数量
    public enum SkillType
    {
        Single, //指定一个目标
        Multi,  //指定两个目标
        Random, //点选一个目标,得到随机个敌人(可以重复)
        All,    //点选一个目标,得到全部敌人
        None,
        Region,
    }

    //卡牌稀有度
    public enum CardRare
    {
        LvA,  //金卡
        LvB,  //蓝卡
        LvC,  //白卡
    }

    //卡牌等级
    public enum CardLevel
    {
        LvA,  //高级
        LvB,  //初级
    }

    public enum CardTarget
    {
        Player,
        Enemy,
    }


    //卡牌状态,操作父节点,枚举暂时不需要
    //public enum CardStatus
    //{
    //    Unused,     //抽牌堆中的牌
    //    Inhand,     //手牌
    //    Used,       //弃牌堆中的牌
    //}

    //当单张牌达到最大数量时,不能继续获得
    //可以用bool值字段,代替当前枚举
    //public enum CardObtain
    //{
    //    CanGet,
    //    CannotGet,
    //}
}
