using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CardBased_V1
{
    public class RoleBase : MonoBehaviour
    {
        //protected int id;
        //protected string name;

        public Dictionary<string , int> playerInfo = new Dictionary<string , int>
        {
            {"Sally",30},
            {"Brown",35},
            {"Coney",25},

        };

    }
}

