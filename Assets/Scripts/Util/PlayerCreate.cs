﻿/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/11/24 16:52:11
 * 完成时间：
 * 玩家数据创建
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class PlayerCreate
{
    static PlayerCreate _pc;
    public static PlayerCreate getInstance()
    {
        if (_pc == null)
            _pc = new PlayerCreate();
        return _pc;
    }
    public void playerCreate()
    {
        Player p = new Player();
        p.Id = 1;
        p.Blood = 30;
        p.Defend = 10;
        p.Attack = 10;
        p.Speed = 1;
        p.Level = 1;
        DoAction.getInstance().writeData<Player>(p, "Player");
    }
}
