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

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = trans.position + new Vector3(0, 2.28f, -10f);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);
        Quaternion q = Quaternion.LookRotation(trans.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime);
        //transform.position = Vector3.Lerp(trans.position, transform.position, Time.deltaTime);
    }
}
