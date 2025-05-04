using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AstarTest : MonoBehaviour
{
    public Text time;
    public Text nodeCount;
    public Text costTotal;



    // Start is called before the first frame update
    //��ͼ�����ϽǸ��ӵ�λ������
    public int beginX = -3;
    public int beginY = 5;

    //ÿ���ڵ�ֱ�ӵķ�϶
    public float offestX;
    public float offestY;

    //������ͼ�Ŀ�ߣ����Ը����Լ���Ҫ�Ĵ�С������
    public int mapWidth;
    public int mapHeight;

    //�ò�ͬ��ɫ�Ĳ�������ʾ��ͬ�Ľڵ�
    public Material redMaterial;
    public Material greenMaterial;
    public Material yellowMaterial;
    public Material whiteMaterial;
    public Material grayMaterial;
    public Material lowGrayMaterial;

    public static Material wide;

    //���нڵ���ֵ�
    public static Dictionary<string,GameObject> map = new Dictionary<string,GameObject>();

    //����������ʼ�㲢������һ��Ĭ��ֵ��Ϊ�����ж�����
    private Vector2 startPoint = Vector2.right * -1;

    //���Ǵ�A*�㷨�л�ȡ�������·��
    private List<AStarNode> path;

    private Stack<AStarNode> pathStack;




    /// <summary>
    /// ��ʼ�����Խű�
    /// </summary>
    /// 
    private void Awake()
    {

    }
    void Start()
    {
        wide = yellowMaterial;
        AStarManager.Instance.InitializeFunc(mapWidth,mapHeight);


        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obj.transform.position = new Vector3(beginX + i * offestX, beginY + j * offestY, 0);
                obj.name = i + "_" + j;
                map.Add(obj.name, obj);
                AStarNode node = AStarManager.Instance.nodes[i, j];
                if(node.nodeType == E_Node_Type.Unwalkable)
                {
                    obj.GetComponent<MeshRenderer>().material = redMaterial;
                }
                if(node.nodeType == E_Node_Type.HighCost)
                {
                    //obj.GetComponent<MeshRenderer>().material = grayMaterial;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            nodeCount.text = "0";
            time.text = "�ȴ�Ѱ·";
            costTotal.text = "0";
            RaycastHit info;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out info,1000))
            {

                if (path != null)
                {
                    for (int i = 0; i < path.Count; i++)
                    {
                        map[path[i].x + "_" + path[i].y].GetComponent<MeshRenderer>().material = whiteMaterial;
                    }
                }

                if (startPoint == Vector2.right * -1)
                {
                    string[] strings = info.collider.name.Split('_');
                    startPoint = new Vector2(int.Parse(strings[0]), int.Parse(strings[1]));
                    info.collider.gameObject.GetComponent<MeshRenderer>().material = yellowMaterial;
                }
                else
                {
                    string[] strings = info.collider.name.Split('_');
                    Vector2 endPoint = new Vector2(int.Parse(strings[0]), int.Parse(strings[1]));
                    var before = System.DateTime.Now.Millisecond;
                    var tempTime = Time.time;
                    path = new List<AStarNode>(AStarManager.Instance.FindPath(startPoint, endPoint));

                    float temp = 0;
                    //foreach(var item in AStarManager.Instance.openList)
                    //{
                    //    map[item.x + "_" + item.y].GetComponent<MeshRenderer>().material = grayMaterial;
                    //}
                    //foreach(var item in AStarManager.Instance.closeList)
                    //{
                    //    map[item.x + "_" + item.y].GetComponent<MeshRenderer>().material = grayMaterial;
                    //}
                    if(path != null)
                    {
                        for (int i = 0; i < path.Count; i++)
                        {
                            map[path[i].x + "_" + path[i].y].GetComponent<MeshRenderer>().material = greenMaterial;
                            temp += path[i].fValue;
                        }
                    }
                    nodeCount.text = path.Count.ToString();
                    costTotal.text = temp.ToString();
                    time.text = (System.DateTime.Now.Millisecond - before).ToString() + " ����";
                    startPoint = Vector2.right * -1;
                }

            }
        }
    }

    public void ToPormpt(bool check)
    {
        AStarManager.isPromopted = check;
    }
}
