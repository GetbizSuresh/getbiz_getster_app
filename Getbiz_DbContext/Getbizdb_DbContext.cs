using Microsoft.EntityFrameworkCore;
//using static getbiz_getster_app.getster_app_master_parent;

namespace getbiz_getster_app
{
    public class Getbizdb_DbContext : DbContext
    {
        

        public Getbizdb_DbContext(DbContextOptions<Getbizdb_DbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<getster_app_about_demo> getster_app_about_demo { get; set; }
        public DbSet<getster_app_audit_trail> getster_app_audit_trail { get; set; }
        public DbSet<getster_app_categories> getster_app_categories { get; set; }
        public DbSet<getster_app_master> getster_app_master { get; set; }
        //public DbSet<getster_app_names> getster_app_names { get; set; }
        public DbSet<getster_app_update_status> getster_app_update_status { get; set; }
       public DbSet<getster_apps_and_categories_assignment> getster_apps_and_categories_assignment { get; set; }
        public object getster_app_categories_parent { get; internal set; }
    }
}
