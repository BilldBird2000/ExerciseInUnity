using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CardBased_V1
{
    public class TemplateDataReader
    {
        private static TemplateDataReader _tpReader = null;
        public static TemplateDataReader Inst
        {
            get
            {
                if ( _tpReader == null )
                    _tpReader = new TemplateDataReader ( );
                return _tpReader;
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
