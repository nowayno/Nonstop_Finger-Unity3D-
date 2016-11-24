/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2015.9.7
 * 完成时间：
 */
using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System;

public class Util
{
    static Util util;
    string filename = @"F:\allprojects\unitypro\Nonstop_Finger\Assets\Data\";
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
    /// 读取xml文件
    /// </summary>
    /// <typeparam name="T">传入类型</typeparam>
    /// <param name="t">对象</param>
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
    public bool writeXML<T>(T t, string name)
    {
        bool flag = false;
        name += ".xml";
        using (Stream stream = new FileStream(filename + name, FileMode.Create))
        {
            stream.Position = 0;
            XmlSerializer xmlFomart = new XmlSerializer(t.GetType(), new Type[] { t.GetType() });
            xmlFomart.Serialize(stream, t);
            stream.Flush();
            stream.Close();
        }
        return flag;
    }

    /// <summary>
    /// 读取xml文件
    /// </summary>
    /// <typeparam name="T">传入类型</typeparam>
    /// <param name="t">对象</param>
    /// <returns>返回类型</returns>
    public T readXML<T>(T t)
    {
        string class_name = "";
        class_name = t.GetType().Name;
        class_name += ".xml";
        using (Stream stream = new FileStream(filename + class_name, FileMode.Open))
        {
            stream.Position = 0;
            XmlSerializer xmlFomart = new XmlSerializer(t.GetType(), new Type[] { t.GetType() });
            t = (T)xmlFomart.Deserialize(stream);
            stream.Flush();
            stream.Close();
        }
        return t;
    }
    public T readXML<T>(T t, string name)
    {
        name += ".xml";
        using (Stream stream = new FileStream(filename + name, FileMode.Open))
        {
            stream.Position = 0;
            XmlSerializer xmlFomart = new XmlSerializer(t.GetType(), new Type[] { t.GetType() });
            t = (T)xmlFomart.Deserialize(stream);
            stream.Flush();
            stream.Close();
        }
        return t;
    }
}
