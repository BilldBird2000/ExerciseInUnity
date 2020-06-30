using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CardBased_V1
{
    public class Game
    {
        private static Game _game = null;
        public static Game Inst
        {
            get
            {
                if ( _game == null )
                    _game = new Game ( );
                return _game;
            }
        }

        public void Start()
        {
            UIMgr.Inst.CanvasJump ( );



        }
    }
}

