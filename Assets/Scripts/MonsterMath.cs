/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2015.9.12
 * 完成时间：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MonsterMath : IMathUtil
{
    float a = 20f;
    static float index = 1f;
    public float actAndBD(params float[] param)
    {
        throw new NotImplementedException();
    }

    public float actAndMission(params float[] param)
    {
        if (param[0] <= 0)
            return -1;

        float act = 0f;
        act = 0.25f * param[0] + 0.2f;
        return act;
    }

    public float bloodAndMission(params float[] param)
    {
        if (param[0] <= 0)
            return -1;

        float blood = 0;
        float data = param[0];
        data = (data / 3 % 10 == 0 ? (data / 3 / 10) : 0);//每30关做一次除法运算
        if (data == 0)
        {
            blood = 2.5f * param[0] + (a + data) * index;
        }
        else
        {
            index = data;
            blood = 2.5f * param[0] + (a + data) * index;
        }
        return blood;
    }

    public float addBuff(BUFF _buff, params float[] param)
    {
        float damage = 0;
        if (param[0] < 0)
            return -1;

        switch (_buff._MONSTERBUFF)
        {
            case BUFF.MONSTERBUFF.FIREDAMAGE:
                param[0] = param[1] - param[0];
                break;
            case BUFF.MONSTERBUFF.HARDDAMAGE:
                param[0] = param[1] - param[0];
                break;
            case BUFF.MONSTERBUFF.ICEDAMAGE:
                param[0] = param[1] - param[0];
                break;
            case BUFF.MONSTERBUFF.POISIONDAMAGE:
                param[0] = param[1] - param[0];
                break;
            case BUFF.MONSTERBUFF.NONE:
                param[0] = param[1] - param[0];
                break;
        }
        damage = param[0];
        return damage;
    }
}
