using UnityEngine;
using System.Collections;

public class BackGroundMoveTemplate : TemplateClass<BackGroundMoveTemplate>
{
    public Transform trans;
    public GameObject[] go;

    BackGroundMove bgm;

    float distance;

    public BackGroundMoveTemplate() { }
    // Use this for initialization
    void Start()
    {
        foreach (GameObject g in go)
        {
            g.GetComponent<BackGroundMove>().watchBack(GetComponent<BackGroundMoveTemplate>());
        }
        distance = Vector3.Distance(trans.position, Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //获取摄像机左右大致范围
        //利用弧度以及数学tan公式算出范围再确定点的位置
        float ang = Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad;
        float ratio = Camera.main.aspect;
        float height = distance * Mathf.Tan(ang);
        float width = height * ratio;
        Vector3 rightEdgePos = Camera.main.transform.position +
            Camera.main.transform.right * width +
            Camera.main.transform.up * height +
            Camera.main.transform.forward * distance;
        Vector3 leftEdgePos = Camera.main.transform.position -
            Camera.main.transform.right * width +
            Camera.main.transform.up * height +
            Camera.main.transform.forward * distance;
        float leftX = leftEdgePos.x;
        float rightX = rightEdgePos.x;
        //Debug.Log(leftX + "  " + rightX);
        GetEdge_Event(leftX, rightX);
    }
}
