using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getbiz_getster_app
{
   
    public class getster_app_master  
    {
        [Key]
        public int getster_app_id { get; set; }
        public string getster_app_icon_name { get; set; }
        public string getster_app_icon_image { get; set; }
        public bool getster_app_development_status { get; set; }
        public string getster_app_title_bar_name { get; set; }
        public string getster_app_name { get; set; }

    }
    //public class getster_app_names  
    //{
    //    [Key]
    //    public int getster_app_id { get; set; }
    //    public string getster_app_name { get; set; }
    //}


    public class getster_app_master_Fetchdata
    {
        [Key]
        public int getster_app_id { get; set; }
        public string getster_app_icon_name { get; set; }
        public string getster_app_icon_image { get; set; }
        public IFormFile getsterapp_upload_image { get; set; }
        public string getster_app_title_bar_name { get; set; }
        public bool getster_app_development_status { get; set; }
        public string getster_app_name { get; set; }


    }









}
