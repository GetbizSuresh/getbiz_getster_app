using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getbiz_getster_app
{
    public class getster_app_categories_parent
    {
        [Key]
        public string getster_app_category_id { get; set; }
        public string getster_app_category_path { get; set; }
        public string getster_app_category_name { get; set; }

        [Key]
        public int getster_apps_and_categories_assignment_id { get; set; }
        //public string getster_app_category_id { get; set; }
        public int getster_app_id { get; set; }
         //public int OrderId { get; set; }
        public int getster_app_category_location { get; set; }
        
    }


    public class getster_app_categories_parent1
    {
        [Key]
        public int getster_apps_and_categories_assignment_id { get; set; }
        public string getster_app_category_id { get; set; }
       public int getster_app_id { get; set; }
        public int getster_app_category_location { get; set; }
        
    }
    public class getster_app_categories
    {
        [Key]
        public string getster_app_category_id { get; set; }
        public string getster_app_category_path { get; set; }
        public string getster_app_category_name { get; set; }
        
        

    }

    public class getster_app_categories_parent2
    {
       
        [Key]
        public int getster_apps_and_categories_assignment_id { get; set; }
        //public string getster_app_category_id { get; set; }
        public int getster_app_id { get; set; }
        //public int OrderId { get; set; }
        public int getster_app_category_location { get; set; }

    }
}
