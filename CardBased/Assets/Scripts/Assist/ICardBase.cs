using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardBased
{
    interface ICardBase
    {
        CardTarget Cardtarget { set; get; }
        int MaxCounter { set; get; }
        int Id { set; get; }
        string Name { set; get; }
        CardTpye Cardtype { set; get; }
        SkillType Skilltype { set; get; }
        CardRare Cardrare { set; get; }
        CardLevel Cardlevel { set; get; }
        int ManaCast { set; get; }  //蓝耗
        int Attack { set; get; }    //攻击力
        float AtkAdd { set; get; }  //力量buff,额外增加攻击力
        int AtkAddRnd { set; get; } //力量buff持续的回合数
        float AtkRdc { set; get; }  //虚弱buff,减少25%攻击力
        int AtkRdcRnd { set; get; } //虚弱buff持续的回合数
        int Block { set; get; }     //格挡值
        float BlcAdd { set; get; }  //敏捷buff,额外增加格挡值
        int BlcAddRnd { set; get; } //敏捷buff持续的回合数
        float BlcRdc { set; get; }  //脆弱buff;减少25%格挡值
        int BlcRdcRnd { set; get; } //脆弱buff持续的回合数
        float Wounded { set; get; } //易伤buff,受到的伤害增加50%
        int WndRnd { set; get; }    //易伤buff持续的回合数


        int Poison { set; get; }    //中毒buff,额外受到伤害,在敌人行动结束后产生效果
        int PsnRnd { set; get; }    //中毒buff持续的回合数




    }
}

