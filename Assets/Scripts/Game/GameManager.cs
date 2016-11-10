using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : TemplateClass<GameManager>
{
    int buffTarget = -1;

    GameObject playerGO;
    List<GameObject> monsterGOList;
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
        if (playerGO != null)
        {
            if (monsterGOList.Count < 0)
            {
                float dir = Random.Range(-1, 1) <= 0 ? -1 : 1;
                foreach (GameObject m in monsterGOList)
                {
                    float pos = Random.Range(20, 30) * dir;
                    //获取怪物游戏体中的脚本中的Monster类，判断是否死亡
                    //若全部死亡则重新生成
                    //m.GetComponent<MonsterScript>().
                    initMonsterGameObject();
                    m.transform.position = playerGO.transform.localPosition + new Vector3(pos, 0, 0);
                }
            }
        }
        for (int index = monsterAttack.Count; index > 0; --index)
        {
            if (monsterAttack[index - 1] > 0)
            {
                playerGO.GetComponent<PlayerScript>().beAttacked(monsterAttack[index]);
                monsterAttack.Remove(index);
            }
        }
        for (int index = playerAttack.Count; index > 0; --index)
        {
            if (playerAttack[index] > 0)
            {
                monsterGOList[0].GetComponent<MonsterScript>().beAttacked(playerAttack[index]);
                playerAttack.Remove(index);
            }
        }
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
