using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System;

public class Util
{
    static Util util;
    string filename = @"F:\allprojects\unitypro\Nonstop_Finger\Assets\Resources\";
    /// <summary>
    /// 获取单例
    /// </summary>
    /// <returns>单例</returns>
    static public Util getInstance()
    {
        if (util == null)
            util = new Util();
        return util;
    }

    /// <summary>
    /// 写入xml文件
    /// </summary>
    /// <param name="obj">对象</param>
    /// <returns>是否成功</returns>
    public bool writeXML<T>(T t)
    {
        bool flag = false;
        string class_name = t.GetType().Name;
        class_name += ".xml";
        using (Stream stream = new FileStream(filename + class_name, FileMode.Create))
        {
            XmlSerializer xmlFomart = new XmlSerializer(t.GetType(), new Type[] { t.GetType() });
            xmlFomart.Serialize(stream, t);
            stream.Flush();
            stream.Close();
        }
        return flag;
    }

    public T readXML<T>(T t)
    {
        string class_name = t.GetType().Name;
        class_name += ".xml";
        return t;
    }
}
