/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/9/21 14:33:59
 * 完成时间：
 * 不想说太多，看看吧
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Monster
{
    private int g_id;
    private float g_blood;
    private float g_attack;
    private float g_defend;
    private float g_speed;
    private int g_level;

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
    private MonsterBehave m_behave;

    public Monster()
    {
        m_behave = new MonsterBehave();
    }

    public MonsterBehave Behave
    {
        get
        {
            return m_behave;
        }
    }
}