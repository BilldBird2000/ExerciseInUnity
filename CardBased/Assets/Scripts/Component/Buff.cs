using CardBased;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buff : MonoBehaviour
{
    public GameObject BuffImagePrefab;

    public void AddBuff (string name, Sprite icon , int rnd )
    {
        Transform buffGroup = transform.Find ("BuffGroup");
        GameObject buff = Instantiate (BuffImagePrefab , buffGroup);
        buff.name = name;
        buff.GetComponent<Image> ( ).sprite = icon;
        buff.transform.GetChild (0).GetComponent<Text> ( ).text = Convert.ToString (rnd);
    }

    ///更新Strength,Agility类型的buff
    public void UpDateBuff ( Transform buff )
    {
        Destroy (buff.gameObject);
    }

    ///更新Weak,Fragile,Wounded类型的buff
    public void UpDateBuff ( string name , int rnd )
    {
        string path = "BuffGroup" + "/" + name;
        Transform buff = transform.Find (path);
        buff.GetChild (0).GetComponent<Text> ( ).text = Convert.ToString (rnd);
    }

    

    public void ClearBuff ( )
    {
        Transform buffGroup = transform.Find ("BuffGroup");
        for ( int i = buffGroup.childCount - 1; i >= 0; i-- )
            Destroy (buffGroup.GetChild (i));
    }


}
