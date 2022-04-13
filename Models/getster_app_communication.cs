using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_getster_app.Models
{
    public class getster_app_communication
    {
        [Key]
        public int communication_id { get; set; }
        public string communication_timestamp { get; set; }
        public int getster_id { get; set; }
        public string communication_text { get; set; }
    }
}
