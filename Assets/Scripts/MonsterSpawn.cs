using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawn : MonoBehaviour
{

    List<MonsterScript> monster_List;


    void Awake()
    {
        monster_List = new List<MonsterScript>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(monster_List.Count<=0)
        {

        }
        else if(monster_List.Count>0)
        {

        }
    }
}
