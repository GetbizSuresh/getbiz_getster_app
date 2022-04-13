using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getbiz_getster_app
{
    public class getster_app_update_status
    {
        [Key]
        public int getster_app_id { get; set; }
        public DateTime getster_app_update_time_stamp { get; set; }
    }
}
