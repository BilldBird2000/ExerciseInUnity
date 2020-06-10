using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <CardBased_V1.0>
/// 1.UnityUI基础
/// 2.将控制台输入移植到UnityUI文本输入
/// 3.点击响应
/// 4.重新搭建代码逻辑,去除原有战斗逻辑中的while循环结构
/// 5.实现简单战斗
/// 6.新增界面管理器
/// 
/// </summary>

namespace CardBased_V1
{
    /// <summary>
    /// 1.运行-加载表
    /// 2.角色选择界面-选择并初始化角色
    /// 2.跳转到战斗界面
    /// </summary>

    public class Main : MonoBehaviour
    {



        void Start ( )
        {
            TemplateDataReader.Ins.LoadTable ( );
            Game.Ins.Start ( );

            //Debug.Log ("Only for test...");

        }



        void Update ( )
        {

        }
    }

}

