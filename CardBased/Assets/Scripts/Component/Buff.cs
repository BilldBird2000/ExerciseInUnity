using CardBased;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buff : MonoBehaviour
{
    public GameObject BuffImagePrdfab;

    public void AddBuff (string name, Sprite icon , int rnd )
    {
        Transform buffGroup = transform.Find ("BuffGroup");
        GameObject buff = Instantiate (BuffImagePrdfab , buffGroup);
        buff.name = name;
        buff.GetComponent<Image> ( ).sprite = icon;
        buff.transform.GetChild (0).GetComponent<Text> ( ).text = Convert.ToString (rnd);
    }

    public void UpDateBuff ( string name , int rnd )
    {
        string path = "BuffGroup" + "/" + name;
        Transform buff = transform.Find (path);
        if ( rnd > 0 )
            buff.GetChild (0).GetComponent<Text> ( ).text = Convert.ToString (rnd);
        else
            Destroy (buff.gameObject);
    }

    public void UpDateBuff ( Transform buff )
    {
        Destroy (buff.gameObject);
    }


}
