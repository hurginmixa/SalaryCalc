using System;
using System.Collections.Generic;
using InterfacesDefinitions.SessionsServiceInterfaces;

namespace InterfacesDefinitions.WorkHoursDataServiceInterfaces
{
    public interface IWorkHoursDataService
    {
        void Save();

        (WorkHoursDataServiceResult Result, IAddingNewWorkHour AddingNewWorkHour) GetAddingNewWorkHour(ISession session);

        (WorkHoursDataServiceResult Result, IEnumerable<IWorkHoursData> List) GetWorkHourListById(ISession session, int id);

        (WorkHoursDataServiceResult Result, IEnumerable<IWorkHoursData> List) GetWorkHourListForAll(ISession session);
    }

    public interface IAddingNewWorkHour
    {
        (WorkHoursDataServiceResult Result, IWorkHoursData Data) AddWorkHour(DateTime day, int value, string subject);
    }

    public enum WorkHoursDataServiceResult
    {
        Success,   
        AccessDenied,
    }
}
