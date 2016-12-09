﻿using UnityEngine;
using System.Collections;

public class MonsterScript : MonoBehaviour
{
    public static int deadnum = 0;
    public int id = 0;
    Monster monster;

    GameObject gameManager;
    public GameObject player;
    public Transform boom;

    private int m_id;
    private float m_blood;
    private float m_attack;
    private float m_speed;
    private float m_defend;
    private bool canAttack = false;

    float buff_p_xxx;

    float mission;
    static PlayerBuff _buff;
    bool isBuff = false;
    bool isFrozen = true;
    bool isBoom = true;

    float counttime = 0;
    float countMission = 0;
    float temp_countTime = 0;
    float temp_countMission = 0;
    float temp_blood;
    float temp_speed = 0;
    float temp_damage = 0;

    float dir = 0;

    static int buffCount = 0;
    float timeCount = 0;

    void Awake()
    {
        gameManager = Camera.main.gameObject;
        monster = new Monster();
        for (int index = 0; index < 5; ++index)
        {
            if (transform.name == ("Monster0" + (index + 1)))
                monster = DoAction.getInstance().readData<Monster>(monster, "Monster0" + (index + 1));
        }
        m_id = monster.Id;
        id = m_id;
        m_blood = monster.Blood;
        m_attack = monster.Attack;
        m_defend = monster.Defend;
        m_speed = monster.Speed;

        temp_blood = m_blood;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dir = Vector3.Distance(transform.position, player.transform.position);
        if (m_blood <= 0)
        {
            if (isBoom)
            {
                isBoom = false;
                Instantiate(boom, gameObject.transform.position, Quaternion.identity);
                //Debug.Log("dead");
            }
            gameObject.GetComponent<MonsterBuffScript>().buffClear();
            transform.position = new Vector3(0, transform.position.z + 100, 0);

            if (monster.Behave.getAction() != Behave.ACTION.DEAD)
            {
                //Debug.Log(deadnum);
                deadnum += 1;
                gameManager.GetComponent<GameManager>().deadNum();
                gameObject.SetActive(false);
            }
            monster.Behave.setAction(Behave.ACTION.DEAD);
            float buffCatch = Random.Range(0.0f, 50.0f);
            if (buffCatch > 10.0f && buffCatch < 20.0f)
            {
                gameManager.GetComponent<GameManager>().addPlayerBuff(new PlayerBuff());
                //Debug.Log("add buff");
            }


            m_blood = monster.Blood;
            m_attack = monster.Attack;
            m_speed = monster.Speed;
            //gameObject.SetActive(false);
        }
        else
        {
            m_speed -= Time.deltaTime;
            if ((m_speed <= 0) && canAttack)
            {
                m_speed = monster.Speed;
                GetComponent<MonsterBehave>().attackBehave("Attack01");
                //monsterAttackPlayer();
            }
            //else if(canAttack==false)
            //{
            //    GetComponent<MonsterBehave>().aliveBehave("idle");
            //}
        }
        //Debug.Log((m_speed <= 0));

    }
    public void monsterAttackPlayer()
    {
        if (canAttack)
        {
            gameManager.GetComponent<GameManager>().monsterAttackplayer(m_attack);
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
        GetComponent<MonsterBehave>().attackBehave("Attack");
        gameManager.GetComponent<GameManager>().monsterAttackplayer(m_attack);
    }
    public void canNowAttack(bool can)
    {
        canAttack = can;
    }
    public void missionAct(int mission)
    {
        m_attack = DoAction.getInstance().actAndMission(1, mission);
    }

    public void missionBlood(int mission)
    {
        m_blood = DoAction.getInstance().bloodAndMission(1, mission);
    }
    public float getSpeed()
    {
        return m_speed;
    }
    public float getBlood()
    {
        return temp_blood;
    }
    public float getNowBlood()
    {
        return m_blood;
    }
    public float getDir()
    {
        return dir;
    }
    public void setDir(float d)
    {
        dir = d;
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
        gameObject.SetActive(true);
        monster.Behave.setAction(Behave.ACTION.ALIVE);
    }
    public void addFireBuff(float delaydamage)
    {
        //temp_damage = delaydamage;
        addDamage(delaydamage);
    }

    public void addIceBuff(float dtime)
    {
        //m_speed = m_speed * dtime;
    }

    public void addPoisionBuff(float delaydamage)
    {
        //temp_damage = delaydamage;
        addDamage(delaydamage);
    }

    public void addHardBuff()
    {
        //temp_speed = m_speed;
        //m_speed = 0;
    }

    public void minFireBuff()
    {

    }

    public void minIceBuff()
    {

    }

    public void minPoisionBuff()
    {
        //m_speed = m_speed * 2;
    }

    public void minHardBuff()
    {
        // m_speed = temp_speed;
    }

    public void addDamage(float damage)
    {
        gameManager.GetComponent<GameManager>().playerAttackmonster(damage);
    }

    float buffChange(float preData, float damage)
    {
        return DoAction.getInstance().addBuff(1, preData, damage);
    }
}
