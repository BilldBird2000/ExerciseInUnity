using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//tableDict,rowDict,headerList实例化比控制台要早,注意区别

namespace CardBased
{
    public class CsvReader
    {
        private static CsvReader _tpReader = null;
        public static CsvReader Inst
        {
            get
            {
                if ( _tpReader == null )
                    _tpReader = new CsvReader ( );
                return _tpReader;
            }
        }

        private readonly char [ ] separator = new char [ ] { ',' };
        private Dictionary<string , Dictionary<int , Dictionary<string , string>>> superDict;

        public void LoadTable ( )
        {
            superDict = new Dictionary<string , Dictionary<int , Dictionary<string , string>>> ( );
            ReadTable (GameAsst._Inst.playerDataPath);
            ReadTable (GameAsst._Inst.enemyDataPath);
            ReadTable (GameAsst._Inst.gamelvDataPath);
            Debug.Log ("LoadTable...");
        }

        public void ReadTable ( string path )
        {
            Dictionary<int , Dictionary<string , string>> tableDict = new Dictionary<int , Dictionary<string , string>> ( );
            Dictionary<string , string> rowDict;
            List<string> headerList;

            try
            {
                FileStream open = new FileStream (path , FileMode.Open);
                StreamReader reader = new StreamReader (open);

                //tableDict = new Dictionary<int , Dictionary<string , string>> ( );
                int lineNum = 0;
                string lineData = null;
                headerList = new List<string> ( );
                while ( ( lineData = reader.ReadLine ( ) ) != null )
                {
                    if ( lineNum == 0 )
                    {
                        string [ ] headArr = lineData.Split (separator);
                        for ( int i = 0; i < headArr.Length; i++ )
                            headerList.Add (headArr [ i ]);
                    }
                    else
                    {
                        string [ ] dataArr = lineData.Split (separator);
                        if ( dataArr == null )
                            continue;
                        else
                        {
                            int index = Convert.ToInt32 (dataArr [ 0 ]);
                            rowDict = new Dictionary<string , string> ( );
                            tableDict.Add (index , rowDict);
                            for ( int i = 0; i < dataArr.Length; i++ )
                                rowDict.Add (headerList [ i ] , dataArr [ i ]);

                        }
                    }
                    lineNum++;
                    //Debug.LogFormat ("成功获得第{0}行数据~~~" , lineNum);
                }
            }
            catch
            {
                Debug.Log ("读表失败...");
            }

            superDict.Add (path , tableDict);
        }

        public Dictionary<string , string> GetRowDict ( string path , int index )
        {
            _ = new Dictionary<string , string> ( );
            Dictionary<string , string> rowDict = superDict [ path ] [ index ];
            return rowDict;
        }

        public List<string> GetHeaderList ( Dictionary<string , string> rowDict )
        {
            List<string> headerList = new List<string> ( );
            foreach ( string key in rowDict.Keys )
                headerList.Add (key);
            return headerList;
        }


    }

}
