/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2015.9.6
 * 完成时间：
 */
using UnityEngine;
using System.Collections;

public class Skill
{
    /*
     * 技能的编号，名字，攻击力，冷却时间 
     * 
     */
    private int skill_id;
    private string skill_name;
    private float skill_attack;
    private float skill_tattack;
    private float skill_time;
    private float skill_CD;
    private float skill_Dir;
    private Buff buffType;
    private string resName;

    public int Skill_id
    {
        get
        {
            return skill_id;
        }

        set
        {
            skill_id = value;
        }
    }

    public string Skill_name
    {
        get
        {
            return skill_name;
        }

        set
        {
            skill_name = value;
        }
    }

    public float Skill_attack
    {
        get
        {
            return skill_attack;
        }

        set
        {
            skill_attack = value;
        }
    }

    public float Skill_CD
    {
        get
        {
            return skill_CD;
        }

        set
        {
            skill_CD = value;
        }
    }

    public float Skill_tattack
    {
        get
        {
            return skill_tattack;
        }

        set
        {
            skill_tattack = value;
        }
    }

    public float Skill_time
    {
        get
        {
            return skill_time;
        }

        set
        {
            skill_time = value;
        }
    }

    public float Skill_Dir
    {
        get
        {
            return skill_Dir;
        }

        set
        {
            skill_Dir = value;
        }
    }

    public Buff BuffType
    {
        get
        {
            return buffType;
        }

        set
        {
            buffType = value;
        }
    }

    public string ResName
    {
        get
        {
            return resName;
        }

        set
        {
            resName = value;
        }
    }
}
