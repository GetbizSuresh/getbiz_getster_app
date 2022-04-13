using getbiz_getster_app.Models;
using getbiz_getster_app.Repository.Getster_App_Communication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_getster_app.Controllers
{
    [ApiController]
    public class GetsterAppCommunicationController : ControllerBase
    {
        private IGetsterAppCommunicationRepository getsterAppCommunicationRepository;

        public GetsterAppCommunicationController(IGetsterAppCommunicationRepository _getsterAppCommunicationRepository)
        {
            getsterAppCommunicationRepository = _getsterAppCommunicationRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/SaveCommunicationData")]
        public IActionResult SaveCommunicationData(getster_app_communication getster_app_communication)
        {
            try
            {
                var messages = getsterAppCommunicationRepository.SaveCommunicationData(getster_app_communication);
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
        [Route("api/DeleteCommunicationData")]
        public IActionResult DeleteCommunicationData(int getster_id)
        {
            try
            {
                var messages = getsterAppCommunicationRepository.DeleteCommunicationData(getster_id);
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
        [Route("api/DeleteCommunicationDataById")]
        public IActionResult DeleteCommunicationDataById(int communication_ID, int getster_id)
        {
            try
            {
                var messages = getsterAppCommunicationRepository.DeleteCommunicationDataById(communication_ID, getster_id);
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
        [Route("api/UpdateCommunicationData")]
        public IActionResult UpdateCommunicationData(getster_app_communication getster_app_communication)
        {
            try
            {
                var messages = getsterAppCommunicationRepository.UpdateCommunicationData(getster_app_communication);
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
        //[Route("api/GetAllCommunicationDataById")]
        //public IActionResult GetAllCommunicationDataById(int CommunicationId,int getster_id)
        //{
        //    try
        //    {
        //        var messages = getsterAppCommunicationRepository.GetAllCommunicationDataById(CommunicationId, getster_id);
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
        [HttpGet]
        [Route("api/GetAllCommunicationData")]
        public IActionResult GetAllCommunicationData(int getster_id)
        {
            try
            {
                var messages = getsterAppCommunicationRepository.GetAllCommunicationData(getster_id);
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

