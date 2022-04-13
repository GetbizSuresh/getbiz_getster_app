
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace getbiz_getster_app
{
    public class getster_app_about_demo
    {
        [Key]
       // public int getster_app_about_demo_Id { get; set; }
        public int getster_app_id { get; set; }
        public string getster_app_demo_video_path { get; set; }
        public string getster_app_time_stamp_title { get; set; }
        public string getster_app_attachments_path { get; set; }
        public string getster_app_time_stamp_description { get; set; }
        
    }
}

