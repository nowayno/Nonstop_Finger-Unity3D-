/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/11/24 14:17:27
 * 完成时间：
 * 技能数值创建
 * 丢了，就在创建
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class SkillCreat
{
    public SkillCreat() { }
    public void skill01Create()
    {
        Skill s = new Skill();
        s.Skill_id = 1;
        s.Skill_name = "no.1";
        s.Skill_attack = 9;
        s.Skill_CD = 3;
        s.Skill_Dir = 10;
        s.BuffType = new Buff();
        s.BuffType.MonsterBuff = Buff.MONSTERBUFF.FIREDAMAGE;
        s.ResName = @"F:\allprojects\unitypro\Nonstop_Finger\Assets\Data\skill01.jpg";
        DoAction.getInstance().writeData<Skill>(s, "Skill01");
    }
    public void skill02Create()
    {
        Skill s = new Skill();
        s.Skill_id = 2;
        s.Skill_name = "no.2";
        s.Skill_attack = 10;
        s.Skill_CD = 5;
        s.Skill_Dir = 10;
        s.BuffType = new Buff();
        s.BuffType.MonsterBuff = Buff.MONSTERBUFF.ICEDAMAGE;
        s.ResName = @"F:\allprojects\unitypro\Nonstop_Finger\Assets\Data\skill02.jpg";
        DoAction.getInstance().writeData<Skill>(s, "Skill02");
    }
    public void skill03Create()
    {
        Skill s = new Skill();
        s.Skill_id = 3;
        s.Skill_name = "no.3";
        s.Skill_attack = 9.5f;
        s.Skill_CD = 2.3f;
        s.Skill_Dir = 10; s.BuffType = new Buff();
        s.BuffType.MonsterBuff = Buff.MONSTERBUFF.POISIONDAMAGE;
        s.ResName = @"F:\allprojects\unitypro\Nonstop_Finger\Assets\Data\skill03.jpg";
        DoAction.getInstance().writeData<Skill>(s, "Skill03");
    }
    public void skill04Create()
    {
        Skill s = new Skill();
        s.Skill_id = 4;
        s.Skill_name = "no.4";
        s.Skill_attack = 8;
        s.Skill_CD = 2;
        s.Skill_Dir = 10; s.BuffType = new Buff();
        s.BuffType.MonsterBuff = Buff.MONSTERBUFF.HARDDAMAGE;
        s.ResName = @"F:\allprojects\unitypro\Nonstop_Finger\Assets\Data\skill03.jpg";
        DoAction.getInstance().writeData<Skill>(s, "Skill04");
    }
    public void skill05Create()
    {
        Skill s = new Skill();
        s.Skill_id = 5;
        s.Skill_name = "no.5";
        s.Skill_attack = 10;
        s.Skill_CD = 5;
        s.Skill_Dir = 10; s.BuffType = new Buff();
        s.BuffType.MonsterBuff = Buff.MONSTERBUFF.FIREDAMAGE;
        s.ResName = @"";
        DoAction.getInstance().writeData<Skill>(s, "Skill05");
    }
    public void skill06Create()
    {
        Skill s = new Skill();
        s.Skill_id = 6;
        s.Skill_name = "no.6";
        s.Skill_attack = 12.5f;
        s.Skill_CD = 7;
        s.Skill_Dir = 10; s.BuffType = new Buff();
        s.BuffType.MonsterBuff = Buff.MONSTERBUFF.FIREDAMAGE;
        s.ResName = @"";
        DoAction.getInstance().writeData<Skill>(s, "Skill06");
    }
    public void skill07Create()
    {
        Skill s = new Skill();
        s.Skill_id = 7;
        s.Skill_name = "no.7";
        s.Skill_attack = 11;
        s.Skill_CD = 6;
        s.Skill_Dir = 10; s.BuffType = new Buff();
        s.BuffType.MonsterBuff = Buff.MONSTERBUFF.FIREDAMAGE;
        s.ResName = @"";
        DoAction.getInstance().writeData<Skill>(s, "Skill07");
    }
    public void skill08Create()
    {
        Skill s = new Skill();
        s.Skill_id = 8;
        s.Skill_name = "no.8";
        s.Skill_attack = 12;
        s.Skill_CD = 7.5f;
        s.Skill_Dir = 10; s.BuffType = new Buff();
        s.BuffType.MonsterBuff = Buff.MONSTERBUFF.FIREDAMAGE;
        s.ResName = @"";
        DoAction.getInstance().writeData<Skill>(s, "Skill08");
    }
}
