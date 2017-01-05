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

        if (transform.name != "BackGround")
        {
            widthBack = transform.GetComponent<Renderer>().bounds.size.x / 2.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.DrawLine(leftEdgePos, new Vector3(0, 0, 0));
        if (transform.name != "BackGround")
        {
            float nowPosX1 = leftX + widthBack;
            float nowPosX2 = leftX - widthBack;
            if (transform.position.x > leftX && transform.position.x < nowPosX1)
            {
                transform.position = new Vector3(rightX, trans.position.y, trans.position.z);
            }
            //else if (transform.position.x < rightX && transform.position.x > nowPosX2)
            //{
            //    transform.position = new Vector3(-(nowPosX1 + widthBack), trans.position.y, trans.position.z);
            //}
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
