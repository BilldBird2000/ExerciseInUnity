using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardBased
{
    interface ICardBase
    {
        int Id { set; get; }
        string Name { set; get; }
        CardTpye Cardtype { set; get; }
        CardStatus Cardstatus { set; get; }
        CardRare Cardrare { set; get; }
        CardLevel Cardlevel { set; get; }
        int ManaCast { set; get; }
        int Attack { set; get; }
        float AtkAdd { set; get; }
        int AtkAddRnd { set; get; }
        float AtkRdc { set; get; }
        int AtkRdcRnd { set; get; }
        int Block { set; get; }
        float BlcAdd { set; get; }
        int BlcAddRnd { set; get; }
        float BlcRdc { set; get; }
        int BlcRdcRnd { set; get; }
        float Wounded { set; get; }
        int WndRnd { set; get; }
        int Poison { set; get; }
        int PsnRnd { set; get; }




    }
}

