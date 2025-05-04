using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class Node
{
    public Node fatherNode;
}
public enum E_Node_Type
{
    Walkable,
    Unwalkable,
    HighCost
}
public class AStarNode
{
    // Start is called before the first frame update
    

    //寻路总消耗
    public float fValue;

    //距离起点的消耗
    public float gValue;

    //距离终点的消耗
    public float hValue;

    public float gValueRatio = 1;

    //父节点
    public AStarNode fatherNode;

    //格子坐标
    public int x;
    public int y;

    //格子类型
    public E_Node_Type nodeType;

    //是否已经检查过
    public bool isChecked;

    public AStarNode(int x, int y,E_Node_Type type)
    {
        this.x = x;
        this.y = y;
        this.nodeType = type;
        isChecked = false;

    }
}
