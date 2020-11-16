namespace AccessToData
{
    public interface IPersonDataListSerializer
    {
        PersonDataList Load();
        
        void Save(PersonDataList personDataList);
    }
}