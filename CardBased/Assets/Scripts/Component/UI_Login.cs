﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardBased;

//新语法
//1.btnList.AddRange (transform.GetComponentsInChildren<Button> ( ));
//  List的属性.AddRange(),增加成员,参数有别于.Add()

//2.btnList [ i ].onClick.AddListener (delegate ( ) { OnClickAddBtn (sender.gameObject); });
//  onClick.AddListener(delegate ( ) { })添加委托参数,解决的问题是在点击时传递参数
//  delegate ( ) { OnClickAddBtn ( ); } 自定义OnClick函数使其能够传递参数
//  sender.gameObject组件,定位到当前节点. Component类默认包含了常用组件,可以用 .组件名 的方式访问

//3.非按钮UI资源,比如Image,可以被点击响应的实现方法:(以下3步缺一不可)
//  using UnityEngine.EventSysten;      //1-引用接口命名空间
//  public class ImageOnTouch:MonoBehaviour,IPointerClickHandler        //2-继承接口IPointerClickHeadler
//  {
//      public void OnPointerClick ( PointerEventData eventdata ) { }   //3-实现接口
//  }
//  

//UI_Login类的功能
//sally,brown,coney三个按钮可点击状态,next不可点击状态
//当sally,brown,coney其中任意一个被点击后,返回其id值作为实例化参数;next变成可点击状态
//点击next后,初始化上一步中选中的对象;跳转到battle界面

public class UI_Login : MonoBehaviour
{
    void Start ( )
    {
        AddButton ( );
    }

    ///给当前界面的按钮统一增加点击事件
    public void AddButton ( )
    {
        UIMgr.Inst.btnList.AddRange (transform.GetComponentsInChildren<Button> ( ));
        for ( int i = 0; i < UIMgr.Inst.btnList.Count; i++ )
        {
            Button sender = UIMgr.Inst.btnList [ i ];
            if ( sender.gameObject.name == "Next" )
            {
                UIMgr.Inst.btnJump = UIMgr.Inst.btnList [ i ];
                UIMgr.Inst.btnJump.interactable = false;
                UIMgr.Inst.btnJump.onClick.AddListener (OnNext);

            }
            else if ( sender.gameObject.name == "Blank" )
            {
                sender.interactable = true;
                UIMgr.Inst.btnList [ i ].onClick.AddListener (OnBlank);
            }
            else
            {
                sender.interactable = true;
                UIMgr.Inst.btnList [ i ].onClick.AddListener (delegate ( ) { OnPlayer (sender.gameObject); });
            }
        }

    }

    ///点击角色
    private void OnPlayer ( GameObject plr )
    {
        //Debug.LogFormat ("按钮{0}被点击" , plr.name);
        GameAsst.Inst.player = plr;
        UIMgr.Inst.btnJump.interactable = true;

    }

    ///点击空白区域,用于撤销
    private void OnBlank ( )
    {
        if ( GameAsst.Inst.player != null )
        {
            //Debug.LogFormat ("撤销选择对象--------");
            GameAsst.Inst.player = null;
            UIMgr.Inst.btnJump.interactable = false;
        }
    }

    ///点击跳转按钮
    private void OnNext ( )
    {
        //Debug.LogFormat ("按钮{0}被点击~" , UIMgr._Inst.btnJump.gameObject.name);
        GameObject.Find ("Launch").transform.Find ("UI_Login").gameObject.SetActive (false);
        UIMgr.Inst.JumpToUIBattle ( );

    }



    //添加点击事件的一种方法,被AddButton()代替
    //用onClick.AddListener()添加的方法不能传参,不方便处理多个按钮事件,局限性比较大
    //private Text btnName;
    //private Button btn;
    //private Text sallyName;
    //private Button sally;
    //private Text brownName;
    //private Button brown;
    //private Text coneyName;
    //private Button coney;

    //public void AddBtn ( )
    //{
    //    btnName = transform.Find ("Button/name").GetComponent<Text> ( );
    //    btn = transform.Find ("Button").GetComponent<Button> ( );
    //    btn.onClick.AddListener (BtnOnClick);
    //}
    //public void BtnOnClick ( )
    //{
    //    Debug.LogFormat ("{0}按钮被点击..." , btnName.text);
    //}




}


