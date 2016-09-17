/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/9/17 20:29:41
 * 完成时间：
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IBehave
{
    void actBehave(ref float blood, float data);
    void beActedBehave(ref float blood, float data);
    void skillBehave(ref float t, float data);
    void mBloodBehave(ref float blood,float data);
    void aBloodBehave(ref float blood, float data);
    void buffBehave(ref float t_data, int data);
}

