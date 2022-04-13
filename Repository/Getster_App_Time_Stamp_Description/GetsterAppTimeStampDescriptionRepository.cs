using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace getbiz_getster_app.Repository.Getster_App_Time_Stamp_Description
{
    public class GetsterAppTimeStampDescriptionRepository : IGetsterAppTimeStampDescriptionRepository
    {
        public readonly Getbizdb_DbContext _DbContext;
        public GetsterAppTimeStampDescriptionRepository(Getbizdb_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddEditGetsterAppTimeStampDescription(getster_app_about_demo getster_App_About_Demo)
        {
            Response response = new Response();
            try
            {
                if (getster_App_About_Demo.getster_app_id == 0)
                {
                    getster_App_About_Demo.getster_app_time_stamp_description = getster_App_About_Demo.getster_app_time_stamp_description;
                    var obj = _DbContext.getster_app_about_demo.Add(getster_App_About_Demo);
                    _DbContext.SaveChanges();
                    response.Message = "Time Stamp Description Saved successfully !!";
                    response.Status = true;
                }
                else
                {
                    getster_app_about_demo _getster_app_about_demo = new getster_app_about_demo();
                    
                    //_getster_app_about_demo.getster_app_about_demo_Id = getster_App_About_Demo.getster_app_about_demo_Id;
                    _getster_app_about_demo.getster_app_id = getster_App_About_Demo.getster_app_id;
                    _getster_app_about_demo.getster_app_demo_video_path = getster_App_About_Demo.getster_app_demo_video_path;
                    _getster_app_about_demo.getster_app_time_stamp_description = getster_App_About_Demo.getster_app_time_stamp_description;
                    _getster_app_about_demo.getster_app_attachments_path = getster_App_About_Demo.getster_app_attachments_path;


                    _DbContext.Attach(_getster_app_about_demo);
                    _DbContext.Entry(_getster_app_about_demo).Property(p => p.getster_app_id).IsModified = true;
                    _DbContext.Entry(_getster_app_about_demo).Property(p => p.getster_app_demo_video_path).IsModified = true;
                    _DbContext.Entry(_getster_app_about_demo).Property(p => p.getster_app_time_stamp_description).IsModified = true;
                    _DbContext.Entry(_getster_app_about_demo).Property(p => p.getster_app_attachments_path).IsModified = true;
                    _DbContext.Entry(_getster_app_about_demo).State = EntityState.Modified;
                    _DbContext.SaveChanges();

                    response.Message = "Time Stamp Description Updated successfully !!";
                    response.Status = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = "Time Stamp Description failed while add or update the data!!";
                response.Status = false;
            }
            return response;
        }

        public Response DeleteGetsterAppTimeStampDescription(getster_app_about_demo getster_App_About_Demo)
        {
            Response response = new Response();
            try
            {
                var _getster_App_About_Demo = _DbContext.getster_app_about_demo.Where(z => z.getster_app_id ==
                getster_App_About_Demo.getster_app_id).FirstOrDefault();
                _DbContext.getster_app_about_demo.Remove(_getster_App_About_Demo);
                _DbContext.SaveChanges();
                response.Message = "Time Stamp Description Deleted successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured ! While Deleting the data !!";
                response.Status = false;
            }
            return response;
        }

        public Response GetAllGetsterAppTimeStampDescription()
        {
            Response response = new Response();
            try
            {
                response.Data = _DbContext.getster_app_about_demo.ToList();
                response.Message = "Data Deleted successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured ! While Deleting the data !!";
                response.Status = false;
            }
            return response;
        }
    }
}
