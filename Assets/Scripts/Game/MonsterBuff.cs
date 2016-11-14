using UnityEngine;
using System.Collections;
using System.Threading;

public class MonsterBuff : TemplateClass<MonsterBuff>
{
    Buff buff;
    const int sleepTime = 1000;
    //public Buff Buff
    //{
    //    get
    //    {
    //        return buff;
    //    }
    //}

    public MonsterBuff()
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
                buff.MonsterBuff = Buff.MONSTERBUFF.FIREDAMAGE;
                break;
            case 1:
                buff.MonsterBuff = Buff.MONSTERBUFF.ICEDAMAGE;
                break;
            case 2:
                buff.MonsterBuff = Buff.MONSTERBUFF.POISIONDAMAGE;
                break;
            case 3:
                buff.MonsterBuff = Buff.MONSTERBUFF.HARDDAMAGE;
                break;
            default:
                buff.MonsterBuff = Buff.MONSTERBUFF.NONE;
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
        buff.IsEnd = false;
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
                buff.IsEnd = false;
            }
            if (buff.BuffTime <= 0.9)
            {
                Thread.Sleep((int)(buff.BuffTime * 1000));
                buff.PlayerBuff = Buff.PLAYERBUFF.NONE;
                buff.IsEnd = false;
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
    public void setBuffData(float data)
    {
        buff.BuffData = data;
    }
    public Buff getBuff()
    {
        return buff;
    }
   public void setMonsterBuff(Buff b)
    {
        buff.MonsterBuff = b.MonsterBuff;
    }
    public void destroySelf()
    {
        if (buff.IsEnd)
        {
            buff = null;
        }
    }
}
