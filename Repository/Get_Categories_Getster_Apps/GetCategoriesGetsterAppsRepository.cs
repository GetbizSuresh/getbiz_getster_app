using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_getster_app.Repository.Get_Categories_Getster_Apps
{
    public class GetCategoriesGetsterAppsRepository : IGetCategoriesGetsterAppsRepository
    {

        public readonly Getbizdb_DbContext _DbContext;
        public GetCategoriesGetsterAppsRepository(Getbizdb_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response2 GetCategoriesGetsterAppsByPath(string _Path,string _Id)
        {
            Response2 response = new Response2();
            List<ParentData> lstParnet = new List<ParentData>();
            ParentData objParent = new ParentData();
            try
            {

                if (_Path == null)

                {
                    response.Message = "Enter Getster App Path !!";
                    response.Status = false;
                }

                else
                {
                    var lstData = (from master in _DbContext.getster_app_master
                                   join assign in _DbContext.getster_apps_and_categories_assignment on master.getster_app_id
                                   equals assign.getster_app_id
                                   join catLoc in _DbContext.getster_app_categories on assign.getster_app_category_id
                                   equals catLoc.getster_app_category_id
                                   //join names in _DbContext.getster_app_names on master.getster_app_id
                                   //equals names.getster_app_id
                                   
                                   select new
                                   {
                                       CategoryName = catLoc.getster_app_category_name,
                                       getster_app_category_name = catLoc.getster_app_category_name,
                                       getster_app_category_path = catLoc.getster_app_category_path,
                                       getster_app_category_id = catLoc.getster_app_category_id,
                                       getster_app_id = master.getster_app_id,
                                       getster_app_icon_name = master.getster_app_icon_name,
                                       getster_app_web_image =master.getster_app_icon_image,
                                       getster_app_development_status = master.getster_app_development_status,
                                       getster_app_name = master.getster_app_name,
                                       getster_app_title_bar_name = master.getster_app_title_bar_name,
                                       getster_apps_and_categories_assignment_id =assign.getster_apps_and_categories_assignment_id,
                                   }).ToList();


                    //Add Category Id and Data into a single List
                    List<ParentData> lstParentData = new();
                    List<ParentData> finalPata = new();

                    ParentData objParentData = new();
                    int _PathLength = _Path.Split(',').Length;
                    List<FilterData1> lstFilterData = new();
                    FilterData1 filterData1 = new FilterData1();

                    if (_PathLength == 1) //if not comma seprated
                    {
                        var objData = lstData.Where(z => z.getster_app_category_path == _Path).ToList();
                        for (int i = 0; i < objData.Count; i++)
                        {
                            objParentData.Category_Name = objData[i].CategoryName;

                            if (objData != null && objData[i].getster_app_id > 0)
                            {
                                filterData1 = new FilterData1();
                                //lstFilterData = new List<FilterData>();
                                filterData1.getster_app_category_id = objData[i].getster_app_category_id;
                                filterData1.getster_app_id = objData[i].getster_app_id;
                                filterData1.getster_app_category_path = objData[i].getster_app_category_path;
                                filterData1.getster_app_category_name = objData[i].getster_app_category_name;
                                filterData1.getster_app_icon_name = objData[i].getster_app_icon_name;
                                filterData1.getster_app_web_image = objData[i].getster_app_id+"//"+objData[i].getster_app_web_image;
                                //filterData1.getster_app_web_link = objData[i].getster_app_web_link;
                                filterData1.getster_app_development_status = objData[i].getster_app_development_status;
                                filterData1.getster_app_name = objData[i].getster_app_name;
                                filterData1.getster_app_title_bar_name = objData[i].getster_app_title_bar_name;
                                filterData1.getster_apps_and_categories_assignment_id = objData[i].getster_apps_and_categories_assignment_id;
                                


                                lstFilterData.Add(filterData1);
                            }
                        }

                        objParentData.filterData1 = lstFilterData;
                        lstParentData.Add(objParentData);
                    }
                    else
                    {
                        for (int j = 0; j < _Path.Split(",").Length; j++)
                        {
                            var objData = lstData.Where(z => z.getster_app_category_path == _Path.Split(",")[j]).ToList();
                            lstFilterData = new List<FilterData1>();
                            objParentData = new ParentData();

                            for (int k = 0; k < objData.Count; k++)
                            {
                                objParentData.Category_Name = objData[k].CategoryName;
                                if (objData != null && objData[k].getster_app_id > 0)
                                {
                                    filterData1 = new FilterData1
                                    {
                                        getster_app_category_id = objData[k].getster_app_category_id,
                                        getster_app_id = objData[k].getster_app_id,
                                        getster_app_category_name = objData[k].getster_app_category_name,
                                        getster_app_category_path = objData[k].getster_app_category_path,
                                        getster_app_icon_name = objData[k].getster_app_icon_name,
                                        getster_app_web_image = objData[k].getster_app_id+"//"+objData[k].getster_app_web_image,
                                        //getster_app_web_link = objData[k].getster_app_web_link,
                                        getster_app_development_status = objData[k].getster_app_development_status,
                                        getster_app_name = objData[k].getster_app_name,
                                        getster_app_title_bar_name = objData[k].getster_app_title_bar_name,
                                        getster_apps_and_categories_assignment_id = objData[k].getster_apps_and_categories_assignment_id,
                                        
                                    };
                                    lstFilterData.Add(filterData1);
                                }
                            }
                            objParentData.filterData1 = lstFilterData;
                            lstParentData.Add(objParentData);
                        }

                    }


                    if (lstParentData.Count() > 0)
                    {
                        response.Data = lstParentData;
                        response.Message = "Data Fetch successfully !!";
                        response.Status = true;
                    }
                    else
                    {
                        response.Data = lstParentData;
                        response.Message = "No Data found!!";
                        response.Status = true;
                    }
  

                }


                if (_Id == null)

                {
                    response.Message = "Enter Getster App Id !!";
                    response.Status = false;
                }

                else
                {
                    var lstData = (from master in _DbContext.getster_app_master
                                   join assign in _DbContext.getster_apps_and_categories_assignment on master.getster_app_id
                                   equals assign.getster_app_id
                                   join catLoc in _DbContext.getster_app_categories on assign.getster_app_category_id
                                   equals catLoc.getster_app_category_id
                                   //join names in _DbContext.getster_app_names on master.getster_app_id
                                   //equals names.getster_app_id
                                   //join aid in _DbContext.getster_apps_and_categories_assignment on master.Id
                                   //equals aid.getster_apps_and_categories_assignment_id
                                   select new
                                   {
                                       CategoryName = catLoc.getster_app_category_name,
                                       getster_app_category_name = catLoc.getster_app_category_name,
                                       getster_app_category_path = catLoc.getster_app_category_path,
                                       getster_app_category_id = catLoc.getster_app_category_id,
                                       getster_app_id = master.getster_app_id,
                                       getster_app_icon_name = master.getster_app_icon_name,
                                       getster_app_web_image = master.getster_app_icon_image,
                                       //getster_app_web_link = master.getster_app_web_link,
                                       getster_app_development_status = master.getster_app_development_status,
                                       getster_app_name = master.getster_app_name,
                                       getster_app_title_bar_name = master.getster_app_title_bar_name,
                                       getster_apps_and_categories_assignment_id = assign.getster_apps_and_categories_assignment_id,
                                   }).ToList();


                    //Add Category Id and Data into a single List
                    List<ParentData> lstParentData = new();
                    List<ParentData> finalPata = new();

                    ParentData objParentData = new();
                    int _IdLength = _Id.Split(',').Length;
                    List<FilterData1> lstFilterData = new();
                    FilterData1 filterData1 = new FilterData1();

                    if (_IdLength == 1) //if not comma seprated
                    {
                        var objData = lstData.Where(z => z.getster_app_category_id == _Id).ToList();
                        for (int i = 0; i < objData.Count; i++)
                        {
                            objParentData.Category_Name = objData[i].CategoryName;

                            if (objData != null && objData[i].getster_app_id > 0)
                            {
                                filterData1 = new FilterData1();
                                //lstFilterData = new List<FilterData>();
                                filterData1.getster_app_category_id = objData[i].getster_app_category_id;
                                filterData1.getster_app_id = objData[i].getster_app_id;
                                filterData1.getster_app_category_name = objData[i].getster_app_category_name;
                                filterData1.getster_app_category_path = objData[i].getster_app_category_path;
                                filterData1.getster_app_icon_name = objData[i].getster_app_icon_name;
                                filterData1.getster_app_web_image = objData[i].getster_app_id+"//"+objData[i].getster_app_web_image;
                                //filterData1.getster_app_web_link = objData[i].getster_app_web_link;
                                filterData1.getster_app_development_status = objData[i].getster_app_development_status;
                                filterData1.getster_app_name = objData[i].getster_app_name;
                                filterData1.getster_app_title_bar_name = objData[i].getster_app_title_bar_name;
                                filterData1.getster_apps_and_categories_assignment_id = objData[i].getster_apps_and_categories_assignment_id;

                                lstFilterData.Add(filterData1);
                            }
                        }

                        objParentData.filterData1 = lstFilterData;
                        lstParentData.Add(objParentData);
                    }
                    else
                    {
                        for (int j = 0; j < _Id.Split(",").Length; j++)
                        {
                            var objData = lstData.Where(z => z.getster_app_category_id == _Id.Split(",")[j]).ToList();
                            lstFilterData = new List<FilterData1>();
                            objParentData = new ParentData();

                            for (int k = 0; k < objData.Count; k++)
                            {
                                objParentData.Category_Name = objData[k].CategoryName;
                                if (objData != null && objData[k].getster_app_id > 0)
                                {
                                    filterData1 = new FilterData1
                                    {
                                       getster_app_category_id = objData[k].getster_app_category_id,
                                        getster_app_id = objData[k].getster_app_id,
                                        getster_app_category_name = objData[k].getster_app_category_name,
                                        getster_app_category_path = objData[k].getster_app_category_path,
                                        getster_app_icon_name = objData[k].getster_app_icon_name,
                                        getster_app_web_image = objData[k].getster_app_id+"//"+objData[k].getster_app_web_image,
                                        //getster_app_web_link = objData[k].getster_app_web_link,
                                        getster_app_development_status = objData[k].getster_app_development_status,
                                        getster_app_name = objData[k].getster_app_name,
                                        getster_app_title_bar_name = objData[k].getster_app_title_bar_name,
                                        getster_apps_and_categories_assignment_id = objData[k].getster_apps_and_categories_assignment_id,
                                    };
                                    lstFilterData.Add(filterData1);
                                }
                            }
                            objParentData.filterData1 = lstFilterData;
                            lstParentData.Add(objParentData);
                        }
                    }


                    if (lstParentData.Count() > 0)
                    {
                        response.Data = lstParentData;
                        response.Message = "Data Fetch successfully !!";
                        response.Status = true;
                    }
                    else
                    {
                        response.Data = lstParentData;
                        response.Message = "No Data found!!";
                        response.Status = true;
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
    }
}
