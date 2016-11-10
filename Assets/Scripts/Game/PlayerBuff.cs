﻿using UnityEngine;
using System.Collections;
using System.Threading;

public class PlayerBuff : TemplateClass<PlayerBuff>
{
    const int sleepTime = 1000;

    Buff buff;

    //public Buff Buff
    //{
    //    get
    //    {
    //        return buff;
    //    }
    //}

    public PlayerBuff()
    {
        initBuff();
    }

    void initBuff()
    {
        buff = new Buff();
        buff.BuffTime = Random.Range(1.0f, 5.0f);
        buff.BuffMission = Random.Range(1.0f, 5.0f);
        buff.BuffData = Random.Range(0.1f, 1.0f);
        int r = Random.Range(0, 6);
        switch (r)
        {
            case 0:
                buff.PlayerBuff = Buff.PLAYERBUFF.ADDSPEED;
                break;
            case 1:
                buff.PlayerBuff = Buff.PLAYERBUFF.ADDDEFEND;
                break;
            case 2:
                buff.PlayerBuff = Buff.PLAYERBUFF.ADDACT;
                break;
            case 3:
                buff.PlayerBuff = Buff.PLAYERBUFF.ADDBLOOD;
                break;
            case 4:
                buff.PlayerBuff = Buff.PLAYERBUFF.ADDSKILLACT;
                break;
            case 5:
                buff.PlayerBuff = Buff.PLAYERBUFF.CD;
                break;
            default:
                buff.PlayerBuff = Buff.PLAYERBUFF.NONE;
                break;
        }
    }

    public void startBuff()
    {
        Thread start = new Thread(buffTime);
        start.Start();
    }

    public void endBuff()
    {
        buff.IsEnd = true;
    }

    void buffTime()
    {
        while (buff.IsEnd)
        {
            --buff.BuffTime;

            Thread.Sleep(sleepTime);
            if (buff.BuffTime <= 0)
            {
                buff.PlayerBuff = Buff.PLAYERBUFF.NONE;
                buff.IsEnd = true;
            }
            if (buff.BuffTime <= 0.9)
            {
                Thread.Sleep((int)(buff.BuffTime * 1000));
                buff.PlayerBuff = Buff.PLAYERBUFF.NONE;
                buff.IsEnd = true;
            }
        }
    }

    public bool isEnd()
    {
        return buff.IsEnd;
    }
    public void isEnd(bool end)
    {
        buff.IsEnd = end;
    }
    public bool isAdd()
    {
        return buff.IsAdd;
    }
    public void isAdd(bool add)
    {
        buff.IsAdd = add;
    }
    public float getBuffData()
    {
        return buff.BuffData;
    }
    public Buff getBuff()
    {
        return buff;
    }
    public void destroySelf()
    {
        if (buff.IsEnd)
        {
            buff = null;
        }
    }
}
