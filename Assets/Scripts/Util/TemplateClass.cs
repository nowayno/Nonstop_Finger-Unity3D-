/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/10/30 10:24:46
 * 完成时间：
 * 模板类
 * 最初是作为委托事件写的一个类，后来不知道为啥不用了
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class TemplateClass<T> : MonoBehaviour
{
    protected delegate void GetNumber(int number);
    protected event GetNumber getNumber_;

    virtual protected void GetNumber_Event(int number)
    {
        getNumber_(number);
    }
}
