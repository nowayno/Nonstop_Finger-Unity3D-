/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/11/24 16:49:13
 * 完成时间：
 * 敌人数据生成
 * 有时候敌人信息没了，我们得再生成一遍
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MonsterCreate
{
    public void m01Create()
    {
        Monster m = new Monster();
        m.Id = 1;
        m.Blood = 22.5f;
        m.Attack = 0.45f;
        m.Defend = 0;
        m.Speed = 1.5f;
        DoAction.getInstance().writeData<Monster>(m, "Monster01");
    }
    public void m02Create()
    {
        Monster m = new Monster();
        m.Id = 2;
        m.Blood = 22.5f;
        m.Attack = 0.45f;
        m.Defend = 0;
        m.Speed = 1f;
        DoAction.getInstance().writeData<Monster>(m, "Monster02");
    }
    public void m03Create()
    {
        Monster m = new Monster();
        m.Id = 3;
        m.Blood = 22.5f;
        m.Attack = 0.45f;
        m.Defend = 0;
        m.Speed = 2f;
        DoAction.getInstance().writeData<Monster>(m, "Monster03");
    }
    public void m04Create()
    {
        Monster m = new Monster();
        m.Id = 4;
        m.Blood = 22.5f;
        m.Attack = 0.45f;
        m.Defend = 0;
        m.Speed = 1.3f;
        DoAction.getInstance().writeData<Monster>(m, "Monster04");
    }
    public void m05Create()
    {
        Monster m = new Monster();
        m.Id = 5;
        m.Blood = 22.5f;
        m.Attack = 0.45f;
        m.Defend = 0;
        m.Speed = 0.8f;
        DoAction.getInstance().writeData<Monster>(m, "Monster05");
    }
}
