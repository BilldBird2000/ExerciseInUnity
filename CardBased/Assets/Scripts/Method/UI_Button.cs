using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CardBased_V1
{
    public class UI_Button : MonoBehaviour
    {
        private Text btnName;
        private Button btn;
        private Text sallyName;
        private Button sally;
        private Text brownName;
        private Button brown;
        private Text coneyName;
        private Button coney;


        void Start ( )
        {
            AddBtn ( );

        }

        public void AddBtn ( )
        {
            btnName = transform.Find ("Button/name").GetComponent<Text> ( );
            btn = transform.Find ("Button").GetComponent<Button> ( );
            btn.onClick.AddListener (BtnOnClick);
            sallyName = transform.Find ("Sally/name").GetComponent<Text> ( );
            sally = transform.Find ("Sally").GetComponent<Button> ( );
            sally.onClick.AddListener (BtnOnClick);
            brownName = transform.Find ("Brown/name").GetComponent<Text> ( );
            brown = transform.Find ("Brown").GetComponent<Button> ( );
            brown.onClick.AddListener (BtnOnClick);
            coneyName = transform.Find ("Coney/name").GetComponent<Text> ( );
            coney = transform.Find ("Coney").GetComponent<Button> ( );
            coney.onClick.AddListener (BtnOnClick);
        }


        public void BtnOnClick ( )
        {
            string name = "Button/name";
            Debug.LogFormat ("{0}按钮被点击..." , MatchBtn (name));
        }

        public string MatchBtn ( string name )
        {
            string na = null;
            switch ( name )
            {
                case "Button/name":
                    na = btnName.text;
                    break;
                case "Sally/name":
                    na = sallyName.text;
                    break;
                case "Brown/name":
                    na = brownName.text;
                    break;
                case "Coney/name":
                    na = coneyName.text;
                    break;
            }
            return na;
        }



    }
}

