using getbiz_getster_app.Repository.Getster_App_Time_Stamp_Description;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_getster_app.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]

    public class GetsterAppTimeStampDescriptionController : ControllerBase
    {
        private IGetsterAppTimeStampDescriptionRepository getsterAppTimeStampDescriptionRespository;

        public GetsterAppTimeStampDescriptionController(IGetsterAppTimeStampDescriptionRepository _getsterAppTimeStampDescriptionRespository)
        {
            getsterAppTimeStampDescriptionRespository = _getsterAppTimeStampDescriptionRespository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddEditTimeStampDescription")]
        public IActionResult AddCategorySubCategory(getster_app_about_demo getster_App_About_Demo)
        {
            try
            {
                var messages = getsterAppTimeStampDescriptionRespository.AddEditGetsterAppTimeStampDescription(getster_App_About_Demo);
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
       // [HttpDelete] 
        [HttpPost]     //This is Delete Methode
        [Route("api/DeleteTimeStampDescription")]
        public IActionResult DeleteTimeStampDescription(getster_app_about_demo getster_App_About_Demo)
        {
            try
            {
                var messages = getsterAppTimeStampDescriptionRespository.DeleteGetsterAppTimeStampDescription(getster_App_About_Demo);
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
        [HttpGet]
        [Route("api/GetAllGetsterAppTimeStampDescription")]
        public IActionResult GetAllGetsterAppTimeStampDescription()
        {
            try
            {
                var messages = getsterAppTimeStampDescriptionRespository.GetAllGetsterAppTimeStampDescription();
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
