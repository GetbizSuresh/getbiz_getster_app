using getbiz_getster_app.Models;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace getbiz_getster_app.Repository.Getster_App_About_Demo
{
    public class Getster_App_About_DemoRespository : IGetster_App_About_DemoRespository
    {
        public readonly Getbizdb_DbContext _DbContext;
        public Getster_App_About_DemoRespository(Getbizdb_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddEditGetsteAppAboutDemo(getster_app_about_demo getster_App_About_Demo)
        {
            Response response = new Response();
            try
            {
                if (getster_App_About_Demo.getster_app_id == 0)
                {
                    _DbContext.getster_app_about_demo.Add(getster_App_About_Demo);
                    _DbContext.SaveChanges();
                    response.Message = "Data Saved successfully !!";
                    response.Status = true;
                }
                else
                {

                    getster_app_about_demo _app_getster_app_about_demo = new getster_app_about_demo();
                     
                    //_app_getster_app_about_demo.getster_app_about_demo_Id = getster_App_About_Demo.getster_app_about_demo_Id;
                    _app_getster_app_about_demo.getster_app_id = getster_App_About_Demo.getster_app_id;
                    _app_getster_app_about_demo.getster_app_demo_video_path = getster_App_About_Demo.getster_app_demo_video_path;
                    _app_getster_app_about_demo.getster_app_attachments_path = getster_App_About_Demo.getster_app_attachments_path;
                    _app_getster_app_about_demo.getster_app_time_stamp_title = getster_App_About_Demo.getster_app_time_stamp_title;
                    _app_getster_app_about_demo.getster_app_time_stamp_description = getster_App_About_Demo.getster_app_time_stamp_description;
                    

                    _DbContext.Attach(_app_getster_app_about_demo);
                    //_DbContext.Entry(_app_getster_app_about_demo).Property(p => p.getster_app_id).IsModified = true;
                    _DbContext.Entry(_app_getster_app_about_demo).Property(p => p.getster_app_demo_video_path).IsModified = true;
                    _DbContext.Entry(_app_getster_app_about_demo).Property(p => p.getster_app_attachments_path).IsModified = true;
                    _DbContext.Entry(_app_getster_app_about_demo).Property(p => p.getster_app_time_stamp_title).IsModified = true;
                    _DbContext.Entry(_app_getster_app_about_demo).Property(p => p.getster_app_time_stamp_description).IsModified = true;
                    //_DbContext.Entry(_app_getster_app_about_demo).Property(p => p.getster_app_id).IsModified = true;
                    _DbContext.Entry(_app_getster_app_about_demo).State = EntityState.Modified;
                    _DbContext.SaveChanges(); 
                    response.Message = "Data Updated successfully !!";
                    response.Status = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = "Data  Saved to failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response DeleteGetsteAppAboutDemo(getster_app_about_demo getster_App_About_Demo)
        {
            Response response = new Response();
            try
            {
                var getster_app_category_and_location = _DbContext.getster_app_about_demo.Where(z => 
                z.getster_app_id == getster_App_About_Demo.getster_app_id).FirstOrDefault();
                _DbContext.getster_app_about_demo.Remove(getster_app_category_and_location);
                _DbContext.SaveChanges();
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


        public Response GetAllGetsteAppAboutDemo()
        {
            Response response = new Response();
            try
            {
                response.Data = _DbContext.getster_app_about_demo.ToList();
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured ! While Fetching  the data !!";
                response.Status = false;
            }
            return response;
        }

        public Response GetGetsteAppAboutDemoById(int getster_app_id)
        {
            Response response = new Response();
            try
            {
                response.Data = _DbContext.getster_app_about_demo.Where(z=>z.getster_app_id == getster_app_id).ToList();
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured ! While Fetching  the data !!";
                response.Status = false;
            }
            return response;
        }
    }
}
