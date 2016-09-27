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

    float buff_p_blood;
    float buff_p_attack;
    Skill buff_p_skill;
    float buff_p_defend;
    float buff_p_speed;

    float mission;
    static BUFF _buff;
    int isBuff = -1;
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
        if (mission < Manager.mission)
        {
            p_blood = DoAction.getInstance().bloodAndMission(0, Manager.mission, p_defend);
            Debug.Log("player_blood:" + p_blood);
        }
        else if (mission == Manager.mission)
        {
            if (isBuff != -1)
            {
                switch (_buff._PLAYERBUFF)
                {
                    case BUFF.PLAYERBUFF.ADDACT:
                        DoAction.getInstance().addBuff(0, _buff, p_attack, buff_p_attack);
                        break;
                    case BUFF.PLAYERBUFF.ADDBLOOD:
                        DoAction.getInstance().addBuff(0, _buff, p_blood, buff_p_blood);
                        break;
                    case BUFF.PLAYERBUFF.ADDDEFEND:
                        DoAction.getInstance().addBuff(0, _buff, p_speed, buff_p_speed);
                        break;
                    case BUFF.PLAYERBUFF.ADDSKILLACT:
                        DoAction.getInstance().addBuff(0, _buff, p_skill.Skill_attack, buff_p_skill.Skill_attack);
                        break;
                    case BUFF.PLAYERBUFF.ADDSPEED:
                        DoAction.getInstance().addBuff(0, _buff, p_speed, buff_p_speed);
                        break;
                    case BUFF.PLAYERBUFF.CD:
                        DoAction.getInstance().addBuff(0, _buff, p_skill.Skill_CD, buff_p_skill.Skill_CD);
                        break;
                    case BUFF.PLAYERBUFF.NONE:
                        p_blood = DoAction.getInstance().bloodAndMission(0, Manager.mission, p_defend);
                        isBuff = -1;
                        break;
                }
            }
        }
    }
}
