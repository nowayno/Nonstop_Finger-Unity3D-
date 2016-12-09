/**
 * 敌人Buff脚本，Buff的作用就在这里体现了 
 **/
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
    //我们给敌人Buff初始化一下吧
    void initBuff()
    {
        buff = new Buff();
        buff.IsEnd = false;
        buff.IsAdd = false;
        buff.IsDoing = true;
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
    //开始计时
    public void startBuff()
    {
        //我用了线程，学艺不深，不知道移动端是否可行
        Thread start = new Thread(buffTime);
        start.Start();
    }

    public void endBuff()
    {
        buff.IsEnd = true;
    }
    //来一场说来就来，说走就走的Buff挂载吧
    bool flag = true;
    void buffTime()
    {
        while (flag)
        {
            //没记错的话，睡眠时间应该是以毫秒为单位，所以咯
            Thread.Sleep((int)(buff.BuffTime * 1000));
            buff.PlayerBuff = Buff.PLAYERBUFF.NONE;
            flag = false;
            buff.IsEnd = true;
            buff.IsDoing = false;
        }
    }
    //下面所有的方法，不是用来判断Buff是否还在，是否已挂载，就是用来销毁自身，获取Buff的状态
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
    public bool isDoing()
    {
        return buff.IsDoing;
    }
    public void isDoing(bool isd)
    {
        buff.IsDoing = isd;
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
