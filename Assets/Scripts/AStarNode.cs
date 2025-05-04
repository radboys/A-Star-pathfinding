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
    

    //Ѱ·������
    public float fValue;

    //������������
    public float gValue;

    //�����յ������
    public float hValue;

    public float gValueRatio = 1;

    //���ڵ�
    public AStarNode fatherNode;

    //��������
    public int x;
    public int y;

    //��������
    public E_Node_Type nodeType;

    //�Ƿ��Ѿ�����
    public bool isChecked;

    public AStarNode(int x, int y,E_Node_Type type)
    {
        this.x = x;
        this.y = y;
        this.nodeType = type;
        isChecked = false;

    }
}
