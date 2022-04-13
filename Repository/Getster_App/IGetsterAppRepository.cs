//using static getbiz_getster_app.getster_app_master_parent;

namespace getbiz_getster_app.Repository.Getster_App
{
    public interface IGetsterAppRepository
    {
        Response2  GetAllAppsForGetster();
        
        Response GetAllAppsForGetsterById(int getster_app_id);
        Response Update_Gester_App_Development_Status(int gesterId,bool publishKey);
        Response AddEditGetsterApp(getster_app_master_Fetchdata getster_app_master_parent);
        Response GetAllGetsterAppAuditTrail();
    }
}
