/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/9/16 14:20:34
 * 完成时间：
 */
using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    GameObject p_go;

    Player player;
    Skill skill;

    int p_id;
    float p_blood;
    float p_attack;
    Skill p_skill;
    float p_defend;
    float p_speed;
    int p_level;

    float buff_p_xxx;

    float mission;
    static BUFF _buff;
    bool isBuff = false;

    float counttime = 0;
    float countMission = 0;
    float temp_countTime = 0;
    float temp_countMission = 0;

    static int buffCount = 0;
    void Awake()
    {
        _buff = new BUFF();
        _buff._PLAYERBUFF = BUFF.PLAYERBUFF.NONE;
        p_go = gameObject;

        player = new Player();
        player = DoAction.getInstance().readData<Player>(player);
        p_id = player.P_id;
        p_blood = player.P_blood;
        p_attack = player.P_attack;
        p_skill = player.P_skill;
        p_defend = player.P_defend;
        p_speed = player.P_speed;
        p_level = player.P_level;

        mission = Manager.mission;
        Debug.Log(p_blood);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //counttime += Time.deltaTime;
        //if (counttime >= 5)
        //{
        //    gameObject.GetComponent<MonsterScript>().beAttacked(p_attack);
        //    counttime = 0;
        //}
        if (p_blood <= 0)
        {
            Destroy(gameObject);
        }
        if (isBuff == true)
        {
            if (mission < Manager.mission)
            {
                p_blood = DoAction.getInstance().bloodAndMission(0, Manager.mission, p_defend + p_blood);
                //Debug.Log("player_blood:" + p_blood);
            }
            else if (mission == Manager.mission)
            {
                if (buffCount <= 0)
                {
                    _buff._PLAYERBUFF = BUFF.PLAYERBUFF.NONE;
                    isBuff = false;
                }
                switch (_buff._PLAYERBUFF)
                {
                    case BUFF.PLAYERBUFF.ADDACT:
                        p_attack += DoAction.getInstance().addBuff(0, _buff, p_attack, buff_p_xxx);
                        break;
                    case BUFF.PLAYERBUFF.ADDBLOOD:
                        p_blood += DoAction.getInstance().addBuff(0, _buff, p_blood, buff_p_xxx);
                        break;
                    case BUFF.PLAYERBUFF.ADDDEFEND:
                        p_defend += DoAction.getInstance().addBuff(0, _buff, p_defend, buff_p_xxx);
                        break;
                    case BUFF.PLAYERBUFF.ADDSKILLACT:
                        p_skill.Skill_attack += DoAction.getInstance().addBuff(0, _buff, p_skill.Skill_attack, buff_p_xxx);
                        break;
                    case BUFF.PLAYERBUFF.ADDSPEED:
                        p_speed += DoAction.getInstance().addBuff(0, _buff, p_speed, buff_p_xxx);
                        break;
                    case BUFF.PLAYERBUFF.CD:
                        if (p_skill.Skill_CD > 0)
                        {
                            p_skill.Skill_CD -= DoAction.getInstance().addBuff(0, _buff, p_skill.Skill_CD, buff_p_xxx);
                        }
                        break;
                    case BUFF.PLAYERBUFF.NONE:
                        p_blood = DoAction.getInstance().bloodAndMission(0, Manager.mission, p_defend + p_blood);
                        p_attack = player.P_attack;
                        p_defend = player.P_defend;
                        p_skill.Skill_attack = skill.Skill_attack;
                        p_speed = player.P_speed;
                        p_skill.Skill_CD = skill.Skill_CD;

                        break;
                }

            }
        }

    }

    public void buffChange(BUFF _b, bool isTimeup = false, params float[] param)
    {
        _buff._PLAYERBUFF = _b._PLAYERBUFF;
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
        if (DoAction.getInstance().beAttacked(ref p_blood, damage) == -1)
        {
            Destroy(p_go);
        }
    }

    public void Attack(GameObject g, float skill_Attack, bool isSkill = false)
    {
        g.GetComponent<MonsterScript>().beAttacked(p_attack);
        if (isSkill)
        {
            g.GetComponent<MonsterScript>().beAttacked(skill_Attack);
        }
    }
}