/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2015.9.12
 * 完成时间：
 * 一些运算的接口
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IMathUtil
{
    /// 以免后续的麻烦，将参数设置为可变参数，后面的都是如此
    float bloodAndMission(params float[] param);
    float actAndMission(params float[] param);
    float actAndBD(params float[] param);
    float addBuff(params float[] param);
}

