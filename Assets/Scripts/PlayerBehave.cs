/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/9/17 20:52:00
 * 完成时间：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
class PlayerBehave : IBehave
{
    public void aBloodBehave<T>(ref T t, float data)
    {
        throw new NotImplementedException();
    }

    public void actBehave<T>(ref T t, float data)
    {
        throw new NotImplementedException();
    }

    public void beActedBehave<T>(ref T t, float data)
    {
        throw new NotImplementedException();
    }

    public void buffBehave(ref float t_date, int data)
    {
        System.Random rand = new System.Random();
        int m_num;
        float r_num = 0;
        BUFF _buff = new BUFF();
        switch (data)
        {
            case 0://速度提升
                _buff._PLAYERBUFF = BUFF.PLAYERBUFF.ADDSPEED;
                m_num = rand.Next(3, 8);
                r_num =(float)Convert.ToDecimal((rand.NextDouble() * m_num + m_num).ToString("0.00"));
                break;
            case 1://防御提升
                _buff._PLAYERBUFF = BUFF.PLAYERBUFF.ADDDEFEND;
                m_num = rand.Next(2, 5);
                r_num = (float)Convert.ToDecimal((rand.NextDouble() * m_num + m_num).ToString("0.00"));
                break;
            case 2://攻击力提升
                _buff._PLAYERBUFF = BUFF.PLAYERBUFF.ADDACT;
                m_num = rand.Next(3, 10);
                r_num = (float)Convert.ToDecimal((rand.NextDouble() * m_num + m_num).ToString("0.00"));
                break;
            case 3://血量BUFF
                _buff._PLAYERBUFF = BUFF.PLAYERBUFF.ADDBLOOD;
                m_num = rand.Next(5, 8);
                r_num = (float)Convert.ToDecimal((rand.NextDouble() * m_num + m_num).ToString("0.00"));
                break;
            case 4://技能攻击力
                _buff._PLAYERBUFF = BUFF.PLAYERBUFF.ADDSKILLACT;
                m_num = rand.Next(3, 5);
                r_num = (float)Convert.ToDecimal((rand.NextDouble() * m_num + m_num).ToString("0.00"));
                break;
            case 5://技能冷却时间
                _buff._PLAYERBUFF = BUFF.PLAYERBUFF.CD;
                m_num = rand.Next(3, 10);
                r_num = (float)Convert.ToDecimal((rand.NextDouble() * m_num + m_num).ToString("0.00"));
                break;
        }
        Debug.Log("rand:" + r_num);
        PlayerMath pm = new PlayerMath();
        t_date = pm.addBuff(_buff, t_date, r_num);
    }

    public void mBloodBehave<T>(ref T t, float data)
    {
        throw new NotImplementedException();
    }

    public void skillBehave<T>(ref T t, float data)
    {
        throw new NotImplementedException();
    }
}

