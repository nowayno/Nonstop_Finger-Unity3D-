/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/11/24 16:54:21
 * 完成时间：
 * 其他数据信息创建
 * 除了玩家和敌人需要单独创建
 * 现在只对选择技能信息单独创建
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class OtherCreate
{
    static OtherCreate _oc;
    public static OtherCreate getInstance()
    {
        if (_oc == null)
            _oc = new OtherCreate();
        return _oc;
    }
    private OtherCreate() { }
    public void usingSkill(params int[] ID)
    {
        DoAction.getInstance().writeData(ID,"UsingSkill");
    }
}