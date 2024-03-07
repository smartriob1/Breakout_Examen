using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveManager
{
    private static string path = Application.persistentDataPath + "/save.dat";
    private static List<int> records = new List<int>();

    public static void SaveRecord(int pooints)
    {
        if(records.Count == 0)
        {
            records.Add(pooints);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            for (int j = 0; j < records.Count; j++)
            {
                RecordData data = new RecordData(records[j]);

                formatter.Serialize(stream, data);
            }

            stream.Close();
        }
        else
        {
            for (int i = 0; i < records.Count; i++)
            {
                int record = records[i];
                if (pooints > record)
                {
                    record = pooints;
                    records.Remove(i);
                    records.Insert(i, record);
                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream stream = new FileStream(path, FileMode.Create);
                    for (int j = 0; j < records.Count; j++)
                    {
                        RecordData data = new RecordData(records[j]);

                        formatter.Serialize(stream, data);
                    }

                    stream.Close();
                }
            }
        } 
        
    }

    public static List<int> LoadRecords()
    {
        List<int> recordsRet = new List<int>();
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            List<RecordData> recordsData = formatter.Deserialize(stream) as List<RecordData>;  // equivalent to (RecordData)formatter.Deserialize(stream);
            stream.Close();

            for(int i = 0; i < recordsData.Count; i++)
            {
                recordsRet.Add(recordsData[i].GetRecord());
            }
           
        }
        return recordsRet;
    }
}
