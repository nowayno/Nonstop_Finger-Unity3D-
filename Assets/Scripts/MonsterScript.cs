using UnityEngine;
using System.Collections;

public class MonsterScript : MonoBehaviour
{
    float time_count = 0;

    Monster monster;

    private int m_id;
    private float m_blood;
    private float m_attack;
    private float m_speed;
    private float m_defend;

    float buff_p_xxx;

    float mission;
    static BUFF _buff;
    bool isBuff = false;
    bool isFrozen = true;

    float counttime = 0;
    float countMission = 0;
    float temp_countTime = 0;
    float temp_countMission = 0;

    static int buffCount = 0;


    void Awake()
    {
        monster = new Monster();
        monster = DoAction.getInstance().readData<Monster>(monster);
        m_id = monster.Id;
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
        //counttime+=Time.deltaTime;
        //if (counttime >= 5)
        //{
        //    gameObject.GetComponent<PlayerScript>().beAttacked(m_attack);
        //    counttime = 0;
        //}
        if (m_blood <= 0)
        {
            Destroy(gameObject);
        }
        if (isBuff == true)
        {
            if (mission < Manager.mission)
            {
                m_blood = DoAction.getInstance().bloodAndMission(0, Manager.mission, m_defend + m_blood);
                //Debug.Log("player_blood:" + p_blood);
            }
            else if (mission == Manager.mission)
            {
                if (buffCount <= 0)
                {
                    _buff._MONSTERBUFF = BUFF.MONSTERBUFF.NONE;
                    isBuff = false;
                }
                switch (_buff._MONSTERBUFF)
                {
                    case BUFF.MONSTERBUFF.FIREDAMAGE:
                        m_blood -= DoAction.getInstance().addBuff(0, _buff, m_blood, buff_p_xxx);
                        break;
                    case BUFF.MONSTERBUFF.ICEDAMAGE:
                        m_blood -= DoAction.getInstance().addBuff(0, _buff, m_blood, buff_p_xxx);
                        if (isFrozen)
                        {
                            isFrozen = false;
                            m_speed -= DoAction.getInstance().addBuff(0, _buff, m_speed, buff_p_xxx);
                        }
                        break;
                    case BUFF.MONSTERBUFF.POISIONDAMAGE:
                        m_blood -= DoAction.getInstance().addBuff(0, _buff, m_blood, buff_p_xxx);
                        break;
                    case BUFF.MONSTERBUFF.HARDDAMAGE:
                        m_blood -= DoAction.getInstance().addBuff(0, _buff, m_blood, buff_p_xxx);
                        break;
                    case BUFF.MONSTERBUFF.NONE:
                        m_blood = DoAction.getInstance().bloodAndMission(0, Manager.mission, m_defend + m_blood);
                        m_attack = monster.Attack;
                        m_defend = monster.Defend;

                        isFrozen = true;
                        break;
                }

            }
        }

    }

    public void buffChange(BUFF _b, bool isTimeup = false, params float[] param)
    {
        _buff._MONSTERBUFF = _b._MONSTERBUFF;
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
        m_blood -= damage;
        Debug.Log("m_blood" + m_blood);
        if (m_blood <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Attack(GameObject g)
    {
        g.GetComponent<PlayerScript>().beAttacked(m_attack);
    }

}
