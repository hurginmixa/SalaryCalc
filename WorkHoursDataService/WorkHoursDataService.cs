using System.Collections.Generic;
using InterfacesDefinitions.SessionsServiceInterfaces;
using InterfacesDefinitions.WorkHoursDataServiceInterfaces;

namespace WorkHoursDataService
{
    internal class WorkHoursDataService : IWorkHoursDataService
    {
        public void Save()
        {
        }

        public (WorkHoursDataServiceResult Result, IAddingNewWorkHour AddingNewWorkHour) GetAddingNewWorkHour(ISession session)
        {
            throw new System.NotImplementedException();
        }

        public (WorkHoursDataServiceResult Result, IEnumerable<IWorkHoursData> List) GetWorkHourListById(ISession session, int id)
        {
            throw new System.NotImplementedException();
        }

        public (WorkHoursDataServiceResult Result, IEnumerable<IWorkHoursData> List) GetWorkHourListForAll(ISession session)
        {
            throw new System.NotImplementedException();
        }
    }
}
