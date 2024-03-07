[System.Serializable]
public class RecordData
{
   int record;

    public RecordData(int record)
    {
         this.record = record;
    }

    public int GetRecord()
    {
        return record;
    }

    public void SetRecord(int record)
    {
        this.record = record;
    }
}
