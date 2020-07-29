using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardBased
{
    interface ICardBase
    {
        ///CardTableV2
        int Id { set; get; }
        string Name { set; get; }
        CardTpye Cardtype { set; get; }
        SkillType Skilltype { set; get; }
        CardRare Cardrare { set; get; }
        CardLevel Cardlevel { set; get; }
        int ManaCast { set; get; }
        int MaxCounter { set; get; }
        int Attack { set; get; }
        int Block { set; get; }
        int Strength { set; get; }
        int Agility { set; get; }
        float Weak { set; get; }
        int WeakRnd { set; get; }
        float Fragile { set; get; }
        int FragileRnd { set; get; }
        float Wounded { set; get; }
        int WndRnd { set; get; }
        int Repeat { set; get; }
        int DrawNum { set; get; }
        int RandomTars { set; get; }
        bool WithScript { set; get; }




        //CardTableV1
        //CardTarget Cardtarget { set; get; }
        //int MaxCounter { set; get; }
        //int Id { set; get; }
        //string Name { set; get; }
        //CardTpye Cardtype { set; get; }
        //SkillType Skilltype { set; get; }
        //CardRare Cardrare { set; get; }
        //CardLevel Cardlevel { set; get; }
        //int ManaCast { set; get; }  //蓝耗
        //int Attack { set; get; }    //攻击力
        //float Strength { set; get; }  //力量buff,额外增加攻击力
        //int StrengthRnd { set; get; } //力量buff持续的回合数
        //float Weak { set; get; }  //虚弱buff,减少25%攻击力
        //int WeakRnd { set; get; } //虚弱buff持续的回合数
        //int Block { set; get; }     //格挡值
        //float Agility { set; get; }  //敏捷buff,额外增加格挡值
        //int AgilityRnd { set; get; } //敏捷buff持续的回合数
        //float Fragile { set; get; }  //脆弱buff;减少25%格挡值
        //int FragileRnd { set; get; } //脆弱buff持续的回合数
        //float Wounded { set; get; } //易伤buff,受到的伤害增加50%
        //int WndRnd { set; get; }    //易伤buff持续的回合数
        //int Poison { set; get; }    //中毒buff,额外受到伤害,在敌人行动结束后产生效果
        //int PsnRnd { set; get; }    //中毒buff持续的回合数




    }
}

