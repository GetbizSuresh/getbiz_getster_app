namespace getbiz_getster_app.Repository.Getster_App_Comments_Section
{
    public interface IGetsterAppCommentsSectionRepository
    {
        Response GetAllComments(int getster_id);
        Response SaveComments(comment_for_getster comment_For_Getster);
        Response DeleteComment(int getster_id);

        Response DeleteCommentById(int comment_id, int getster_id);
        Response SavePublicPrivateComment(int getster_id, int is_the_comment_private);
        Response UpdateComments(comment_for_getster comment_For_Getster);
    }
}
