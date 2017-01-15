/**
 * 这个能多说什么呢，镜头的跟踪
 **/
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

    public GameObject player;
    Transform trans;

    // Use this for initialization
    void Start()
    {
        trans = player.transform;
    }

    /// <summary>
    /// 镜头跟着玩家行动
    /// </summary>
    void Update()
    {
        Vector3 targetPos = trans.position + new Vector3(0, 2.28f, -6f);
        //Lerp方法，跟踪和被跟踪物体位置，第三个参数是一个插值，简单说就是每一次都会根据两者距离进行计算，形成一种润滑的移动。
        //可以百度线性插值
        //transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);
        transform.position = targetPos;
        Quaternion q = Quaternion.LookRotation(trans.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime);
        //transform.position = Vector3.Lerp(trans.position, transform.position, Time.deltaTime);
    }
}
