using getbiz_getster_app.Models;
using System;

namespace getbiz_getster_app.Repository.Getster_App_Communication
{
    public class GetsterAppCommunicationRepository : IGetsterAppCommunicationRepository
    {
        public readonly Getbizdb_DbContext _DbContext;
        public GetsterAppCommunicationRepository(Getbizdb_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response DeleteCommunicationData(int getster_id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                getSetDatabase.CreateGetsterAppCommunicationTableDyanmically(getster_id, 0,"","","Delete");
                response.Status = true;
                response.Message = "Data Deleted Successfully !!";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error Occured ! while  deleting the data !!";
            }
            return response;
        }

        public Response DeleteCommunicationDataById(int getster_id, int communication_ID)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                getSetDatabase.CreateGetsterAppCommunicationTableDyanmically(communication_ID, getster_id, "","", "DeleteById");
                response.Status = true;
                response.Message = "Data Deleted Successfully !!";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error Occured ! while  deleting the data !!";
            }
            return response;
        }


        public Response GetAllCommunicationData(int gester_app_id)
        {
            Response response = new Response();
            try
            {
                try
                {
                    GetSetDatabase getSetDatabase = new GetSetDatabase();
                    var result = getSetDatabase.CreateGetsterAppCommunicationTableDyanmically(gester_app_id, 0, "","", "GetAll");
                    response = result;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = "Error occured fetching the data !!";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }

        //public Response GetAllCommunicationDataById(int communication_ID,int gester_app_Id)
        //{
        //    Response response = new Response();
        //    try
        //    {
        //        try
        //        {
        //            GetSetDatabase getSetDatabase = new GetSetDatabase();
        //            var result = getSetDatabase.CreateGetsterAppCommunicationTableDyanmically(gester_app_Id, communication_ID, "", "","GetByID");
        //            response = result;
        //        }
        //        catch (Exception ex)
        //        {
        //            response.Status = false;
        //            response.Message = "Error occured ! white fething the data";
        //        }
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = "Error, while fetching the data !!";
        //        response.Status = false;
        //    }
        //    return response;
        //}

        public Response SaveCommunicationData(getster_app_communication getster_app_communication)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.CreateGetsterAppCommunicationTableDyanmically(
                    getster_app_communication.getster_id,
                    0,
                    getster_app_communication.communication_timestamp,
                    getster_app_communication.communication_text,
                    
                    "Insert");
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error occured ! while saving the data";
            }
            return response;
        }

        public Response UpdateCommunicationData(getster_app_communication getster_app_communication)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.CreateGetsterAppCommunicationTableDyanmically(getster_app_communication.getster_id, 
                    getster_app_communication.communication_id,
                    getster_app_communication.communication_timestamp,
                    getster_app_communication.communication_text,
                    
                    "EditCommunication");
                response.Status = result.Status;
                response.Message = result.Message;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error, while updating the data !!";
            }
            return response;
        }
    }
}
