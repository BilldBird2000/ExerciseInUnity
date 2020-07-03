using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardBased_V1;

public class GamelvlInitial : MonoBehaviour, IGamelvBase
{
    public int Id { set; get; } = 0;
    public string Name { set; get; } = "";
    public bool NotPass { set; get; } = true;
    public GamelevelType Glvtype { set; get; } = GamelevelType.Battle;
    public GamelevelStatus Glvstatus { set; get; } = GamelevelStatus.Undone;
    public int NPCId { set; get; } = 0;
    public int Enemy1Id { set; get; } = 0;
    public int Enemy1Num { set; get; } = 0;
    public int Enemy2Id { set; get; } = 0;
    public int Enemy2Num { set; get; } = 0;
    public int Enemy3Id { set; get; } = 0;
    public int Enemy3Num { set; get; } = 0;
    public int Enemy4Id { set; get; } = 0;
    public int Enemy4Num { set; get; } = 0;
    public int Enemy5Id { set; get; } = 0;
    public int Enemy5Num { set; get; } = 0;

    public List<int> idList = new List<int> { 1001 , 1002 , 1003 , 2001 , 3001 , 4001 };

    void Start ( )
    {
        //Initial (1001);
    }

    public void Initial ( int index )
    {
        Dictionary<string , string> rowData = CsvReader.Inst.GetRowDict (GameAsst._Inst.gamelvDataPath , index);
        List<string> header = CsvReader.Inst.GetHeaderList (rowData);

        Id = index;
        Name = rowData [ header [ 1 ] ];





    }

    public void BuildEnemy ( )
    {

    }



}
