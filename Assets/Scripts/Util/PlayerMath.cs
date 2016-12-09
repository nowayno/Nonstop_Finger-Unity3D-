/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/9/13 8:03:37
 * 完成时间：
 * 玩家的数学处理
 * 详情见tellme.txt文件
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
    /// <summary>
    /// 玩家血量和关卡
    /// </summary>
    /// <param name="param">关卡，血量</param>
    /// <returns>修改后的血量</returns>
    public float bloodAndMission(params float[] param)
    {
        float blood = 0;
        if (param[0] < 0)
            return -1;
        blood = (1.25f * param[0] - 0.6f) * 556 / 37.3f + param[1];
        return blood;
    }
    /// <summary>
    /// buff来了
    /// </summary>
    /// <param name="param">当前值，原始值(只会随着关卡改变的和初始值)，buff值</param>
    /// <returns>改变后的值</returns>
    public float addBuff(params float[] param)
    {
        float addBUFF = 0;
        if (param[0] < 0)
            return -1;
        addBUFF = param[0] + param[1] * param[2];
        return addBUFF;
    }
}

