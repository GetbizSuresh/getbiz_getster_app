using getbiz_getster_app.Models;

namespace getbiz_getster_app.Repository.Getster_App_Communication
{
    public interface IGetsterAppCommunicationRepository
    {
        Response GetAllCommunicationData(int getster_id);
       // Response GetAllCommunicationDataById(int communication_ID, int getster_id);
        Response SaveCommunicationData(getster_app_communication getster_app_communication);
        Response DeleteCommunicationData(int getster_id);
       Response DeleteCommunicationDataById(int communication_ID, int getster_id);
        Response UpdateCommunicationData(getster_app_communication getster_app_communication);
    }
}