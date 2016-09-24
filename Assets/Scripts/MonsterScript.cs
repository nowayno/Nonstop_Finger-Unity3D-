using UnityEngine;
using System.Collections;

public class MonsterScript : MonoBehaviour
{

    Monster monster;

    float time_count = 0;
    float mission = 1;
    // Use this for initialization
    void Start()
    {
        monster = new Monster();
        monster = DoAction.getInstance().readData<Monster>(monster);
        Debug.Log("Monster:\n" + "monster blood:" + monster.Blood + "\nmonster attack:" + monster.Attack + "\nmonster defend:" + monster.Defend);
    }

    // Update is called once per frame
    void Update()
    {
        time_count += Time.deltaTime;
        if (time_count >= 10)
        {
            time_count = 0;
            mission++;
            monster.Blood = DoAction.getInstance().bloodAndMission(1, mission);
            monster.Attack = DoAction.getInstance().actAndMission(1, mission);
            Debug.Log("monster_bood and mission:" + monster.Blood + "\nmonster_act and mission:" + monster.Attack);
            
        }

    }

}
