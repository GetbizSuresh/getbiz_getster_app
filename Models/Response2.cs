using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getbiz_getster_app
{
    public class Response2
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Data { get; set; }
    }
    public class ParentData
    {
        public string Category_Name { get; set; }
        public List<FilterData> filterData { get; set; }
        public List<FilterData1> filterData1 { get; set; }
    }
     
    public class FilterData
    {
        public string getster_app_category_path { get; set; }
        public int getster_app_id { get; set; }
        public string getster_app_icon_name { get; set; }
        public string getster_app_web_image { get; set; }
        public string getster_app_web_link { get; set; }
        public bool getster_app_development_status { get; set; }
        public string getster_app_name { get; set; }
        public string getster_app_title_bar_name { get; set; }
        
    }

    public class FilterData1
    {
        public string getster_app_category_path { get; set; }
        public string getster_app_category_id { get; set; }
        public string getster_app_category_name { get; set; }
        public int getster_app_id { get; set; }
        public string getster_app_icon_name { get; set; }
        public string getster_app_web_image { get; set; }
        public string getster_app_web_link { get; set; }
        public bool getster_app_development_status { get; set; }
        public string getster_app_name { get; set; }
        public string getster_app_title_bar_name { get; set; }
        public int getster_apps_and_categories_assignment_id { get; set; }
    }
}
