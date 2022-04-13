using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace getbiz_getster_app.Repository.Getster_App_Category_Location
{
    public class GetsterAppCategoryLocationRespository : IGetsterAppCategoryLocationRespository
    {
        public readonly Getbizdb_DbContext _DbContext;
        public GetsterAppCategoryLocationRespository(Getbizdb_DbContext DbContext)
        {
            _DbContext = DbContext;
        }


        public Response AddCategorySubCategory(getster_app_categories getster_app_categories)
        {
            Response response = new Response();

            try
            {
                //MD Category
                //for (int i = 100; i < 199; i = i + 100)
                
                //{
                //    if (i + 100 < 199)
                //    {

                        getster_app_categories _getster_app_categories = new getster_app_categories
                        {
                            getster_app_category_id = getster_app_categories.getster_app_category_id,
                            getster_app_category_path = getster_app_categories.getster_app_category_path,
                            getster_app_category_name = getster_app_categories.getster_app_category_name
                        };
                    //}

                    var obj = _DbContext.getster_app_categories.Add(getster_app_categories);
                    // var obj2 = _DbContext.getster_apps_and_categories_assignment.Add(getster_Apps_And_Categories_Assignment);

                    _DbContext.SaveChanges();

                    response.Message = "Category & Location Saved successfully !!";
                    response.Status = true;
               //}
            }
            catch (Exception ex)
            {
                response.Message = "Getster Category Id already Exist or Category Saved to failed !!";
                response.Status = false;
            }
            return response;
        }

        public Response AddCategorySubCategorygetster(getster_app_categories_parent1 getster_app_categories_parent1)
        {
            Response response = new Response();
            try
            {
                //getster_app_categories _app_getster_app_categories = new getster_app_categories
                //{
                //    Id = getster_app_categories_parent.id,
                //    Name = getster_app_categories_parent.name,
                //    Path = getster_app_categories_parent.path
                //};
                //_DbContext.Attach(_app_getster_app_categories);
                //_DbContext.Entry(_app_getster_app_categories).Property(p => p.Path).IsModified = true;
                //_DbContext.Entry(_app_getster_app_categories).Property(p => p.Name).IsModified = true;
                //_DbContext.Entry(_app_getster_app_categories).State = EntityState.Modified;



                var getData = _DbContext.getster_apps_and_categories_assignment.Where(z => z.getster_app_id == getster_app_categories_parent1.getster_app_id
                && z.getster_app_category_id == getster_app_categories_parent1.getster_app_category_id).FirstOrDefault();


                if (getData == null)
                {
                    getster_apps_and_categories_assignment getster_Apps_And_Categories_Assignment = new getster_apps_and_categories_assignment
                    {
                        getster_app_category_id = getster_app_categories_parent1.getster_app_category_id,
                        getster_app_id = getster_app_categories_parent1.getster_app_id,
                        getster_app_category_location = (int)getster_app_categories_parent1.getster_app_category_location
                    };

                    _DbContext.Attach(getster_Apps_And_Categories_Assignment);
                    _DbContext.Entry(getster_Apps_And_Categories_Assignment).Property(p => p.getster_app_id);
                    _DbContext.Entry(getster_Apps_And_Categories_Assignment).Property(p => p.getster_app_category_location);
                    _DbContext.Entry(getster_Apps_And_Categories_Assignment).State = EntityState.Added;

                   


                    _DbContext.SaveChanges();

                    response.Status = true;
                    response.Message = "Data updated Successfully";
                }
                else
                {
                    response.Status = false;
                    response.Message = "Getster App Id already Exist !!";
                }

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Data updated failed.." ;
            }
            return response;
        }

        public Response Modify(getster_app_categories_parent getster_app_categories_parent)
        {
            Response response = new Response();
            try
            {
                getster_app_categories _app_getster_app_categories = new getster_app_categories
                {
                    getster_app_category_id = getster_app_categories_parent.getster_app_category_id,
                    getster_app_category_path = getster_app_categories_parent.getster_app_category_path,
                    getster_app_category_name = getster_app_categories_parent.getster_app_category_name

                };
                _DbContext.Attach(_app_getster_app_categories);

                _DbContext.Entry(_app_getster_app_categories).Property(p => p.getster_app_category_path).IsModified = true;
                _DbContext.Entry(_app_getster_app_categories).Property(p => p.getster_app_category_name).IsModified = true;
                _DbContext.Entry(_app_getster_app_categories).State = EntityState.Modified;
                _DbContext.SaveChanges();

                //getster_apps_and_categories_assignment getster_Apps_And_Categories_Assignment = new getster_apps_and_categories_assignment();

                //getster_Apps_And_Categories_Assignment.Id = getster_app_categories_parent.id;
                //getster_Apps_And_Categories_Assignment.getster_app_id = getster_app_categories_parent.getster_app_id;
                //getster_Apps_And_Categories_Assignment.getster_app_category_location = getster_app_categories_parent.getster_app_category_location;
                //getster_Apps_And_Categories_Assignment.getster_apps_and_categories_assignment_id = getster_app_categories_parent.getster_apps_and_categories_assignment_id;                

                //_DbContext.Attach(getster_Apps_And_Categories_Assignment);
                // _DbContext.Entry(getster_Apps_And_Categories_Assignment).Property(p => p.Id).IsModified = false;
                //_DbContext.Entry(getster_Apps_And_Categories_Assignment).Property(p => p.getster_app_id).IsModified = true;
                //_DbContext.Entry(getster_Apps_And_Categories_Assignment).Property(p => p.getster_app_category_location).IsModified = true;
                //_DbContext.SaveChanges();

                response.Status = true;
                response.Message = "Data updated Successfully";
            }
            catch (Exception ex)
            
            {
                response.Status = false;
                response.Message = "Data updated failed.." ;
            }
            return response;
        }

        public Response DeleteCategory(string CategoryId)
        {
            Response response = new Response();
            try
            {
                var getster_app_category_and_location = _DbContext.getster_app_categories.Where(z => z.getster_app_category_id == Convert.ToString(CategoryId)).FirstOrDefault();
                _DbContext.getster_app_categories.Remove(getster_app_category_and_location);
                _DbContext.SaveChanges();
                response.Message = "Category Deleted successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured ! While Deleting the data !!";
                response.Status = false;
            }
            return response;
        }

        public Response GetAllCategories()
        {
            //Response response = new Response();
            //try
            //{
            //    response.Data = (from CatLoc in _DbContext.getster_app_categories
            //                     join assign in _DbContext.getster_apps_and_categories_assignment on CatLoc.Id
            //                     equals assign.Id

            //                     select new
            //                     {
            //                         id = CatLoc.Id,
            //                         path = CatLoc.Path,
            //                         name = CatLoc.Name,
            //                        //getster_app_id = assign.getster_app_id,

            //                     }).ToList();

            //    response.Message = "Data Fetch successfully !!";
            //    response.Status = true;

            //}
            //catch(Exception ex)
            //{
            //    response.Message = "Error, while fetching the data !!";
            //    response.Status = false;
            //}
            //return response;

            Response response = new Response();
            try
            {
                response.Data = _DbContext.getster_app_categories.ToList();
                response.Message = "Data Fetched successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured ! While Deleting the data !!";
                response.Status = false;
            }
            return response;


        }

        //public Response GetAllCategoriesById(int getster_app_id)
        //{
        //    Response response = new Response();
        //    try
        //    {
        //        if (getster_app_id == 0)

        //        {
        //            response.Message = "Enter Getster App Id !!";
        //            response.Status = false;
        //        }
        //        else

        //        {
        //            var getster_app_categories_parent = (from Cate in _DbContext.getster_app_categories
        //                                                join assign in _DbContext.getster_apps_and_categories_assignment on Cate.Id
        //                                                equals assign.Id
        //                                                join assign1 in _DbContext.getster_app_categories on assign.Id
        //                                                equals assign1.Id

        //                                                 select new
        //                                                {
        //                                                     id = Cate.Id,
        //                                                     path = Cate.Path,
        //                                                     name = Cate.Name,
        //                                                     getster_app_id = assign.getster_app_id,
        //                                                 }).ToList();

        //            response.Data = getster_app_categories_parent.Where(z => z.getster_app_id == getster_app_id).ToList();
        //            response.Message = "Data Fetch successfully !!";
        //            response.Status = true;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = "Error, while fetching the data !!";
        //        response.Status = false;
        //    }
        //    return response;
        //}

        public Response ReAssignApps(getster_app_categories_parent1 getster_app_categories_parent1)
        {
            Response response = new Response();
            //try
            //{
            //    if (getster_Apps_And_Categories_Assignment.Id == "0")
            //    {
            //        _DbContext.getster_apps_and_categories_assignment.Add(getster_Apps_And_Categories_Assignment);
            //        _DbContext.SaveChanges();
            //    }
            //    else
            //    {
            //        getster_apps_and_categories_assignment _app_getster_Apps_And_Categories_Assignment = new getster_apps_and_categories_assignment();
            //        _app_getster_Apps_And_Categories_Assignment.getster_app_category_location = getster_Apps_And_Categories_Assignment.getster_app_category_location;
            //        _app_getster_Apps_And_Categories_Assignment.getster_app_id = getster_Apps_And_Categories_Assignment.getster_app_id;
            //        _app_getster_Apps_And_Categories_Assignment.Id = getster_Apps_And_Categories_Assignment.Id;

            //        _DbContext.Attach(_app_getster_Apps_And_Categories_Assignment);
            //        //_DbContext.Entry(_app_getster_Apps_And_Categories_Assignment).Property(p => p.Id).IsModified = true;
            //        _DbContext.Entry(_app_getster_Apps_And_Categories_Assignment).Property(p => p.getster_app_id).IsModified = true;
            //        _DbContext.Entry(_app_getster_Apps_And_Categories_Assignment).Property(p => p.getster_app_category_location).IsModified = true;

            //        _DbContext.SaveChanges();
            //    }
            var getData = _DbContext.getster_apps_and_categories_assignment.Where(z => z.getster_app_id == getster_app_categories_parent1.getster_app_id
                && z.getster_app_category_id == getster_app_categories_parent1.getster_app_category_id).FirstOrDefault();


            if (getData == null)
            {
                getster_apps_and_categories_assignment getster_Apps_And_Categories_Assignment = new getster_apps_and_categories_assignment
                {
                    getster_app_category_id = getster_app_categories_parent1.getster_app_category_id,
                    getster_app_id = getster_app_categories_parent1.getster_app_id,
                    getster_app_category_location = (int)getster_app_categories_parent1.getster_app_category_location
                };

                _DbContext.Attach(getster_Apps_And_Categories_Assignment);
                _DbContext.Entry(getster_Apps_And_Categories_Assignment).Property(p => p.getster_app_id);
                _DbContext.Entry(getster_Apps_And_Categories_Assignment).Property(p => p.getster_app_category_location);
                _DbContext.Entry(getster_Apps_And_Categories_Assignment).State = EntityState.Added;

                _DbContext.SaveChanges();
                response.Status = true;
                response.Message = "Apps Assigned Successfully..";
            }
            else
            {
                response.Status = false;
                response.Message = "Getster App Id already Exist !!";
            }
            //catch (Exception ex)
            //{
            //    response.Status = false;
            //    response.Message = "Error occured while assigning the apps..";
            //}

            return response;
        }


        public Response ReAssignAppsDeletegetsterId(getster_app_categories_parent1 getster_app_categories_parent1)
        {
            Response response = new Response();
            try
            {
                var getData = _DbContext.getster_apps_and_categories_assignment.Where(z => z.getster_app_id == getster_app_categories_parent1.getster_app_id
                && z.getster_app_category_id == getster_app_categories_parent1.getster_app_category_id).FirstOrDefault();
                _DbContext.getster_apps_and_categories_assignment.Remove(getData);
                _DbContext.SaveChanges();
                response.Message = "Category Deleted successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured ! While Deleting the data !!";
                response.Status = false;
            }
            return response;
        }

        public Response ReLocateApp(getster_app_categories_parent2 getster_app_categories_parent2)
        {
            Response response = new Response();
            try
            {
                getster_apps_and_categories_assignment getster_Apps_And_Categories_Assignment = new getster_apps_and_categories_assignment
                {
                    getster_app_category_location = getster_app_categories_parent2.getster_app_category_location,
                    getster_apps_and_categories_assignment_id = getster_app_categories_parent2.getster_apps_and_categories_assignment_id
                };

                _DbContext.Attach(getster_Apps_And_Categories_Assignment);
                _DbContext.Entry(getster_Apps_And_Categories_Assignment).Property(p => p.getster_app_category_location).IsModified = true;
                _DbContext.SaveChanges();

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
    }
}
