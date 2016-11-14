using UnityEngine;
using System.Collections;

public class MonsterScript : MonoBehaviour
{
    public static int deadnum = 0;
    public int id = 0;
    Monster monster;

    GameObject gameManager;

    private int m_id;
    private float m_blood;
    private float m_attack;
    private float m_speed;
    private float m_defend;

    float buff_p_xxx;

    float mission;
    static PlayerBuff _buff;
    bool isBuff = false;
    bool isFrozen = true;

    float counttime = 0;
    float countMission = 0;
    float temp_countTime = 0;
    float temp_countMission = 0;
    float temp_speed = 0;
    float temp_damage = 0;

    static int buffCount = 0;
    float timeCount = 0;

    void Awake()
    {
        gameManager = Camera.main.gameObject;
        monster = new Monster();
        monster = DoAction.getInstance().readData<Monster>(monster);
        m_id = id;
        m_blood = monster.Blood;
        m_attack = monster.Attack;
        m_defend = monster.Defend;
        m_speed = monster.Speed;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_blood <= 0)
        {
            //Debug.Log("dead");
            monster.Behave.setAction(Behave.ACTION.DEAD);
            float buffCatch = Random.Range(0.0f, 50.0f);
            if (buffCatch > 10.0f && buffCatch < 20.0f)
            {
                gameManager.GetComponent<GameManager>().addPlayerBuff(new PlayerBuff());
                //Debug.Log("add buff");
            }
            deadnum += 1;
            gameManager.GetComponent<GameManager>().deadNum();
            m_blood = monster.Blood;
            m_attack = monster.Attack;

            //gameObject.SetActive(false);
        }

        timeCount += Time.deltaTime;
        if (timeCount >= 1)
        {
            if (m_blood > 0)
            {
                m_blood -= temp_damage;
            }
            timeCount = 0;
        }
    }

    public void buffChange(Buff _b, bool isTimeup = false, params float[] param)
    {
        _buff.getBuff().MonsterBuff = _b.MonsterBuff;
        if (param.Length > 1)
        {
            if (isTimeup == false)
            {
                ++buffCount;
                if (param[1] == -1)
                {
                    temp_countTime = param[0];
                }
                else if (param[1] == 0)
                {
                    temp_countMission = param[0];
                }
                else
                {
                    temp_countTime = param[0];
                    temp_countMission = param[1];
                }
                buff_p_xxx = param[2];
                isBuff = true;
            }
            else if (isTimeup == true)
            {
                --buffCount;
                buff_p_xxx = param[2];
            }
        }
    }

    public void beAttacked(float damage)
    {
        //Debug.Log(id + " m_blood " + m_blood);
        if (m_blood > 0)
        {
            m_blood -= damage;
        }
    }

    public void Attack(GameObject g)
    {
        //g.GetComponent<PlayerScript>().beAttacked(m_attack);
        GameManager.monsterAttackplayer(m_attack);
    }

    public void missionAct(int mission)
    {
        m_attack = DoAction.getInstance().actAndMission(1, m_attack, mission);
    }

    public void missionBlood(int mission)
    {
        m_blood = DoAction.getInstance().bloodAndMission(1, m_blood, mission);
    }

    public void reBlood()
    {
        m_blood = monster.Blood;
    }

    public void reAct()
    {
        m_attack = monster.Attack;
    }

    public bool isDead()
    {
        return monster.Behave.getAction() == Behave.ACTION.DEAD ? true : false;
    }
    public void Relife()
    {
        monster.Behave.setAction(Behave.ACTION.ALIVE);
    }
    public void addFireBuff(float delaydamage)
    {
        temp_damage = delaydamage;
    }

    public void addIceBuff(float dtime)
    {
        m_speed = m_speed * dtime;
    }

    public void addPoisionBuff(float delaydamage)
    {
        temp_damage = delaydamage;
    }

    public void addHardBuff()
    {
        temp_speed = m_speed;
        m_speed = 0;
    }

    public void minFireBuff()
    {

    }

    public void minIceBuff()
    {

    }

    public void minPoisionBuff()
    {
        m_speed = m_speed * 2;
    }

    public void minHardBuff()
    {
        m_speed = temp_speed;
    }

    float buffChange(float preData, float damage)
    {
        return DoAction.getInstance().addBuff(1, preData, damage);
    }
}
