using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MySqlDbContex: DbContext
    {
        protected readonly IConfiguration Configuration;

        public MySqlDbContex(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration.GetConnectionString("MySqlConnEctionString");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), mySqlOptionsAction =>
            {
                mySqlOptionsAction.EnableRetryOnFailure();
            });

        }


        public DbSet<UserModel> user { get; set; }
        public DbSet<CategoryModel> category { get; set; }
        public DbSet<DoctorModel> doctor { get; set; }
        public DbSet<PeroidModel> periode { get; set; }
        public DbSet<MedicalModel> medical { get; set; }

    }
}
