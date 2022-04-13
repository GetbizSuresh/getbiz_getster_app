using getbiz_getster_app.Repository.Get_Categories_Getster_Apps;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_getster_app.Controllers
{
    public class GetCategoriesGetsterAppsController : ControllerBase
    {

        private IGetCategoriesGetsterAppsRepository GetCategoriesGetsterAppsRepository;

        public GetCategoriesGetsterAppsController(IGetCategoriesGetsterAppsRepository _getsterAppCommentsSectionRepository)
        {
            GetCategoriesGetsterAppsRepository = _getsterAppCommentsSectionRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/GetCategoriesGetsterAppsByPath")]
        public IActionResult GetCategoriesGetsterAppsByPath(string Path,string Id)
        {
            try
            {
                var messages = GetCategoriesGetsterAppsRepository.GetCategoriesGetsterAppsByPath(Path,Id);
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
