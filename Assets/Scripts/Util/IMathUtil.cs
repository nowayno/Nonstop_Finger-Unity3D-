﻿/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2015.9.12
 * 完成时间：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IMathUtil
{
    float bloodAndMission(params float[] param);
    float actAndMission(params float[] param);
    float actAndBD(params float[] param);
    float addBuff(BUFF _buff, params float[] param);
}
