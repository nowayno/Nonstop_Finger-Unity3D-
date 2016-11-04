using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : TemplateClass<GameManager>
{

    GameObject playerGo;
    GameObject[] monsterGoList;
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
