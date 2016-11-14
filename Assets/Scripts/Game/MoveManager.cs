using UnityEngine;
using System.Collections;

public class MoveManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] monsters;
    // Use this for initialization
    void Start()
    {
        //player = base.playerGO;
        //monsters = base.monsterGOList;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject mg in monsters)
        {
            float dir = Vector3.Distance(mg.transform.position, player.transform.position);
            //Debug.Log(dir);
            if (dir >= 2.0f)
            {
                mg.transform.position = Vector3.Lerp(mg.transform.position, player.transform.position, Time.deltaTime);
            }
        }
    }
}
