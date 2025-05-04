using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarManager
{
    public static bool isPromopted = false;
    public static float timeCost = 0;

    private static AStarManager instance;
    public static AStarManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AStarManager();
            }
            return instance;
        }
    }

    //��ͼ���
    private int width;
    private int height;

    //���������еĽڵ�
    public AStarNode[,] nodes;

    //�����б�
    public List<AStarNode> openList;

    //�ر��б�
    public List<AStarNode> closeList;

    //��ʼ����ͼ�Լ���Ա����
    public void InitializeFunc(int w, int h)
    {
        nodes = new AStarNode[w, h];
        openList = new List<AStarNode>();
        closeList = new List<AStarNode>();

        height = h;
        width = w;

        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                AStarNode node = new AStarNode(i, j, E_Node_Type.Walkable);
                nodes[i,j] = node;
            }
        }

        #region ��ʾ

        nodes[11, 6].nodeType = E_Node_Type.HighCost;
        nodes[11, 7].nodeType = E_Node_Type.HighCost;
        nodes[11, 8].nodeType = E_Node_Type.HighCost;
        nodes[11, 9].nodeType = E_Node_Type.HighCost;
        nodes[11, 10].nodeType = E_Node_Type.HighCost;

        nodes[12, 6].nodeType = E_Node_Type.HighCost;
        nodes[12, 7].nodeType = E_Node_Type.HighCost;
        nodes[12, 8].nodeType = E_Node_Type.HighCost;
        nodes[12, 9].nodeType = E_Node_Type.HighCost;
        nodes[12, 10].nodeType = E_Node_Type.HighCost;



        nodes[20, 28].nodeType = E_Node_Type.Unwalkable;
        nodes[5, 5].nodeType = E_Node_Type.Unwalkable;
        nodes[6, 5].nodeType = E_Node_Type.Unwalkable;
        nodes[7, 5].nodeType = E_Node_Type.Unwalkable;
        nodes[8, 5].nodeType = E_Node_Type.Unwalkable;
        nodes[9, 5].nodeType = E_Node_Type.Unwalkable;
        nodes[9, 6].nodeType = E_Node_Type.Unwalkable;
        nodes[9, 7].nodeType = E_Node_Type.Unwalkable;
        nodes[9, 8].nodeType = E_Node_Type.Unwalkable;
        nodes[9, 9].nodeType = E_Node_Type.Unwalkable;
        nodes[9, 10].nodeType = E_Node_Type.Unwalkable;
        nodes[9, 11].nodeType = E_Node_Type.Unwalkable;
        nodes[9, 12].nodeType = E_Node_Type.Unwalkable;
        nodes[8, 12].nodeType = E_Node_Type.Unwalkable;
        nodes[7, 12].nodeType = E_Node_Type.Unwalkable;
        nodes[6, 12].nodeType = E_Node_Type.Unwalkable;
        nodes[5, 12].nodeType = E_Node_Type.Unwalkable;
        //nodes[4, 12].nodeType = E_Node_Type.Unwalkable;
        //nodes[3, 12].nodeType = E_Node_Type.Unwalkable;

        nodes[25, 5].nodeType = E_Node_Type.Unwalkable;
        nodes[25, 6].nodeType = E_Node_Type.Unwalkable;
        nodes[25, 7].nodeType = E_Node_Type.Unwalkable;
        nodes[25, 8].nodeType = E_Node_Type.Unwalkable;
        nodes[25, 9].nodeType = E_Node_Type.Unwalkable;
        nodes[24, 9].nodeType = E_Node_Type.Unwalkable;
        nodes[23, 9].nodeType = E_Node_Type.Unwalkable;
        nodes[22, 9].nodeType = E_Node_Type.Unwalkable;
        nodes[21, 9].nodeType = E_Node_Type.Unwalkable;
        nodes[20, 9].nodeType = E_Node_Type.Unwalkable;
        nodes[20, 10].nodeType = E_Node_Type.Unwalkable;
        nodes[20, 11].nodeType = E_Node_Type.Unwalkable;
        nodes[20, 12].nodeType = E_Node_Type.Unwalkable;
        nodes[20, 13].nodeType = E_Node_Type.Unwalkable;
        nodes[20, 14].nodeType = E_Node_Type.Unwalkable;
        nodes[20, 15].nodeType = E_Node_Type.Unwalkable;
        nodes[20, 16].nodeType = E_Node_Type.Unwalkable;
        nodes[20, 17].nodeType = E_Node_Type.Unwalkable;
        nodes[19, 17].nodeType = E_Node_Type.Unwalkable;
        nodes[18, 17].nodeType = E_Node_Type.Unwalkable;
        nodes[17, 17].nodeType = E_Node_Type.Unwalkable;
        nodes[16, 17].nodeType = E_Node_Type.Unwalkable;
        nodes[15, 17].nodeType = E_Node_Type.Unwalkable;
        nodes[14, 17].nodeType = E_Node_Type.Unwalkable;
        nodes[13, 17].nodeType = E_Node_Type.Unwalkable;
        nodes[13, 18].nodeType = E_Node_Type.Unwalkable;
        nodes[13, 19].nodeType = E_Node_Type.Unwalkable;
        nodes[13, 20].nodeType = E_Node_Type.Unwalkable;
        nodes[13, 21].nodeType = E_Node_Type.Unwalkable;
        nodes[13, 22].nodeType = E_Node_Type.Unwalkable;
        nodes[13, 23].nodeType = E_Node_Type.Unwalkable;
        nodes[12, 23].nodeType = E_Node_Type.Unwalkable;
        nodes[11, 23].nodeType = E_Node_Type.Unwalkable;
        nodes[10, 23].nodeType = E_Node_Type.Unwalkable;
        nodes[9, 23].nodeType = E_Node_Type.Unwalkable;
        nodes[8, 23].nodeType = E_Node_Type.Unwalkable;
        nodes[7, 23].nodeType = E_Node_Type.Unwalkable;

        nodes[3, 19].nodeType = E_Node_Type.Unwalkable;
        nodes[4, 19].nodeType = E_Node_Type.Unwalkable;
        nodes[5, 19].nodeType = E_Node_Type.Unwalkable;
        nodes[6, 19].nodeType = E_Node_Type.Unwalkable;
        nodes[7, 19].nodeType = E_Node_Type.Unwalkable;
        nodes[8, 19].nodeType = E_Node_Type.Unwalkable;
        nodes[9, 19].nodeType = E_Node_Type.Unwalkable;

        nodes[3, 19].nodeType = E_Node_Type.Unwalkable;
        nodes[3, 20].nodeType = E_Node_Type.Unwalkable;
        nodes[3, 21].nodeType = E_Node_Type.Unwalkable;
        nodes[3, 22].nodeType = E_Node_Type.Unwalkable;
        nodes[3, 23].nodeType = E_Node_Type.Unwalkable;
        nodes[3, 24].nodeType = E_Node_Type.Unwalkable;
        nodes[3, 25].nodeType = E_Node_Type.Unwalkable;
        nodes[3, 26].nodeType = E_Node_Type.Unwalkable;
        nodes[3, 27].nodeType = E_Node_Type.Unwalkable;
        nodes[3, 28].nodeType = E_Node_Type.Unwalkable;
        nodes[4, 28].nodeType = E_Node_Type.Unwalkable;
        nodes[5, 28].nodeType = E_Node_Type.Unwalkable;
        nodes[6, 28].nodeType = E_Node_Type.Unwalkable;
        nodes[7, 28].nodeType = E_Node_Type.Unwalkable;
        nodes[8, 28].nodeType = E_Node_Type.Unwalkable;
        nodes[9, 28].nodeType = E_Node_Type.Unwalkable;

        nodes[13, 5].nodeType = E_Node_Type.Unwalkable;
        nodes[13, 6].nodeType = E_Node_Type.Unwalkable;
        nodes[13, 7].nodeType = E_Node_Type.Unwalkable;
        nodes[13, 8].nodeType = E_Node_Type.Unwalkable;
        nodes[13, 9].nodeType = E_Node_Type.Unwalkable;
        nodes[13, 10].nodeType = E_Node_Type.Unwalkable;
        nodes[13, 11].nodeType = E_Node_Type.Unwalkable;
        nodes[14, 11].nodeType = E_Node_Type.Unwalkable;
        nodes[15, 11].nodeType = E_Node_Type.Unwalkable;
        nodes[16, 11].nodeType = E_Node_Type.Unwalkable;
        nodes[17, 11].nodeType = E_Node_Type.Unwalkable;

        nodes[20, 21].nodeType = E_Node_Type.Unwalkable;
        nodes[21, 21].nodeType = E_Node_Type.Unwalkable;
        nodes[22, 21].nodeType = E_Node_Type.Unwalkable;
        nodes[23, 21].nodeType = E_Node_Type.Unwalkable;
        nodes[24, 21].nodeType = E_Node_Type.Unwalkable;
        nodes[25, 21].nodeType = E_Node_Type.Unwalkable;
        nodes[26, 21].nodeType = E_Node_Type.Unwalkable;
        nodes[27, 21].nodeType = E_Node_Type.Unwalkable;

        nodes[20, 21].nodeType = E_Node_Type.Unwalkable;
        nodes[20, 22].nodeType = E_Node_Type.Unwalkable;
        nodes[20, 23].nodeType = E_Node_Type.Unwalkable;
        nodes[20, 24].nodeType = E_Node_Type.Unwalkable;
        nodes[20, 25].nodeType = E_Node_Type.Unwalkable;
        nodes[20, 26].nodeType = E_Node_Type.Unwalkable;
        nodes[20, 27].nodeType = E_Node_Type.Unwalkable;


        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                switch(nodes[i,j].nodeType)
                {
                    case E_Node_Type.HighCost: nodes[i, j].gValueRatio = 5; break;
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Ѱ·����
    /// </summary>
    /// <param name="startPos"></param>
    /// <param name="endPos"></param>
    /// <returns></returns>
    public Stack<AStarNode> FindPath(Vector2 startPos, Vector2 endPos)
    {
        //�жϵ��Ƿ��ڵ�ͼ��
        if (startPos.x < 0 || startPos.x >= width ||
            startPos.y < 0 || startPos.y >= height || 
            endPos.x < 0 || endPos.x >= width || 
            endPos.y < 0 || endPos.y >= height)
        {
            Debug.Log("��ʼ������յ��ڿ�Ѱ·��Χ��");
            return null;
        }


        //������ʼ��Ŀ���
        AStarNode startNode = nodes[(int)startPos.x, (int)startPos.y];
        AStarNode endNode = nodes[(int)endPos.x, (int)endPos.y];

        //�ж��������
        if (startNode.nodeType == E_Node_Type.Unwalkable ||
            endNode.nodeType == E_Node_Type.Unwalkable)
        {
            Debug.Log("��ʼ������յ�Ϊ������������");
            return null;
        }


        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                nodes[i, j].isChecked = false;
            }
        }

        //�ڿ����µ�һ��Ѱ·ǰ��������б�
        closeList.Clear();
        openList.Clear();

        //������ʼ�����

        startNode.isChecked = true;
        startNode.fatherNode = null;
        startNode.fValue = 0;
        startNode.gValue = 0;
        startNode.hValue = 0;

        //����ʼ�����ر��б�
        closeList.Add(startNode);

        //����Ѱ·ѭ��
        while(true)
        { 
            //�����Χ���Ӳ�������Ҫ��ļ��뿪���б�
            CheckNearbyNode(startNode.x - 1, startNode.y - 1, 1.4f, startNode, endNode);
            CheckNearbyNode(startNode.x, startNode.y - 1, 1, startNode, endNode);
            CheckNearbyNode(startNode.x + 1, startNode.y - 1, 1.4f, startNode, endNode);
            CheckNearbyNode(startNode.x - 1, startNode.y, 1, startNode, endNode);
            CheckNearbyNode(startNode.x + 1, startNode.y, 1, startNode, endNode);
            CheckNearbyNode(startNode.x - 1, startNode.y + 1, 1.4f, startNode, endNode);
            CheckNearbyNode(startNode.x, startNode.y + 1, 1, startNode, endNode);
            CheckNearbyNode(startNode.x + 1, startNode.y + 1, 1.4f, startNode, endNode);

            //�������б�Ϊ�գ�֤�����еĽڵ㶼�Ѿ��������ǻ���û���ҵ�Ŀ��㣬������·
            if (openList.Count == 0)
            {
                Debug.Log("��·");
                return null;
            }

            #region �Ż�ǰ

            if(!isPromopted)
            {
                //Debug.Log("np");
                openList.Sort(SortNode);

                //�������б���fֵ��С�ļ���ر��б�
                closeList.Add(openList[0]);

                //����ǰ������Ϊ���fֵ��С�Ľڵ�
                startNode = openList[0];

                openList.RemoveAt(0);
            }



            #endregion


            #region �Ż���
            if(isPromopted)
            {
                openList.Sort(SortNode2);

                //�������б���fֵ��С�ļ���ر��б�
                closeList.Add(openList[openList.Count-1]);

                //����ǰ������Ϊ���fֵ��С�Ľڵ�
                startNode = openList[openList.Count - 1];

                openList.RemoveAt(openList.Count - 1);
            }


            #endregion
            //�����ǰ��ΪĿ���,����ջ�Ƚ���������ԣ���·������һ����ջ��������ջ
            if (startNode == endNode)
            {
                Stack<AStarNode> path = new Stack<AStarNode>();
                path.Push(endNode);
                while (endNode.fatherNode != null)
                {
                    //Debug.Log(endNode.x + "  " + endNode.y); 
                    path.Push(endNode.fatherNode);
                    endNode = endNode.fatherNode;
                }
                return path;
            }

        }
    }

    /// <summary>
    /// �Զ����������
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private int SortNode(AStarNode a, AStarNode b)
    {
        if (a.fValue >=b.fValue)
            return 1;
        else 
            return -1;
    }
    private int SortNode2(AStarNode a, AStarNode b)
    {
        if (a.fValue <= b.fValue)
            return 1;
        else
            return -1;
    }

    /// <summary>
    /// �Ե�ǰ����Χ�ĵ�����ж�
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="g"></param>
    /// <param name="fatherNode"></param>
    /// <param name="endNode"></param>
    private void CheckNearbyNode(int x, int y,float g, AStarNode fatherNode, AStarNode endNode)
    {

            //������ڵ�ͼ�ڣ�ֱ�ӷ���
            //Debug.Log(x + " " + y);
        if(isPromopted)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
                return;
            AStarNode aStarNode = nodes[x, y];

            //���Ϊ�ջ���Ϊ����������������ڿ����б���߹����б��ڶ�����
            if (aStarNode == null ||
                aStarNode.nodeType == E_Node_Type.Unwalkable)
                return;

            if (aStarNode.isChecked)
            {
                float temp = fatherNode.gValue + g;
                if (aStarNode.fatherNode == null)
                    return;

                if (aStarNode.fatherNode.x - x != 0 && aStarNode.fatherNode.y - y != 0)
                {
                    if (temp < aStarNode.fatherNode.gValue + 1.4f)
                    {
                        aStarNode.gValue = temp;
                        aStarNode.hValue = Mathf.Abs(endNode.x - aStarNode.x) + Mathf.Abs(endNode.y - aStarNode.y);
                        aStarNode.fValue = aStarNode.gValue + aStarNode.hValue;
                        aStarNode.fatherNode = fatherNode;
                    }
                }
                else
                {
                    if (temp < aStarNode.fatherNode.gValue + 1f)
                    {
                        aStarNode.gValue = temp;
                        aStarNode.hValue = Mathf.Abs(endNode.x - aStarNode.x) + Mathf.Abs(endNode.y - aStarNode.y);
                        aStarNode.fValue = aStarNode.gValue + aStarNode.hValue;
                        aStarNode.fatherNode = fatherNode;
                    }
                }
                return;
            }

            //����ǰ���ĵ�ĸ��ڵ���Ϊ��ǰ�����Ľڵ�
            aStarNode.fatherNode = fatherNode;

            //���ݸ��ڵ��ֵ����f��g��hֵ������isChecked��Ϊtrue
            aStarNode.gValue = fatherNode.gValue + g * aStarNode.gValueRatio;
            aStarNode.hValue = Mathf.Abs(endNode.x - aStarNode.x) + Mathf.Abs(endNode.y - aStarNode.y);
            aStarNode.fValue = aStarNode.gValue + aStarNode.hValue;
            aStarNode.isChecked = true;
            openList.Add(aStarNode);
        }


        if (!isPromopted)
        {
            //������ڵ�ͼ�ڣ�ֱ�ӷ���
            //Debug.Log(x + " " + y);
            if (x < 0 || x >= width || y < 0 || y >= height)
                return;
            AStarNode aStarNode = nodes[x, y];

            //���Ϊ�ջ���Ϊ����������������ڿ����б���߹����б��ڶ�����
            if (aStarNode == null ||
                aStarNode.nodeType == E_Node_Type.Unwalkable)
                return;

            if (openList.Contains( aStarNode)||closeList.Contains(aStarNode))
                {
                    //return;
                    float temp = fatherNode.gValue + g;
                    if (aStarNode.fatherNode == null)
                        return;

                    if (aStarNode.fatherNode.x - x != 0 && aStarNode.fatherNode.y - y != 0)
                    {
                        if (temp < aStarNode.fatherNode.gValue + 1.4f)
                        {
                            aStarNode.gValue = temp;
                            aStarNode.hValue = Mathf.Abs(endNode.x - aStarNode.x) + Mathf.Abs(endNode.y - aStarNode.y);
                            aStarNode.fValue = aStarNode.gValue + aStarNode.hValue;
                            aStarNode.fatherNode = fatherNode;
                        }
                    }
                    else
                    {
                        if (temp < aStarNode.fatherNode.gValue + 1f)
                        {
                            aStarNode.gValue = temp;
                            aStarNode.hValue = Mathf.Abs(endNode.x - aStarNode.x) + Mathf.Abs(endNode.y - aStarNode.y);
                            aStarNode.fValue = aStarNode.gValue + aStarNode.hValue;
                            aStarNode.fatherNode = fatherNode;
                        }
                    }
                    return;
                }

            //����ǰ���ĵ�ĸ��ڵ���Ϊ��ǰ�����Ľڵ�
            aStarNode.fatherNode = fatherNode;

            //���ݸ��ڵ��ֵ����f��g��hֵ������isChecked��Ϊtrue
            aStarNode.gValue = fatherNode.gValue + g * aStarNode.gValueRatio;
            aStarNode.hValue = Mathf.Abs(endNode.x - aStarNode.x) 
                               + Mathf.Abs(endNode.y - aStarNode.y);
            aStarNode.fValue = aStarNode.gValue + aStarNode.hValue;
            openList.Add(aStarNode);
        }

    }
}
