using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardBased_V1;

/// <summary>
/// 
/// 
/// 
/// </summary>

public class Main : MonoBehaviour
{
    void Start ( )
    {
        CsvReader.Inst.LoadTable ( );


        //大大大写的错误!! game.Start ( )被调用了2次
        //GameAsst._Inst.game.Start ( );    

    }



}



