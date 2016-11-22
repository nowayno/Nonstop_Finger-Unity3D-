/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/9/16 14:20:34
 * 完成时间：
 */
using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    GameObject gameManager;

    Player player;
    Skill skill;

    int p_id;
    float p_blood;
    float p_attack;
    Skill p_skill;
    float p_defend;
    float p_speed;
    int p_level;
    bool canAttack = false;

    float buff_p_xxx;

    float mission;
    static PlayerBuff _buff;
    bool isBuff = false;

    float counttime = 0;
    float countMission = 0;
    float temp_countTime = 0;
    float temp_countMission = 0;
    float temp_blood;
    float temp_attack;
    float temp_defend;
    float temp_speed;
    int temp_level;

    static int buffCount = 0;
    void Awake()
    {
        //_buff = new PlayerBuff();
        //_buff.getBuff().PlayerBuff = Buff.PLAYERBUFF.NONE;
        gameManager = Camera.main.gameObject;

        player = new Player();

        //try
        //{
        player = DoAction.getInstance().readData<Player>(player);
        //}
        //catch (System.Exception e)
        //{ }
        //finally
        //{
        //    player.Id = 0;
        //    player.Blood = 23;
        //    player.Attack = 10;
        //    player.Defend = 10;
        //    player.Level = 1;
        //    player.Speed = 1;
        //    DoAction.getInstance().writeData<Player>(player);
        //}
        p_id = player.Id;
        p_blood = player.Blood;
        p_attack = player.Attack;
        p_skill = new Skill();
        p_defend = player.Defend;
        p_speed = player.Speed;
        p_level = player.Level;

        temp_blood = p_blood;
        temp_attack = p_attack;
        temp_defend = p_defend;
        temp_speed = p_speed;

        //mission = GameManager.mission;
        //Debug.Log(p_blood);
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

            p_speed = player.Speed;
            gameObject.SetActive(false);
            player.Behave.setAction(Behave.ACTION.DEAD);
            //Destroy(gameObject);
        }
        else
        {
            p_speed -= Time.deltaTime;
            if ((p_speed <= 0) && canAttack)
            {
                p_speed = temp_speed;
                gameManager.GetComponent<GameManager>().playerAttackmonster(p_attack);
            }
        }
        //Debug.Log("血量:" + temp_blood + "  " + p_blood);
    }

    public void beAttacked(float damage)
    {
        if (p_blood > 0)
        {
            p_blood -= damage;
        }
    }

    public void Attack(GameObject g)
    {
        //g.GetComponent<MonsterScript>().beAttacked(p_attack);
        gameManager.GetComponent<GameManager>().playerAttackmonster(p_attack);
    }
    public void skillAttack(GameObject g, Skill skill)
    {
        //g.GetComponent<MonsterScript>().beAttacked(skill.Skill_attack);
        gameManager.GetComponent<GameManager>().playerAttackmonster(skill.Skill_attack);
        float buffCatch = Random.Range(0.0f, 50.0f);
        if (buffCatch > 10.0f && buffCatch < 30.0f)
        {
            MonsterBuff mb = new MonsterBuff();
            switch (skill.Skill_id)
            {
                case 0:
                    mb.getBuff().MonsterBuff = Buff.MONSTERBUFF.FIREDAMAGE;
                    mb.setMonsterBuff(mb.getBuff());
                    mb.setBuffData(mb.getBuffData() * skill.Skill_attack);
                    break;
                case 1:
                    mb.getBuff().MonsterBuff = Buff.MONSTERBUFF.ICEDAMAGE;
                    mb.setMonsterBuff(mb.getBuff());
                    break;
                case 2:
                    mb.getBuff().MonsterBuff = Buff.MONSTERBUFF.POISIONDAMAGE;
                    mb.setMonsterBuff(mb.getBuff());
                    mb.setBuffData(mb.getBuffData() * skill.Skill_attack);
                    break;
                case 3:
                    mb.getBuff().MonsterBuff = Buff.MONSTERBUFF.HARDDAMAGE;
                    break;
            }
            //gameManager.GetComponent<GameManager>().addMonsterBuff(mb, p_skill.Skill_Dir);
        }
    }
    public void canNowAttack(bool can)
    {
        canAttack = can;
    }
    public float getBlood()
    {
        return temp_blood;
    }
    public float getNowBlood()
    {
        return p_blood;
    }
    public void missionBlood(int mission)
    {
        temp_blood = DoAction.getInstance().bloodAndMission(0, mission, temp_blood);
        p_blood = temp_blood;
        p_attack = temp_attack;
        p_defend = temp_defend;
        p_speed = temp_speed;
        //temp_blood = p_blood;
    }

    public bool isDead()
    {
        return player.Behave.getAction() == Behave.ACTION.DEAD ? true : false;
    }
    public void reLife()
    {
        p_blood = temp_blood;
    }

    public void addSpeedBuff(float data)
    {
        p_speed = buffChange(p_speed, temp_speed, data);
    }

    public void addDefendBuff(float data)
    {
        p_defend = buffChange(p_defend, temp_defend, data);
    }

    public void addActBuff(float data)
    {
        p_attack = buffChange(p_attack, temp_attack, data);
    }

    public void addBloodBuff(float data)
    {
        p_blood = buffChange(p_blood, temp_blood, data);
    }

    public void addSkillActBuff(float data)
    {
        p_skill.Skill_attack = buffChange(p_skill.Skill_attack, 1, data);
    }

    public void addCDBuff(float data)
    {
        p_skill.Skill_CD = buffChange(p_skill.Skill_CD, 1, data);
    }

    public void minSpeedBuff(float data)
    {
        p_speed = buffChange(p_speed, temp_speed, data);
    }

    public void minDefendBuff(float data)
    {
        p_defend = buffChange(p_defend, temp_defend, data);
    }

    public void minActBuff(float data)
    {
        //Debug.Log(p_attack + "  " + temp_attack);
        p_attack = buffChange(p_attack, temp_attack, data);
    }

    public void minBloodBuff(float data)
    {
        p_blood = buffChange(p_blood, temp_blood, data);
    }

    public void minSkillActBuff(float data)
    {
        p_skill.Skill_attack = buffChange(p_skill.Skill_attack, 1, data);
    }

    public void minCDBuff(float data)
    {
        p_skill.Skill_CD = buffChange(p_skill.Skill_CD, 1, data);
    }

    float buffChange(float predata, float tempdata, float adddata)
    {
        return DoAction.getInstance().addBuff(0, predata, tempdata, adddata);
    }
}