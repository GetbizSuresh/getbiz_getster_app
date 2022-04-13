using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_getster_app.Repository.Get_Categories_Getster_Apps
{
    public interface IGetCategoriesGetsterAppsRepository
    {
        Response2 GetCategoriesGetsterAppsByPath(string Path,string Id);

    }
}
