using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : TemplateClass<GameManager>
{

    GameObject playerGO;
    List<GameObject> monsterGOList;
    List<MonsterBuffScript> monsterBuffList = new List<MonsterBuffScript>();
    List<PlayerBuffScript> playerBuffList = new List<PlayerBuffScript>();

    public List<MonsterBuffScript> MonsterBuffList
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

    public List<PlayerBuffScript> PlayerBuffList
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
        if (monsterBuffList.Count > 0)
        {
            foreach (MonsterBuffScript _b in monsterBuffList)
            {
                if (_b.Buff.IsEnd)
                {
                    _b.destroySelf();
                    monsterBuffList.Remove(_b);
                }
            }
        }
    }

    public void addMonsterBuff(ref MonsterBuffScript bfs)
    {
        monsterBuffList.Add(bfs);
    }
    public void addPlayerBuff(ref PlayerBuffScript pfs)
    {
        playerBuffList.Add(pfs);
    }
}
