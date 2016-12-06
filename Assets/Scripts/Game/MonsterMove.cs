using UnityEngine;
using System.Collections;

public class MonsterMove : MonoBehaviour
{
    public GameObject player;
    float speed;
    //public GameObject[] monsters;
    // Use this for initialization
    void Start()
    {
        speed = GetComponent<MonsterScript>().getSpeed();
        //player = base.playerGO;
        //monsters = base.monsterGOList;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        float dir = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log(dir);
        if (dir >= 3.0f)
        {
            GetComponent<MonsterBehave>().runBehave("Run");
            Vector3.RotateTowards(transform.position, player.transform.position, 0.5f, 0.5f);
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * 10.0f);
            transform.Translate(Vector3.forward * (speed / 100.0f));
        }
        else
        {
            GetComponent<MonsterBehave>().runBehave("Run", false);
        }
    }
}
