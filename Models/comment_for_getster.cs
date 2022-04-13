using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getbiz_getster_app
{
   public class comment_for_getster
    {
        [Key]
        public int comment_id { get; set; }
        public int getster_id { get; set; }
        public string comment_timestamp { get; set; }
        public string comment_text { get; set; }
        public int is_the_comment_private { get; set; }
        public string comment_reply { get; set; }
        public int comment_reply_by_getster_id { get; set; }
    }
}
