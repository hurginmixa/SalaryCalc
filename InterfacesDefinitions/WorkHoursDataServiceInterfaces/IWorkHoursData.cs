using System;

namespace InterfacesDefinitions.WorkHoursDataServiceInterfaces
{
    public interface IWorkHoursData
    {
        int Id { get; }
        
        DateTime Day { get; }

        int Count { get; }

        string Subject { get; }
    }
}