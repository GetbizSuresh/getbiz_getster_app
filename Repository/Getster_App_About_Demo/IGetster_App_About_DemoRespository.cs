namespace getbiz_getster_app.Repository.Getster_App_About_Demo
{
    public interface IGetster_App_About_DemoRespository
    {
        Response AddEditGetsteAppAboutDemo(getster_app_about_demo getster_App_About_Demo);
        Response DeleteGetsteAppAboutDemo(getster_app_about_demo getster_App_About_Demo);
        Response GetAllGetsteAppAboutDemo();
        Response GetGetsteAppAboutDemoById(int getster_app_id);
    }
}
