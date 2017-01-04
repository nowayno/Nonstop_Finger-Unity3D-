using UnityEngine;
using System.Collections;

public class GroundMove : MonoBehaviour
{
    public Transform trans;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(trans.position.x, transform.position.y, transform.position.z);
    }
}
