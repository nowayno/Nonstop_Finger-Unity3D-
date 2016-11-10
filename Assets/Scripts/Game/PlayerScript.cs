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
    static PlayerBuff _buff;
    bool isBuff = false;

    float counttime = 0;
    float countMission = 0;
    float temp_countTime = 0;
    float temp_countMission = 0;

    static int buffCount = 0;
    void Awake()
    {
        _buff = new PlayerBuff();
        _buff.getBuff().PlayerBuff = Buff.PLAYERBUFF.NONE;
        p_go = gameObject;

        player = new Player();
        player = DoAction.getInstance().readData<Player>(player);
        p_id = player.Id;
        p_blood = player.Blood;
        p_attack = player.Attack;
        p_skill = player.Skill;
        p_defend = player.Defend;
        p_speed = player.Speed;
        p_level = player.Level;

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
            gameObject.SetActive(false);
            //Destroy(gameObject);
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
                    _buff.getBuff().PlayerBuff = Buff.PLAYERBUFF.NONE;
                    isBuff = false;
                }
            }
        }

    }

    public void buffChange(Buff _b, bool isTimeup = false, params float[] param)
    {
        _buff.getBuff().PlayerBuff = _b.PlayerBuff;
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
        if (p_blood>0)
        {
            p_blood -= damage;
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

    public void addSpeedBuff(float data)
    {
        p_speed = buffChange(p_speed, data);
    }

    public void addDefendBuff(float data)
    {
        p_defend = buffChange(p_defend, data);
    }

    public void addActBuff(float data)
    {
        p_attack = buffChange(p_attack, data);
    }

    public void addBloodBuff(float data)
    {
        p_blood = buffChange(p_blood, data);
    }

    public void addSkillActBuff(float data)
    {
        p_skill.Skill_attack = buffChange(p_skill.Skill_attack, data);
    }

    public void addCDBuff(float data)
    {
        p_skill.Skill_CD = buffChange(p_skill.Skill_CD, data);
    }

    public void minSpeedBuff(float data)
    {
        p_speed = buffChange(p_speed, data);
    }

    public void minDefendBuff(float data)
    {
        p_defend = buffChange(p_defend, data);
    }

    public void minActBuff(float data)
    {
        p_attack = buffChange(p_attack, data);
    }

    public void minBloodBuff(float data)
    {
        p_blood = buffChange( p_blood, data);
    }

    public void minSkillActBuff(float data)
    {
        p_skill.Skill_attack = buffChange(p_skill.Skill_attack, data);
    }

    public void minCDBuff(float data)
    {
        p_skill.Skill_CD = buffChange(p_skill.Skill_CD, data);
    }

    float buffChange(float predata,float adddata)
    {
        return DoAction.getInstance().addBuff(0, predata, adddata);
    }
}