using getbiz_getster_app.Repository.Getster_App_Category_Location;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_getster_app.Controllers
{
    [ApiController]
    public class GetsterAppCategoryLocationController : ControllerBase
    {
        private IGetsterAppCategoryLocationRespository getsterAppCategoryLocationRespository;

        public GetsterAppCategoryLocationController(IGetsterAppCategoryLocationRespository _getsterAppCategoryLocationRespository)
        {
            getsterAppCategoryLocationRespository = _getsterAppCategoryLocationRespository;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            try
            {
                var messages = getsterAppCategoryLocationRespository.GetAllCategories();
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //[AllowAnonymous]
        //[HttpGet]
        //[Route("api/GetAllCategoriesById")]
        //public IActionResult GetAllCategoriesById(int getster_app_id)
        //{
        //    try
        //    {
        //        var messages = getsterAppCategoryLocationRespository.GetAllCategoriesById(getster_app_id);
        //        if (messages == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(messages);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}


        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddCategorySubCategory")]
        public IActionResult AddCategorySubCategory(getster_app_categories getster_app_categories)
        {
            try
            {
                var messages = getsterAppCategoryLocationRespository.AddCategorySubCategory(getster_app_categories);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddCategorySubCategorygetster")]
        public IActionResult AddCategorySubCategorygetster(getster_app_categories_parent1 getster_app_categories_parent1)
        {
            try
            {
                var messages = getsterAppCategoryLocationRespository.AddCategorySubCategorygetster(getster_app_categories_parent1);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [AllowAnonymous]
        //[HttpDelete]
        
        [HttpPost]   //This is Delete Methode
        [Route("api/DeleteCategory")]

        public IActionResult DeleteCategory(string CategoryId)
        {
            try
            {
                var messages = getsterAppCategoryLocationRespository.DeleteCategory(CategoryId);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        //[HttpPut]
        [HttpPost]   //This is PUT Methode
        [Route("api/ModifyCategory")]
        public IActionResult ModifyCategory(getster_app_categories_parent getster_app_categories_parent)
        {
            try
            {
                var messages = getsterAppCategoryLocationRespository.Modify(getster_app_categories_parent);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/ReAssignApps")]
        public IActionResult ReAssignApps(getster_app_categories_parent1 getster_app_categories_parent1 )
        {
            try
            {
                var messages = getsterAppCategoryLocationRespository.ReAssignApps(getster_app_categories_parent1);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/ReAssignAppsDeletegetsterId")]
        public IActionResult ReAssignAppsDeletegetsterId(getster_app_categories_parent1 getster_app_categories_parent1)
        {
            try
            {
                var messages = getsterAppCategoryLocationRespository.ReAssignAppsDeletegetsterId(getster_app_categories_parent1);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/ReLocateApp")]
        public IActionResult ReLocateApp(getster_app_categories_parent2 getster_app_categories_parent2)
        {
            try
            {
                var messages = getsterAppCategoryLocationRespository.ReLocateApp(getster_app_categories_parent2);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
