using UnityEngine;
using System.Collections;

public class Util
{
    static Util util;
    public Util getInstance()
    {
        if (util == null)
            util = new Util();
        return util;
    }
}
