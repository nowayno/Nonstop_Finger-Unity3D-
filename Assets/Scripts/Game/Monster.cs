/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/9/21 14:33:59
 * 完成时间：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Monster : GameCharator
{
    private int m_id;
    private float m_blood;
    private float m_attack;
    private float m_defend;
    private float m_speed;

    public int Id
    {
        get
        {
            return m_id;
        }

        set
        {
            m_id = value;
        }
    }

    public float Blood
    {
        get
        {
            return m_blood;
        }

        set
        {
            m_blood = value;
        }
    }

    public float Attack
    {
        get
        {
            return m_attack;
        }

        set
        {
            m_attack = value;
        }
    }

    public float Defend
    {
        get
        {
            return m_defend;
        }

        set
        {
            m_defend = value;
        }
    }

    public float Speed
    {
        get
        {
            return m_speed;
        }

        set
        {
            m_speed = value;
        }
    }
}