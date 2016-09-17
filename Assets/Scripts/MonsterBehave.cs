/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/9/17 21:46:42
 * 完成时间：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MonsterBehave : IBehave
{
    public void aBloodBehave(ref float blood, float data)
    {
        throw new NotImplementedException();
    }

    public void actBehave(ref float blood, float data)
    {
        PlayerBehave pb = new PlayerBehave();
        pb.mBloodBehave(ref blood, data);
    }

    public void beActedBehave(ref float blood, float data)
    {
        mBloodBehave(ref blood, data);
    }

    public void buffBehave(ref float t_data, int data)
    {
        throw new NotImplementedException();
    }

    public void mBloodBehave(ref float blood, float data)
    {
        blood = blood - data;
    }

    public void skillBehave(ref float blood, float data)
    {
        throw new NotImplementedException();
    }
}

