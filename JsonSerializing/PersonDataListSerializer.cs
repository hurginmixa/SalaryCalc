using System.IO;
using AccessToData;
using InterfacesDefinitions.PersonsServiceInterfaces;

namespace JsonSerializingService
{
    public class PersonDataListSerializer : IPersonDataListSerializer
    {
        public PersonDataList Load()
        {
            string fileName = GetFileName();

            if (!File.Exists(fileName))
            {
                return new PersonDataList {DataList = new[] {new PersonData {FirstName = "a", LastName = "b", Role = Role.Manager}}};
            }

            return JsonSerializer.Deserialize<PersonDataList>(File.ReadAllText(fileName));
        }

        public void Save(PersonDataList personDataList)
        {
            string json = JsonSerializer.FormatJson(JsonSerializer.Serialize(personDataList));

            File.WriteAllText(GetFileName(), json);
        }

        private static string GetFileName() => Tools.CombineFileName("Persons.json");
    }
}