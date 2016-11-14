using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : TemplateClass<GameManager>
{
    int buffTarget = -1;
    int mission = 0;
    int monsterAllDead = 0;


    public GameObject playerGO;
    public GameObject[] monsterGOList;
    static List<float> monsterAttack;
    static List<float> playerAttack;
    List<MonsterBuff> monsterBuffList = new List<MonsterBuff>();
    List<PlayerBuff> playerBuffList = new List<PlayerBuff>();

    public List<MonsterBuff> MonsterBuffList
    {
        get
        {
            return monsterBuffList;
        }

        set
        {
            monsterBuffList = value;
        }
    }

    public List<PlayerBuff> PlayerBuffList
    {
        get
        {
            return playerBuffList;
        }

        set
        {
            playerBuffList = value;
        }
    }

    void Awake()
    {
        monsterAttack = new List<float>();
        playerAttack = new List<float>();
        //monsterGOList = new GameObject[5];
    }

    // Use this for initialization
    void Start()
    {

    }

    void initMonsterGameObject()
    {
        /*
         *List.add(go) 
         */
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterAllDead >= 15)
        {
            mission += 1;
            monsterAllDead = 0;
        }
        if (playerGO.GetComponent<PlayerScript>().isDead() != true)
        {
            Debug.Log(MonsterScript.deadnum);
            if (MonsterScript.deadnum >= 4)
            {
                monsterAttack.Clear();
                playerAttack.Clear();
                float dir = Random.Range(-0.4f, 0.4f) <= 0 ? -1 : 1;
                Debug.Log(dir);
                foreach (GameObject m in monsterGOList)
                {
                    float pos = Random.Range(20, 30) * dir;
                    m.GetComponent<MonsterScript>().missionBlood(mission);
                    m.GetComponent<MonsterScript>().missionAct(mission);
                    m.GetComponent<MonsterScript>().Relife();
                    m.transform.position = playerGO.transform.localPosition + new Vector3(pos, 0, 0);
                }
                MonsterScript.deadnum = 0;
            }
            foreach (GameObject m in monsterGOList)
            {
                float dir = Vector3.Distance(m.transform.localPosition, playerGO.transform.localPosition);
                if (dir < 2.0f)
                {
                    playerGO.GetComponent<PlayerScript>().Attack(m);

                    m.GetComponent<MonsterScript>().Attack(playerGO);
                }
            }
        }
        for (int index = monsterAttack.Count; index > 0; --index)
        {
            if (monsterAttack[index - 1] > 0)
            {
                playerGO.GetComponent<PlayerScript>().beAttacked(monsterAttack[index - 1]);
                monsterAttack.Remove(index);
            }
        }
        for (int index = playerAttack.Count; index > 0; --index)
        {
            if (playerAttack[index - 1] > 0)
            {
                foreach (GameObject m in monsterGOList)
                {
                    if (m.GetComponent<MonsterScript>().isDead() == false)
                    {
                        m.GetComponent<MonsterScript>().beAttacked(playerAttack[index - 1]);
                        playerAttack.Remove(index);
                        break;
                    }
                }
            }
        }
    }

    public void deadNum()
    {
        monsterAllDead += 1;
    }

    public void addMonsterBuff(MonsterBuff bfs, float tar_length)
    {
        foreach (GameObject go in monsterGOList)
        {
            float length = Vector3.Distance(playerGO.transform.localPosition, go.transform.localPosition);
            if (length <= tar_length)
            {
                go.GetComponent<MonsterBuffScript>().addBuff(bfs);
            }
        }
    }
    public void addPlayerBuff(PlayerBuff pfs)
    {
        playerGO.GetComponent<PlayerBuffScript>().addBuff(pfs);
    }

    public static void monsterAttackplayer(float attack)
    {
        monsterAttack.Insert(0, attack);
    }

    public static void playerAttackmonster(float attack)
    {
        playerAttack.Insert(0, attack);
    }
}
