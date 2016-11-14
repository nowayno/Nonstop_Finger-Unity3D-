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
    private int g_id;
    private float g_blood;
    private float g_attack;
    private float g_defend;
    private float g_speed;
    private int g_level;
    private Skill p_skill;
    private PlayerBehave p_behave;
    //private GameObject p_gameobject;

    public Player()
    {
        p_behave = new PlayerBehave();
    }

    public PlayerBehave Behave
    {
        get
        {
            return p_behave;
        }
    }

    public Skill Skill
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

    public int Id
    {
        get
        {
            return g_id;
        }

        set
        {
            g_id = value;
        }
    }

    public float Blood
    {
        get
        {
            return g_blood;
        }

        set
        {
            g_blood = value;
        }
    }

    public float Attack
    {
        get
        {
            return g_attack;
        }

        set
        {
            g_attack = value;
        }
    }

    public float Defend
    {
        get
        {
            return g_defend;
        }

        set
        {
            g_defend = value;
        }
    }

    public float Speed
    {
        get
        {
            return g_speed;
        }

        set
        {
            g_speed = value;
        }
    }

    public int Level
    {
        get
        {
            return g_level;
        }

        set
        {
            g_level = value;
        }
    }

    //public GameObject P_gameobject
    //{
    //    get
    //    {
    //        return p_gameobject;
    //    }

    //    set
    //    {
    //        p_gameobject = value;
    //    }
    //}
}
