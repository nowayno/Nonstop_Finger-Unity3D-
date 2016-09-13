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
                break;
            case BUFF.PLAYERBUFF.ADDBLOOD:
                break;
            case BUFF.PLAYERBUFF.ADDDEFEND:
                break;
            case BUFF.PLAYERBUFF.ADDSKILLACT:
                break;
            case BUFF.PLAYERBUFF.ADDSPEED:
                break;
        }

        return addBUFF;
    }
}

