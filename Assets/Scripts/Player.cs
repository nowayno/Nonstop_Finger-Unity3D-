/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2015.9.6
 * 完成时间：
 */

using UnityEngine;
using System.Collections;

public class Player
{
    /*
     * 
     *以下是玩家的标志号，血量，攻击力，技能，技能攻击力，防御力，等级，还有游戏体 
     * 
     */
    private int p_id;
    private float p_blood;
    private float p_attack;
    private Skill p_skill;
    private float p_skillattack;
    private float p_defend;
    private int p_level;
    private GameObject p_gameobject;

    public int P_id
    {
        get
        {
            return p_id;
        }

        set
        {
            p_id = value;
        }
    }

    public float P_blood
    {
        get
        {
            return p_blood;
        }

        set
        {
            p_blood = value;
        }
    }

    public float P_attack
    {
        get
        {
            return p_attack;
        }

        set
        {
            p_attack = value;
        }
    }

    public Skill P_skill
    {
        get
        {
            return p_skill;
        }

        set
        {
            p_skill = value;
        }
    }

    public float P_skillattack
    {
        get
        {
            return p_skillattack;
        }

        set
        {
            p_skillattack = value;
        }
    }

    public float P_defend
    {
        get
        {
            return p_defend;
        }

        set
        {
            p_defend = value;
        }
    }

    public int P_level
    {
        get
        {
            return p_level;
        }

        set
        {
            p_level = value;
        }
    }

    public GameObject P_gameobject
    {
        get
        {
            return p_gameobject;
        }

        set
        {
            p_gameobject = value;
        }
    }
}
