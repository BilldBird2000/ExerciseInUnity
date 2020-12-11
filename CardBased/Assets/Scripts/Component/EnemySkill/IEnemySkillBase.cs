using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardBased;
using System;

public class IEnemySkillBase : MonoBehaviour
{
    protected EnemyInitial enemyInst;
    protected Transform enemyRoot;
    protected PlayerInitial playerInst;
    protected Transform playerRoot;

    void Start ( )
    {
        enemyInst = GetComponent<EnemyInitial> ( );
        enemyRoot = transform.parent.parent.parent;
        playerInst = GameAsst.Inst.player.GetComponent<PlayerInitial> ( );
        playerRoot = GameAsst.Inst.player.transform.parent.parent.parent;

    }

    //敌方AI
    protected virtual void EnemyAI ( )
    {
        

    }

    //攻击:x点伤害
    protected virtual void Attack ( int atk )
    {
        float dmg = ( atk + enemyInst.Strength ) * ( 1 - enemyInst.Wounded ) * ( 1 + playerInst.Weak );
        int damage = Convert.ToInt32 (Math.Floor (dmg));
        dmg -= damage;
        if ( dmg > 0 )
            damage++;
        int playerHp = playerInst.Hp;
        playerHp -= damage;
        playerInst.Hp = playerHp;


    }

    //吸血:x点伤害+自身恢复x*50%点生命
    protected virtual void Blood ( int atk )
    {

    }

    //重伤攻击:易伤3回合+x点伤害
    protected virtual void WoundedAttack ( int atk )
    {

    }

    //感染攻击:虚弱3回合+x点伤害
    protected virtual void WeakAttack ( int atk )
    {

    }

    //破甲攻击:脆弱3回合+x点伤害
    protected virtual void FragileAttack ( int atk )
    {

    }

    //强化攻击:+2力量2回合+x点伤害
    protected virtual void StrengthAttack ( int atk )
    {

    }

    //疯狂攻击:连续攻击3次,每次伤害增加1点;首次首段伤害为x点
    protected virtual void CrazyAttack ( int atk )
    {

    }

    //治疗:恢复x点生命值;+释放条件
    protected virtual void Treatment ( int atk )
    {

    }

}


