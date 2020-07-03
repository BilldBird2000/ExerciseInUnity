using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardBased_V1
{
    interface IGamelvBase
    {
        int Id { set; get; }
        string Name { set; get; }
        bool NotPass { set; get; }
        GamelevelType Glvtype { set; get; }
        GamelevelStatus Glvstatus { set; get; }
        int NPCId { set; get; }
        int Enemy1Id { set; get; }
        int Enemy1Num { set; get; }
        int Enemy2Id { set; get; }
        int Enemy2Num { set; get; }
        int Enemy3Id { set; get; }
        int Enemy3Num { set; get; }
        int Enemy4Id { set; get; }
        int Enemy4Num { set; get; }
        int Enemy5Id { set; get; }
        int Enemy5Num { set; get; }

    }
}

