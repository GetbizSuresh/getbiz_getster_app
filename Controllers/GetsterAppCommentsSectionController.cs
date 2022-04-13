using getbiz_getster_app.Repository.Getster_App_Comments_Section;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_getster_app.Controllers
{
    [ApiController]
    public class GetsterAppCommentsSectionController : ControllerBase
    {
        private IGetsterAppCommentsSectionRepository getsterAppCommentsSectionRepository;

        public GetsterAppCommentsSectionController(IGetsterAppCommentsSectionRepository _getsterAppCommentsSectionRepository)
        {
            getsterAppCommentsSectionRepository = _getsterAppCommentsSectionRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/SaveComments")]
        public IActionResult SaveComments(comment_for_getster comment_For_Getster)
        {
            try
            {
                var messages = getsterAppCommentsSectionRepository.SaveComments(comment_For_Getster);
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

        [HttpPost]     //This is Delete Methode
        [Route("api/DeleteComment")]
        public IActionResult DeleteComment(int getster_id)
        {
            try
            {
                var messages = getsterAppCommentsSectionRepository.DeleteComment(getster_id);
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
        [Route("api/DeleteCommentById")]
        public IActionResult DeleteCommentById(int comment_id, int getster_id)
        {
            try
            {
                var messages = getsterAppCommentsSectionRepository.DeleteCommentById(comment_id, getster_id);
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
        [Route("api/SavePublicPrivateComment")]
        public IActionResult SavePublicPrivateComment(int getster_id, int is_the_comment_private)
        {
            try
            {
                var messages = getsterAppCommentsSectionRepository.SavePublicPrivateComment(getster_id, is_the_comment_private);
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
        [Route("api/UpdateComments")]
        public IActionResult UpdateComments(comment_for_getster comment_For_Getster)
        {
            try
            {
                var messages = getsterAppCommentsSectionRepository.UpdateComments(comment_For_Getster);
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
        [Route("api/GetAllComments")]
        public IActionResult GetAllComments(int getster_id)
        {
            try
            {
                var messages = getsterAppCommentsSectionRepository.GetAllComments(getster_id);
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
