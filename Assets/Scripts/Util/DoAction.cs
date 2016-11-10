/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/9/16 11:57:34
 * 完成时间：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class DoAction
{
    private DoAction() { }
    static DoAction _action;
    static public DoAction getInstance()
    {
        if (_action == null)
            _action = new DoAction();
        return _action;
    }

    public bool writeData<T>(T t)
    {
        bool flag = false;
        Util.getInstance().writeXML<T>(t);
        return flag;
    }

    public T readData<T>(T t)
    {
        return Util.getInstance().readXML<T>(t);
    }

    public float bloodAndMission(int which, params float[] param)
    {
        float blood = 0;
        IMathUtil imathutil;
        if (which == 0)
        {
            imathutil = new PlayerMath();
            blood = imathutil.bloodAndMission(param);
        }
        else if (which == 1)
        {
            imathutil = new MonsterMath();
            blood = imathutil.bloodAndMission(param);
        }
        else
        {
            blood = -1;
        }
        return blood;
    }
    public float actAndMission(int which, params float[] param)
    {
        float act = 0;
        IMathUtil imathutil;
        if (which == 0)
        {
            imathutil = new PlayerMath();
            act = imathutil.actAndMission(param);
        }
        else if (which == 1)
        {
            imathutil = new MonsterMath();
            act = imathutil.actAndMission(param);
        }
        else
        {
            act = -1;
        }
        return act;
    }
    public float actAndBD(int which, params float[] param)
    {
        float act = 0;
        IMathUtil imathutil;
        if (which == 0)
        {
            imathutil = new PlayerMath();
            act = imathutil.actAndBD(param);
        }
        else if (which == 1)
        {
            imathutil = new MonsterMath();
            act = imathutil.actAndBD(param);
        }
        else
        {
            act = -1;
        }
        return act;
    }
    public float addBuff(int which, params float[] param)
    {
        float buff = 0;
        IMathUtil imathutil;
        if (which == 0)
        {
            imathutil = new PlayerMath();
            buff = imathutil.addBuff(param);
        }
        else if (which == 1)
        {
            imathutil = new MonsterMath();
            buff = imathutil.addBuff(param);
        }
        else
        {
            buff = -1;
        }
        return buff;
    }

    public void gameObjectBuff(GameObject go, Buff _buff, params float[] param)
    {
        PlayerScript ps;
        MonsterScript ms;
        if (go.tag == "Player")
        {
            ps = go.GetComponent<PlayerScript>();
            ps.buffChange(_buff, false, param);
        }
        else
        {
            ms = go.GetComponent<MonsterScript>();
        }

    }

    public float beAttacked(ref float blood, float damage)
    {
        blood -= damage;
        Debug.Log("p_blood" + blood);
        if (blood <= 0)
        {
            return -1;
        }
        return 0;
    }
}

//public float Attack()
//{

//}

