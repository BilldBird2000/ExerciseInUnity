using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CardBased_V1
{
    public class TemplateDataReader
    {
        private static TemplateDataReader _tpRearer = null;
        public static TemplateDataReader Ins
        {
            get
            {
                if ( _tpRearer == null )
                    _tpRearer = new TemplateDataReader ( );
                return _tpRearer;
            }
        }

        private readonly char [ ] separator = new char [ ] { ',' };
        private Dictionary<string , Dictionary<int , Dictionary<string , string>>> superDict;

        public void LoadTable ( )
        {
            Debug.Log ("LoadTable...");

        }


    }

}
