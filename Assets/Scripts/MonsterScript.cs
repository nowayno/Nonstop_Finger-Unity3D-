using UnityEngine;
using System.Collections;

public class MonsterScript : MonoBehaviour
{
    float time_count = 0;

    Monster monster;

    private int m_id;
    private float m_blood;
    private float m_attack;
    private float m_defend;
    // Use this for initialization
    void Start()
    {
        monster = new Monster();
        monster = DoAction.getInstance().readData<Monster>(monster);
        m_id = monster.Id;
        m_blood = monster.Blood;
        m_attack = monster.Attack;
        m_defend = monster.Defend;
    }

    // Update is called once per frame
    void Update()
    {
        time_count += Time.deltaTime;
        if (time_count >= 10)
        {
            time_count = 0;

        }

    }

}
