/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2015.9.7
 * 完成时间：
 * 工具类
 */
using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System;

public class Util
{
    static Util util;
#if UNITY_ANDROID
    //string filename = @"/data/data/com.crazyoung.Nonstop_Finger/raw/";
    string filename = new AndroidJavaClass("android.os.Environment").CallStatic<AndroidJavaObject>("getExternalStorageDirectory").Call<string>("getAbsolutePath") + @"\";
#elif UNITY_STANDALONE_WIN
    //一种是编辑的时候用，一种是生成PC端用的
    string filename = @"F:\allprojects\unitypro\Nonstop_Finger\Assets\Data\";
    //string filename = System.IO.Directory.GetCurrentDirectory() + @"\Data\";
#endif
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
    /// <typeparam name="T">传入类型</typeparam>
    /// <param name="t">对象</param>
    /// <returns>是否成功</returns>
    public bool writeXML<T>(T t)
    {
        bool flag = false;
        string class_name = t.GetType().Name;
        class_name += ".xml";
#if UNITY_ANDROID
        class_name = class_name.ToLower();
#endif
        using (Stream stream = new FileStream(filename + class_name, FileMode.Create))
        {
            XmlSerializer xmlFomart = new XmlSerializer(t.GetType(), new Type[] { t.GetType() });
            xmlFomart.Serialize(stream, t);
            stream.Flush();
            stream.Close();
        }
        return flag;
    }
    /// <summary>
    /// 写入xml文件
    /// </summary>
    /// <typeparam name="T">传入类型</typeparam>
    /// <param name="t">传入对象</param>
    /// <param name="name">名字</param>
    /// <param name="isNew">如果为false，则根据name来创建文件名，为true则根据类型名字创建</param>
    /// <returns></returns>
    public bool writeXML<T>(T t, string name, bool isNew = false)
    {
        bool flag = false;

        if (isNew == false)
        {
            name += ".xml";
#if UNITY_ANDROID
            name = name.ToLower();
#endif
            name = filename + name;
        }
        else
        {
            string class_name = t.GetType().Name;
            class_name += ".xml";
#if UNITY_ANDROID
            class_name = class_name.ToLower();
#endif
            name = name + @"\" + class_name;
        }
        using (Stream stream = new FileStream(name, FileMode.Create))
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
#if UNITY_ANDROID
        class_name = class_name.ToLower();
#endif
        using (Stream stream = new FileStream(filename + class_name, FileMode.Open))
        {
            try
            {
                stream.Position = 0;
                XmlSerializer xmlFomart = new XmlSerializer(t.GetType(), new Type[] { t.GetType() });
                t = (T)xmlFomart.Deserialize(stream);
                stream.Flush();
                stream.Close();
            }
            catch (Exception e)
            {
                DoAction.getInstance().writeData<string>(e.Message, filename, true);
            }
        }
        return t;
    }
    /// <summary>
    /// 读取xml文件
    /// </summary>
    /// <typeparam name="T">传入类型</typeparam>
    /// <param name="t">传入对象</param>
    /// <param name="name">名字</param>
    /// <param name="isNew">如果为false，则根据name来查找文件名，为true则用类型查找</param>
    /// <returns></returns>
    public T readXML<T>(T t, string name, bool isNew = false)
    {
        if (isNew == false)
        {
            name += ".xml";
#if UNITY_ANDROID
            name = name.ToLower();
#endif
            name = filename + name;
        }
        else
        {
            string class_name = t.GetType().Name;
            class_name += ".xml";
#if UNITY_ANDROID
            class_name = class_name.ToLower();
#endif
            Debug.Log(class_name);
            name = name + @"\" + class_name;
        }
        using (Stream stream = new FileStream(name, FileMode.Open))
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
