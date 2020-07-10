using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;

//用接口方法实现角色基类RoleBase

namespace CardBased
{
    interface IRoleBase
    {
        int Counter { set; get; }
        int Id { get; set; }
        string Name { get; set; }
        int MaxHp { get; set; }
        int Hp { get; set; }
        int Mana { get; set; }
        int Gold { get; set; }
        RoleType Roletype { get; set; }
        RoleStatus Rolestatus { get; set; }

        void Die ( );
        void UseSkill ( );

    }
}




