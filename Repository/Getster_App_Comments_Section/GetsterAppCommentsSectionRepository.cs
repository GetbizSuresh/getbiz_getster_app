using System;

namespace getbiz_getster_app.Repository.Getster_App_Comments_Section
{
    public class GetsterAppCommentsSectionRepository : IGetsterAppCommentsSectionRepository
    {
        public readonly Getbizdb_DbContext _DbContext;
        public GetsterAppCommentsSectionRepository(Getbizdb_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response GetAllComments(int getster_id)
        {
            Response response = new Response();
            try
            {
                try
                {
                    GetSetDatabase getSetDatabase = new GetSetDatabase();
                    var result = getSetDatabase.CreateCommentTableDyanmically(0, "", getster_id,
                   "",0, "",0, "GetAll");
                    response = result;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = ResponceMessage.CommentAdded_ErrorMessage;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }

       

        public Response SaveComments(comment_for_getster comment_For_Getster)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.CreateCommentTableDyanmically(0, comment_For_Getster.comment_timestamp, comment_For_Getster.getster_id,
                 comment_For_Getster.comment_text,  comment_For_Getster.is_the_comment_private, 
                comment_For_Getster.comment_reply, comment_For_Getster.comment_reply_by_getster_id, "Insert");
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ResponceMessage.CommentAdded_ErrorMessage;
            }
            return response;
        }

        public Response UpdateComments(comment_for_getster comment_For_Getster)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.CreateCommentTableDyanmically(comment_For_Getster.comment_id, comment_For_Getster.comment_timestamp, comment_For_Getster.getster_id,
                  comment_For_Getster.comment_text,  comment_For_Getster.is_the_comment_private, 
                comment_For_Getster.comment_reply, comment_For_Getster.comment_reply_by_getster_id, "EditComment");
                response.Status = result.Status;
                response.Message = result.Message;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ResponceMessage.CommentAdded_ErrorMessage;
            }
            return response;
        }
        public Response DeleteComment(int getster_id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                getSetDatabase.CreateCommentTableDyanmically(0, "",getster_id, "", 0,"",0, "Delete");
                response.Status = true;
                response.Message = ResponceMessage.CommentDeleted_SuccessMessage;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ResponceMessage.CommentDeleted_ErrorMessage;
            }
            return response;
        }

        public Response DeleteCommentById(int comment_id, int getster_id)
        {
            Response response = new Response();
            try
            {
                try
                {
                    GetSetDatabase getSetDatabase = new GetSetDatabase();
                    getSetDatabase.CreateCommentTableDyanmically(comment_id, "",getster_id,"", 0,"",0, "DeleteById");
                    response.Status = true;
                    response.Message = ResponceMessage.CommentDeleted_SuccessMessage;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = "Error occured ! white fething the data";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }

        public Response SavePublicPrivateComment(int getster_id, int is_the_comment_private)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                getSetDatabase.CreateCommentTableDyanmically(0, "",getster_id, "", is_the_comment_private, "",0, "PublicPrivateCommentUpdate");
                response.Status = true;
                response.Message = ResponceMessage.CommentPublicPrivate_SuccessMessage;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ResponceMessage.CommentPublicPrivate_ErrorMessage;
            }
            return response;
        }

    }
}
