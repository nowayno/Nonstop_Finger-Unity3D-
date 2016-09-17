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
    void actBehave<T>(ref T t);
    void beActedBehave<T>(ref T t);
    void skillBehave<T>(ref T t);
    void mBloodBehave<T>(ref T t);
    void aBloodBehave<T>(ref T t);
    void buffBehave<T>(ref T t);
}

