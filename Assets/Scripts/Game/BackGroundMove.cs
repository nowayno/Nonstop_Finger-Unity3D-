using UnityEngine;
using System.Collections;

public class BackGroundMove : MonoBehaviour
{
    public Transform trans;
    GameObject _nextGO;
    GameObject _preGO;
    float distance;
    // Use this for initialization
    void Start()
    {
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
        float rightX = (Camera.main.transform.position -
            Camera.main.transform.right * width +
            Camera.main.transform.up * height +
            Camera.main.transform.forward * distance).x;

        float nowPosX = transform.GetComponent<Renderer>().bounds.size.x;
    }
    public void addOrDeleteNext()
    {

    }

    public void addOrDeletePre()
    {

    }
}
