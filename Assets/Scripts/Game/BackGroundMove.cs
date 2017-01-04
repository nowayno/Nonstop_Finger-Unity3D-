using UnityEngine;
using System.Collections;

public class BackGroundMove : MonoBehaviour
{
    public Transform trans;
    GameObject _nextGO;
    GameObject _preGO;
    float distance;
    float widthBack;
    // Use this for initialization
    void Start()
    {
        distance = Vector3.Distance(trans.position, Camera.main.transform.position);
        if (transform.name != "BackGround")
        {
            widthBack = transform.GetComponent<Renderer>().bounds.size.x / 2.0f;
        }
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
        Vector3 edgePos = Camera.main.transform.position -
            Camera.main.transform.right * width +
            Camera.main.transform.up * height +
            Camera.main.transform.forward * distance;
        float rightX = edgePos.x;
        Debug.DrawLine(edgePos, new Vector3(0, 0, 0));
        if (transform.name != "BackGround")
        {
            float nowPosX1 = rightX + widthBack;
            float nowPosX2 = rightX - widthBack;
            if (transform.position.x > rightX && transform.position.x < nowPosX1)
            {
                transform.position = new Vector3(nowPosX1 + widthBack, trans.position.y, trans.position.z);
            }
            //else if (transform.position.x < rightX && transform.position.x > nowPosX2)
            //{
            //    transform.position = new Vector3(-(nowPosX1 + widthBack), trans.position.y, trans.position.z);
            //}
        }
    }
    public void addOrDeleteNext()
    {

    }

    public void addOrDeletePre()
    {

    }
}
