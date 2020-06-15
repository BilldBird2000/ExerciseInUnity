using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//新语法
//1.btnList.AddRange (transform.GetComponentsInChildren<Button> ( ));
//  List的属性.AddRange(),增加成员,参数有别于.Add()

//2.btnList [ i ].onClick.AddListener (delegate ( ) { OnClickAddBtn (sender.gameObject); });
//  onClick.AddListener(delegate ( ) { })添加委托参数,解决的问题是在点击时传递参数
//  delegate ( ) { OnClickAddBtn ( ); } 自定义OnClick函数使其能够传递参数
//  sender.gameObject组件,定位到当前节点. Component类默认包含了常用组件,可以用 .组件名 的方式访问

//3.非按钮UI资源,比如Image,可以被点击响应的实现方法:(以下3步缺一不可)
//  using UnityEngine.EventSysten;      //1-引用接口命名空间
//  public class ImageOnTouch:MonoBehaviour,IPointerClickHandlerq   //2-继承接口IPointerClickHeadler
//  {
//      public void OnPointerClick ( PointerEventData eventdata ) { }   //3-实现接口
//  }
//  


namespace CardBased_V1
{
    //UI_Login类的功能
    //sally,brown,coney三个按钮可点击状态,next不可点击状态
    //当sally,brown,coney其中任意一个被点击后,返回其id值作为实例化参数;next变成可点击状态
    //点击next后,初始化上一步中选中的对象;跳转到battle界面

    public class UI_Login : MonoBehaviour
    {
        private List<Button> btnList = new List<Button> ( );
        //public Transform [ ] target;
        private Button nextBtn;
        private GameObject player = null;

        void Start ( )
        {
            AddButton ( );

        }

        void Update ( )
        {

        }

        public void AddButton ( )
        {
            btnList.AddRange (transform.GetComponentsInChildren<Button> ( ));
            for ( int i = 0; i < btnList.Count; i++ )
            {
                Button sender = btnList [ i ];
                if ( sender.gameObject.name == "Next" )
                {
                    nextBtn = btnList [ i ];
                    nextBtn.interactable = false;
                    nextBtn.onClick.AddListener (OnNext);

                }
                else if ( sender.gameObject.name == "Null" )
                {
                    sender.interactable = true;
                    btnList [ i ].onClick.AddListener (OnNull);
                }
                else
                {
                    sender.interactable = true;
                    btnList [ i ].onClick.AddListener (delegate ( ) { OnPlayer (sender.gameObject); });
                }
            }

        }

        private void OnPlayer ( GameObject node )
        {
            Debug.LogFormat ("按钮{0}被点击" , node.name);
            player = node;
            nextBtn.interactable = true;

        }

        private void OnNull ( )
        {
            if ( player != null )
            {
                Debug.LogFormat ("撤销选择对象--------");
                player = null;
                nextBtn.interactable = false;
            }
        }

        private void OnNext ( )
        {
            Debug.LogFormat ("按钮{0}被点击~" , nextBtn.gameObject.name);

            PlayerInit init = player.AddComponent<PlayerInit> ( );
            init.Init (player);

            Debug.LogFormat ("即将跳转到战斗界面>>>>>>>>");

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
}

