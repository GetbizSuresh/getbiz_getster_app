namespace getbiz_getster_app.Repository.Getster_App_Category_Location
{
    public interface IGetsterAppCategoryLocationRespository
    {
        Response AddCategorySubCategory(getster_app_categories getster_app_categories);
        Response AddCategorySubCategorygetster(getster_app_categories_parent1 getster_app_categories_parent1);
        Response DeleteCategory(string CategotyId);
        Response Modify(getster_app_categories_parent getster_app_categories_parent);
        Response GetAllCategories();
        //Response GetAllCategoriesById(int getster_app_id);
        Response ReAssignApps(getster_app_categories_parent1 getster_app_categories_parent1);

        Response ReAssignAppsDeletegetsterId(getster_app_categories_parent1 getster_app_categories_parent1);
         Response ReLocateApp(getster_app_categories_parent2 getster_App_Categories_Parent2);
    }
}
