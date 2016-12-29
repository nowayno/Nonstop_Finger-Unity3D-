/**
 * 敌人行动起来
 * 
 **/
using UnityEngine;
using System.Collections;

public class MonsterMove : MonoBehaviour
{
    public GameObject player;
    float speed;
    float dir = 0;
    float angle = 45.0f;
    float maxView = 2.0f;
    // Use this for initialization
    void Start()
    {
        speed = GetComponent<MonsterScript>().getSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        sawSomeone();
        //不管是谁，背对着人家打人家，是不对的
        transform.LookAt(player.transform);
        dir = Vector3.Distance(transform.position, player.transform.position);
        //我与他的距离，使我们不停的奔跑，当我们相近的时候，就是兵刃相见
        if (dir >= 3.0f)
        {
            GetComponent<MonsterBehave>().runBehave("Run");
            Vector3.RotateTowards(transform.position, player.transform.position, 0.5f, 0.5f);
            transform.Translate(Vector3.forward * (speed / 100.0f));
        }
        else
        {
            GetComponent<MonsterBehave>().runBehave("Run", false);
        }
    }
    void sawSomeone()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit ray;
        if (Physics.Raycast(transform.position, forward, out ray))
        {
            string name = ray.transform.name;
            if (name == "Player")
            {

            }
            else
            {
                float an = Vector3.Angle(transform.position, ray.transform.position);
                if (an > angle)
                {
                    //Debug.Log("out of my sight");
                }
                else
                {
                    //Debug.Log("hey get out of my way!");
                    float distance = Vector3.Distance(transform.position, ray.transform.position);
                    if (distance < maxView)
                    {
                        if (transform.position.z <= ray.transform.position.z)
                        {
                            transform.Translate(Vector3.left * (speed / 10.0f));
                        }
                        else
                        {
                            transform.Translate(Vector3.right * (speed / 10.0f));
                        }
                    }
                }
            }
        }
    }
    //获取敌人与玩家的距离
    public float getDir()
    {
        return dir;
    }
}
