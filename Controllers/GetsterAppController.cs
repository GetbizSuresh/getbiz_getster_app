using getbiz_getster_app.Repository.Getster_App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_getster_app.Controllers
{

    [ApiController]
    public class GetsterAppController : ControllerBase
    {
        private IGetsterAppRepository getsterAppRepository;

        public GetsterAppController(IGetsterAppRepository _getsterAppRepository)
        {
            getsterAppRepository = _getsterAppRepository;
        }

        #region Get (All values in Tables (1. getster_app_category_and_location & 2. getster_app_master)

        
        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetAllAppsForGetster")]
        public IActionResult GetAllAppsForGetster()
        {
            try
            {
                var messages = getsterAppRepository.GetAllAppsForGetster();
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
        [Route("api/GetAllAppsForGetsterById")]
        public IActionResult GetAllAppsForGetsterById(int getsterAppID)
        {
           try
           {
               var messages = getsterAppRepository.GetAllAppsForGetsterById(getsterAppID);
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

        #endregion

        #region Publish & UnPublish – (Also update getster_app_audit_trail, getster_app_update_status table)

        [AllowAnonymous]
        //[HttpPut]

        [HttpPost]      //This is PUT Methode
        [Route("api/Update_Gester_App_Development_Status")]
        public IActionResult Update_Gester_App_Development_Status(int gesterId,bool publishKey)
        {
            try
            {
                var messages = getsterAppRepository.Update_Gester_App_Development_Status(gesterId, publishKey);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion

        #region Add Edit Master table

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddEditGetsterApp")]
        public IActionResult AddEditGetsterApp([FromForm] getster_app_master_Fetchdata getster_App_Master)
        {
            try
            {
                string getimagename = getster_App_Master.getsterapp_upload_image.FileName;


                getster_App_Master.getster_app_icon_image = getimagename;
                var messages = getsterAppRepository.AddEditGetsterApp(getster_App_Master);
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

        #endregion

        #region Get (All values in Tables (1. getster_app_category_and_location & 2. getster_app_master)

        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetAllGetsterAppAuditTrail")]
        public IActionResult GetAllGetsterAppAuditTrail()
        {
            try
            {
                var messages = getsterAppRepository.GetAllGetsterAppAuditTrail();
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

        #endregion
    }
}
