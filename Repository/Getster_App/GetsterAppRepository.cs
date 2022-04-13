using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
//using static getbiz_getster_app.getster_app_master_parent;

namespace getbiz_getster_app.Repository.Getster_App
{
    public class GetsterAppRepository : IGetsterAppRepository
    {
        private IConfiguration _configuration;

        public readonly Getbizdb_DbContext _DbContext;
        public GetsterAppRepository(Getbizdb_DbContext DbContext,IConfiguration configuration)
        {
            _DbContext = DbContext;
            _configuration = configuration;

        }

        public Response AddEditGetsterApp(getster_app_master_Fetchdata getster_app_master_parent)
        {
            Response response = new Response();

            try
            {
                if (getster_app_master_parent.getster_app_id == 0)
                {
                    getster_app_master getster_App_Master = new getster_app_master
                    {
                        getster_app_icon_image = getster_app_master_parent.getster_app_icon_image,
                        getster_app_icon_name = getster_app_master_parent.getster_app_icon_name,
                        getster_app_development_status = getster_app_master_parent.getster_app_development_status,
                        getster_app_title_bar_name= getster_app_master_parent.getster_app_title_bar_name,
                        getster_app_name= getster_app_master_parent.getster_app_name
                    };

                    //getster_app_names getster_App_Names = new getster_app_names
                    //{
                    //    getster_app_name = getster_app_master_parent.getster_app_names.getster_app_name,
                    //    getster_app_title_bar_name = getster_app_master_parent.getster_app_names.getster_app_title_bar_name,
                    //};

                    var obj = _DbContext.getster_app_master.Add(getster_App_Master);
                 //   var obj2 = _DbContext.getster_app_names.Add(getster_App_Names);

                    _DbContext.SaveChanges();

                    saveImage(convertImage(getster_app_master_parent.getsterapp_upload_image), getster_App_Master.getster_app_icon_image, getster_App_Master.getster_app_id);


                    //_DbContext.Entry(getster_App_Master).State = EntityState.Detached;
                    CommanUpdateStatus(obj.Entity.getster_app_id, obj.Entity.getster_app_development_status, "");

                    getster_app_audit_trail _getster_app_audit_trail = new getster_app_audit_trail();
                    _getster_app_audit_trail.getster_app_id = getster_App_Master.getster_app_id;
                    _getster_app_audit_trail.getster_app_activity = "Added";
                    _getster_app_audit_trail.getster_app_activity_by_getster_id = _getster_app_audit_trail.getster_app_activity_by_getster_id;
                    _getster_app_audit_trail.getster_app_activity_time_stamp = DateTime.UtcNow;

                    _DbContext.getster_app_audit_trail.Add(_getster_app_audit_trail);
                    _DbContext.SaveChanges();

                    response.Message = "Data Saved successfully !!";
                    response.Data = getster_App_Master;
                    response.Status = true;

                }
                else
                {
                    getster_app_master _app_getster_app_master = new getster_app_master
                    {
                        getster_app_icon_image = getster_app_master_parent.getster_app_icon_image,
                        getster_app_icon_name = getster_app_master_parent.getster_app_icon_name,
                        getster_app_development_status = getster_app_master_parent.getster_app_development_status,
                        getster_app_id = getster_app_master_parent.getster_app_id,
                        getster_app_title_bar_name = getster_app_master_parent.getster_app_title_bar_name

                    };

                    _DbContext.Attach(_app_getster_app_master);
                    _DbContext.Entry(_app_getster_app_master).Property(p => p.getster_app_development_status).IsModified = true;
                    _DbContext.Entry(_app_getster_app_master).Property(p => p.getster_app_icon_image).IsModified = true;
                    _DbContext.Entry(_app_getster_app_master).Property(p => p.getster_app_icon_name).IsModified = true;
                    _DbContext.Entry(_app_getster_app_master).Property(p => p.getster_app_title_bar_name).IsModified = true;
                    _DbContext.SaveChanges();
                    saveImage(convertImage(getster_app_master_parent.getsterapp_upload_image), _app_getster_app_master.getster_app_icon_image, _app_getster_app_master.getster_app_id);

                    //getster_app_names _app_getster_App_Names = new getster_app_names
                    //{
                    //    getster_app_name = getster_app_master_parent.getster_app_names.getster_app_name,
                    //    getster_app_title_bar_name = getster_app_master_parent.getster_app_names.getster_app_title_bar_name,
                    //    getster_app_id = getster_app_master_parent.getster_app_master.getster_app_id
                    //};

                    //_DbContext.Attach(_app_getster_App_Names);
                    //_DbContext.Entry(_app_getster_App_Names).Property(p => p.getster_app_name).IsModified = true;
                    //_DbContext.Entry(_app_getster_App_Names).Property(p => p.getster_app_title_bar_name).IsModified = true;
                    //_DbContext.SaveChanges();

                    getster_app_audit_trail _getster_app_audit_trail = new getster_app_audit_trail();
                    _getster_app_audit_trail.getster_app_id = _app_getster_app_master.getster_app_id;
                    _getster_app_audit_trail.getster_app_activity = "Edited";
                    _getster_app_audit_trail.getster_app_activity_by_getster_id = _getster_app_audit_trail.getster_app_activity_by_getster_id;
                    _getster_app_audit_trail.getster_app_activity_time_stamp = DateTime.UtcNow;

                    _DbContext.getster_app_audit_trail.Add(_getster_app_audit_trail);
                    _DbContext.SaveChanges();

                    //var fetchData = _DbContext.getster_app_master.Where(z => z.getster_app_id == getster_app_master_parent.getster_app_master.getster_app_id).FirstOrDefault();
                    CommanUpdateStatus(_app_getster_app_master.getster_app_id, _app_getster_app_master.getster_app_development_status, "");



                    response.Message = "Data updated successfully!!"; 
                    response.Status = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = "Data Saved to failed !!";
                response.Status = false;
            }
            return response;
        }

       public Response2 GetAllAppsForGetster()
        {
            Response2 response = new Response2();
            List<ParentData> lstParnet = new List<ParentData>();
            ParentData objParent = new ParentData();

            
            var query2 = (
            from CAT in _DbContext.getster_app_categories
            from AST in _DbContext.getster_apps_and_categories_assignment
            .Where(mapping => mapping.getster_app_category_id == CAT.getster_app_category_id)
            .DefaultIfEmpty() // <== makes join left join
            from groups in _DbContext.getster_app_master
            .Where(groupe => groupe.getster_app_id == AST.getster_app_id)
            .DefaultIfEmpty() // <== makes join left join
            select new
            {
                Category_Name = CAT.getster_app_category_name,
                getster_app_id = AST.getster_app_id
            });

            try
            {
                if (query2 == null)
                {

                    var q = query2.ToList();
                    var lstCategory = q.GroupBy(z => z.Category_Name).ToList();

                    var lstData = (from master in _DbContext.getster_app_master
                                   join assign in _DbContext.getster_apps_and_categories_assignment on master.getster_app_id
                                   equals assign.getster_app_id
                                   join catLoc in _DbContext.getster_app_categories on assign.getster_app_category_id
                                   equals catLoc.getster_app_category_id
                                   //join assign1 in _DbContext.getster_app_names on master.getster_app_id
                                   //equals assign1.getster_app_id

                                   select new
                                   {
                                       getster_app_id = master.getster_app_id,
                                       CategoryName = catLoc.getster_app_category_name,
                                       getster_app_category_path = catLoc.getster_app_category_path,
                                       getster_app_icon_name = master.getster_app_icon_name,
                                       getster_app_web_image = master.getster_app_icon_image,
                                       getster_app_title_bar_name = master.getster_app_title_bar_name,
                                       getster_app_development_status = master.getster_app_development_status,
                                       getster_app_name = master.getster_app_name,
                                   }).ToList();

                    List<FilterData> lstFilterData = new List<FilterData>();
                    FilterData fDataobj = new FilterData();
                    for (int i = 0; i < lstCategory.Count; i++)
                    {
                        objParent = new ParentData();
                        var list = lstData.Where(z => z.CategoryName == lstCategory[i].Key).ToList();

                        if (list.Count > 0)
                        {
                            objParent.Category_Name = lstCategory[i].Key;
                            lstFilterData = new List<FilterData>();
                            foreach (var master in list)
                            {
                                fDataobj = new FilterData();
                                fDataobj.getster_app_category_path = master.getster_app_category_path;

                                fDataobj.getster_app_id = master.getster_app_id;
                                fDataobj.getster_app_icon_name = master.getster_app_icon_name;
                                fDataobj.getster_app_web_image = master.getster_app_id+"//"+master.getster_app_web_image;
                                fDataobj.getster_app_title_bar_name = master.getster_app_title_bar_name;
                                fDataobj.getster_app_development_status = master.getster_app_development_status;
                                fDataobj.getster_app_name = master.getster_app_name;
                                lstFilterData.Add(fDataobj);
                            }
                            objParent.filterData = lstFilterData;
                            lstParnet.Add(objParent);
                        }
                    }
                    response.Data = lstParnet;
                    response.Message = "Data Fetch successfully !!";
                    response.Status = true;
                }
                else
                {
                    var query = (
                          from CAT in _DbContext.getster_app_categories
                          from AST in _DbContext.getster_apps_and_categories_assignment
                              //.Where(mapping => mapping.Id == CAT.Id)
                              //.DefaultIfEmpty() // <== makes join left join
                          from groups in _DbContext.getster_app_master
                          .Where(groupe => groupe.getster_app_id == AST.getster_app_id)
                         .DefaultIfEmpty() // <== makes join left join
                          select new
                          {
                              Category_Name = CAT.getster_app_category_name,
                              getster_app_id = AST.getster_app_id
                          });

                    try
                    {
                        
                       

                            var q = query.ToList();
                            var lstCategory = q.GroupBy(z => z.Category_Name).ToList();

                            var lstData = (from master in _DbContext.getster_app_master
                                           join assign in _DbContext.getster_apps_and_categories_assignment on master.getster_app_id
                                           equals assign.getster_app_id
                                           join catLoc in _DbContext.getster_app_categories on assign.getster_app_category_id
                                           equals catLoc.getster_app_category_id
                                           //join assign1 in _DbContext.getster_app_names on master.getster_app_id
                                           //equals assign1.getster_app_id

                                           select new
                                           {
                                               getster_app_id = master.getster_app_id,
                                               CategoryName = catLoc.getster_app_category_name,
                                               getster_app_category_path = catLoc.getster_app_category_path,
                                               getster_app_icon_name = master.getster_app_icon_name,
                                               getster_app_web_image = master.getster_app_icon_image,
                                               getster_app_development_status = master.getster_app_development_status,
                                               getster_app_name = master.getster_app_name,
                                               getster_app_title_bar_name = master.getster_app_title_bar_name,
                                           }).ToList();

                            List<FilterData> lstFilterData = new List<FilterData>();
                            FilterData fDataobj = new FilterData();
                            for (int i = 0; i < lstCategory.Count; i++)
                            {
                                objParent = new ParentData();
                                var list = lstData.Where(z => z.CategoryName == lstCategory[i].Key).ToList();

                                if (list.Count > 0)
                                {
                                    objParent.Category_Name = lstCategory[i].Key;
                                    lstFilterData = new List<FilterData>();
                                    foreach (var master in list)
                                    {
                                        fDataobj = new FilterData();
                                        fDataobj.getster_app_category_path = master.getster_app_category_path;

                                        fDataobj.getster_app_id = master.getster_app_id;
                                        fDataobj.getster_app_icon_name = master.getster_app_icon_name;
                                        fDataobj.getster_app_web_image = master.getster_app_id+"//"+master.getster_app_web_image;
                                        //fDataobj.getster_app_web_link = master.getster_app_web_link;
                                        fDataobj.getster_app_development_status = master.getster_app_development_status;
                                        fDataobj.getster_app_name = master.getster_app_name;
                                        fDataobj.getster_app_title_bar_name = master.getster_app_title_bar_name;
                                        lstFilterData.Add(fDataobj);
                                    }
                                    objParent.filterData = lstFilterData;
                                    lstParnet.Add(objParent);
                                }
                            }
                            response.Data = lstParnet;
                            response.Message = "Data Fetch successfully !!";
                            response.Status = true;
                        

                    }
                    catch (Exception ex)
                    {
                        response.Message = "Error, while fetching the data !!";
                        response.Status = false;
                    }
                } 
            }


            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }


            return response;
        }
               public Response GetAllAppsForGetsterById(int getster_app_id)
        {
           Response response = new Response();
           try
           {

               if (getster_app_id == 0)

               {
                   response.Message = "Enter Getster App Id !!";
                   response.Status = false;
               }

               else
               {
                   //response.Data = _DbContext.getster_app_master.Where(g => g.getster_app_id == getsterAppID).ToList();

                   var lstData = (from master in _DbContext.getster_app_master
                                    //join assign in _DbContext.getster_apps_and_categories_assignment on master.getster_app_id
                                    //equals assign.getster_app_id
                                    //join catLoc in _DbContext.getster_app_categories on assign.getster_app_category_id
                                    //equals catLoc.getster_app_category_id
                                  //join assign1 in _DbContext.getster_app_names on master.getster_app_id
                                  //  equals x.getster_app_id


                                    select new
                                    {
                                        //path = catLoc.Path,
                                        getster_app_id = master.getster_app_id,
                                        getster_app_icon_name = master.getster_app_icon_name,
                                        getster_app_web_image = master.getster_app_id+"//"+master.getster_app_icon_image,
                                        //getster_app_web_link = master.getster_app_web_link,
                                        getster_app_development_status = master.getster_app_development_status,
                                        getster_app_name = master.getster_app_name,
                                        getster_app_title_bar_name = master.getster_app_title_bar_name,
                                    }).ToList();



                   response.Data = lstData.Where(z => z.getster_app_id == getster_app_id).ToList();
                   response.Message = "Data Fetch successfully !!";
                   response.Status = true;
               }



           }
           catch (Exception ex)
           {
               response.Message = "Error, while fetching the data !!";
               response.Status = false;
           }
           return response;
        }


        public Response Update_Gester_App_Development_Status(int gesterId, bool publishKey)
    {
        return CommanUpdateStatus(gesterId, publishKey, "Single_Update_Status");
    }


    public Response CommanUpdateStatus(int gesterId, bool publishKey, string methodName)
    {
        Response response = new Response();
        try
        {
            getster_app_update_status getster_App_Update_Status = new getster_app_update_status();
            getster_app_audit_trail getster_App_Audit_Trail = new getster_app_audit_trail();
            getster_app_master getster_App_Master = new getster_app_master();


            #region Update Field getster_app_development_status in  getster_app_master Table
            //0 means Publish and 1 means Unpublish

            if (methodName == "Single_Update_Status")
            {
                var getData = _DbContext.getster_app_master.Where(z => z.getster_app_id == gesterId).FirstOrDefault();
                getData.getster_app_id = gesterId;
                getData.getster_app_development_status = publishKey;
                _DbContext.getster_app_master.Attach(getData).Property(x => x.getster_app_development_status).IsModified = true;
                _DbContext.Entry(getData).State = EntityState.Modified;
                _DbContext.SaveChanges();
            }
            #endregion


            #region getster_App_Audit_Trail Update Section
            var getAuditTrial = _DbContext.getster_app_audit_trail.Where(z => z.getster_app_id == gesterId).FirstOrDefault();

            if (getAuditTrial != null)
            {
                // 0 = true = Publish // 1= false = unUblish
                // 0 being false and 1 being true
                getAuditTrial.getster_app_activity = (publishKey == true ? "Publish Key" : "Un-Publish Key");
                getAuditTrial.getster_app_activity_by_getster_id = gesterId; //Current UserId
                getAuditTrial.getster_app_activity_time_stamp = DateTime.UtcNow;
                getAuditTrial.getster_app_id = gesterId;

                _DbContext.getster_app_audit_trail.Attach(getAuditTrial).Property(x => x.getster_app_activity).IsModified = true;
                _DbContext.getster_app_audit_trail.Attach(getAuditTrial).Property(x => x.getster_app_activity_by_getster_id).IsModified = true;
                _DbContext.getster_app_audit_trail.Attach(getAuditTrial).Property(x => x.getster_app_activity_time_stamp).IsModified = true;
                _DbContext.Entry(getAuditTrial).State = EntityState.Modified;
                _DbContext.SaveChanges();
            }

            else  //entry New
            {
                getster_App_Audit_Trail.getster_app_activity = (publishKey == true ? "Publish Key" : "Un-Publish Key");
                getster_App_Audit_Trail.getster_app_activity_by_getster_id = gesterId; //Current UserId
                getster_App_Audit_Trail.getster_app_activity_time_stamp = DateTime.UtcNow;
                getster_App_Audit_Trail.getster_app_id = gesterId;
                var obj = _DbContext.getster_app_audit_trail.Add(getster_App_Audit_Trail);
                _DbContext.SaveChanges();
            }


            #endregion

            #region Update getster_app_update_status
            var getStatusData = _DbContext.getster_app_update_status.Where(z => z.getster_app_id == gesterId).FirstOrDefault();
            if (getStatusData != null) //entry updated
            {
                getStatusData.getster_app_id = gesterId;
                getStatusData.getster_app_update_time_stamp = DateTime.UtcNow;
                _DbContext.getster_app_update_status.Attach(getStatusData).Property(x => x.getster_app_update_time_stamp).IsModified = true;
                _DbContext.Entry(getStatusData).State = EntityState.Modified;
                _DbContext.SaveChanges();
            }
            else  //entry New
            {
                getster_App_Update_Status.getster_app_update_time_stamp = DateTime.UtcNow;
                getster_App_Update_Status.getster_app_id = gesterId;
                var obj = _DbContext.getster_app_update_status.Add(getster_App_Update_Status);
                _DbContext.SaveChanges();
            }


            #endregion

            response.Status = true;
            response.Message = "Data updated Successfully";
        }
        catch (Exception ex)
        {

            response.Status = false;
            response.Message = "Data updated failed..";
        }
        return response;
    }

        public Response GetAllGetsterAppAuditTrail()
        {
            Response response = new Response();
            try
            {
                response.Data = (from auditTrail in _DbContext.getster_app_audit_trail
                                 select new
                                 {
                                     Getster_App_Id = auditTrail.getster_app_id,
                                     App_Activity = auditTrail.getster_app_activity,
                                     App_Activity_by_getster_id = auditTrail.getster_app_activity_by_getster_id,
                                     App_activity_time_stamp = auditTrail.getster_app_activity_time_stamp,
                                 }).ToList();

                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }

           
            catch (Exception ex)
            {
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            return response;
        }



        protected string saveImage(byte[] image, string name, int userid)
        {
            string uniqueFileName = name;
            string LiveServerpath = _configuration.GetSection("LiveGetsterapp").Value;
            string pathname = LiveServerpath + userid;
            bool exists = System.IO.Directory.Exists(pathname);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(pathname);
            }

            using (MemoryStream mem = new MemoryStream(image))
            {
                using (var yourImage = Image.FromStream(mem))
                {
                    var filepath = pathname + "\\" + uniqueFileName;
                    yourImage.Save(filepath, ImageFormat.Png);
                }
            }
            return uniqueFileName;
        }

        protected static byte[] convertImage(IFormFile imgToResize)
        {
            using (var ms = new MemoryStream())
            {
                imgToResize.CopyTo(ms);
                var fileBytes = ms.ToArray();
                ms.Dispose();
                return (byte[])fileBytes;
            }
        }



    }
}
 
    

