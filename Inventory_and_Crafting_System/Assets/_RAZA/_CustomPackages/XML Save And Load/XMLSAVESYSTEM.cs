//----------------------------------------------
//              XML: XML Save Manager
//          Copyright © 2017 Raza Butt
//                  Version 1.0
//----------------------------------------------


using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;


/// <summary>
/// XML DataClass Manager to Save Load and Clear the data of Serializeable Class objects
/// </summary>
public static class XMLSAVESYSTEM
{
    #region XMLDataBase Functions

    /// <summary>
    /// Deletes the specified File form Application Data
    /// </summary>
    /// <param name="fileName">Name of File with Extension e.g. playerData.xml</param>
    public static void Delete(string fileName)
    {
        File.Delete(Application.persistentDataPath + "/" + fileName);
    }


    /// <summary>
    /// Loads the file specified of the specified object
    /// </summary>
    /// <typeparam name="T">The Type of class, class should be serializeable</typeparam>
    /// <param name="obj">The class object you want to save</param>
    /// <param name="fileName">Name of File with Extension e.g. playerData.xml</param>
    /// <returns></returns>
    public static T Load<T>(T obj, string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(obj.GetType());
        FileStream stream = new FileStream(Application.persistentDataPath + "/" + fileName, FileMode.Open);
        T toReturn = (T)serializer.Deserialize(stream);
        stream.Close();
        return toReturn;
    }

    /// <summary>
    /// Saves the file specified of the specified object
    /// </summary>
    /// <typeparam name="T">The Type of class, class should be serializeable</typeparam>
    /// <param name="obj">The class object you want to save</param>
    /// <param name="fileName">Name of File with Extension e.g. playerData.xml</param>
    public static void Save<T>(T obj, string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(obj.GetType());
        string filename = Application.persistentDataPath + "/" + fileName;
        var encoding = Encoding.GetEncoding("UTF-8");

        using (StreamWriter stream = new StreamWriter(filename, false, encoding))
        {
            serializer.Serialize(stream, obj);
            stream.Close();
        }
    }
    #endregion
}
