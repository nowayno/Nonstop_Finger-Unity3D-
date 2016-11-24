/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/11/24 16:54:21
 * 完成时间：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class OtherCreate
{
    public void usingSkill(params int[] ID)
    {
        DoAction.getInstance().writeData(ID,"UsingSkill");
    }
}