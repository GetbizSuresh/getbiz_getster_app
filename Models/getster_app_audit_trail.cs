using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getbiz_getster_app
{
    public class getster_app_audit_trail
    {
        [Key]
        public int getster_app_audit_trail_id { get; set; }
        public int getster_app_id { get; set; }
        public string getster_app_activity { get; set; }
        public int getster_app_activity_by_getster_id { get; set; }
        public DateTime getster_app_activity_time_stamp { get; set; }
    }
}
