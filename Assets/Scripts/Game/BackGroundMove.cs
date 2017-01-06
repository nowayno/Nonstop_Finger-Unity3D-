using UnityEngine;
using System.Collections;

public class BackGroundMove : MonoBehaviour
{
    public Transform trans;
    GameObject _nextGO;
    GameObject _preGO;
    float distance;
    float widthBack;
    float leftX;
    float rightX;

    public BackGroundMove() { }
    // Use this for initialization
    void Start()
    {
        widthBack = transform.GetComponent<Renderer>().bounds.size.x / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.DrawLine(leftEdgePos, new Vector3(0, 0, 0));
        float leftEgdeX = transform.position.x - widthBack;
        float rightEdgeX = transform.position.x + widthBack;
        if (rightEdgeX <= leftX)
        {
            transform.position = new Vector3(rightX, trans.position.y, trans.position.z);
        }
        else if (leftEgdeX >= rightX)
        {
            transform.position = new Vector3(leftX, trans.position.y, trans.position.z);
        }
    }

    public void watchBack(BackGroundMoveTemplate bk)
    {
        bk.edge += new BackGroundMoveTemplate.GetEdge(getE);
    }
    public void getE(float left, float right)
    {
        leftX = left;
        rightX = right;
    }
    public void addOrDeleteNext()
    {

    }

    public void addOrDeletePre()
    {

    }
}
