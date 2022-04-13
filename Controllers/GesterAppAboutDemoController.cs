using getbiz_getster_app.Repository.Getster_App_About_Demo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_getster_app.Controllers
{
    [ApiController]
    public class GesterAppAboutDemoController : ControllerBase
    {
        private IGetster_App_About_DemoRespository getster_App_About_DemoRespository;

        public GesterAppAboutDemoController(IGetster_App_About_DemoRespository _getster_App_About_DemoRespository)
        {
            getster_App_About_DemoRespository = _getster_App_About_DemoRespository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddEditGetsterAppAboutDemo")]
        public IActionResult AddEditGetsteAppAboutDemo([FromBody]getster_app_about_demo getster_App_About_Demo)
        {
            try
            {

                var messages = getster_App_About_DemoRespository.AddEditGetsteAppAboutDemo(getster_App_About_Demo);
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
        [Route("api/DeleteGetsterAppAboutDemo")]
        public IActionResult DeleteGetsteAppAboutDemo(getster_app_about_demo getster_App_About_Demo)
        {
            try
            {
                var messages = getster_App_About_DemoRespository.DeleteGetsteAppAboutDemo(getster_App_About_Demo);
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
        [Route("api/GetAllGetsteAppAboutDemo")]
        public IActionResult GetAllGetsteAppAboutDemo()
        {
            try
            {
                var messages = getster_App_About_DemoRespository.GetAllGetsteAppAboutDemo();
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
        [Route("api/GetGetsteAppAboutDemoById")]
        public IActionResult GetGetsteAppAboutDemoById(int getster_app_id)
        {
            try
            {
                var messages = getster_App_About_DemoRespository.GetGetsteAppAboutDemoById(getster_app_id);
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
