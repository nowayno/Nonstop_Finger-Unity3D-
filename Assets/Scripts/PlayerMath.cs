/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/9/13 8:03:37
 * 完成时间：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PlayerMath : IMathUtil
{
    public float actAndBD(params float[] param)
    {
        throw new NotImplementedException();
    }

    public float actAndMission(params float[] param)
    {
        throw new NotImplementedException();
    }

    public float bloodAndMission(params float[] param)
    {
        float blood = 0;
        if (param[0] < 0)
            return -1;
        blood = (1.25f * param[0] + 0.2f) * 37.3f / 556;
        return blood;
    }

    public float addBuff(BUFF _buff, params float[] param)
    {
        float addBUFF = 0;
        if (param[0] < 0)
            return -1;
        switch (_buff._PLAYERBUFF)
        {
            case BUFF.PLAYERBUFF.ADDACT:
                addBUFF = param[0] + param[0] * param[1];
                break;
            case BUFF.PLAYERBUFF.ADDBLOOD:
                addBUFF = param[0] + param[0] * param[1];
                break;
            case BUFF.PLAYERBUFF.ADDDEFEND:
                addBUFF = param[0] + param[0] * param[1];
                break;
            case BUFF.PLAYERBUFF.ADDSKILLACT:
                addBUFF = param[0] + param[0] * param[1];
                break;
            case BUFF.PLAYERBUFF.ADDSPEED:
                addBUFF = param[0] + param[0] * param[1];
                break;
            case BUFF.PLAYERBUFF.CD:
                addBUFF = param[0] + param[0] * param[1];
                break;
            case BUFF.PLAYERBUFF.NONE:
                break;
        }

        return addBUFF;
    }
}

