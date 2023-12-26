﻿
using Hospital_Management_System.HospitalDataManager.DAL;
using Hospital_Management_System.HospitalDataManager.IDAL;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Hospital_Management_System.Extension
{
    public static class DataManager
    {
        public static IServiceCollection AddAppSetting(this IServiceCollection services)
        {
            services.AddScoped<IDBManager>(AddDBManager);
            //services.AddScoped<IEmployeeBAL, EmployeeBAL>;
            //services.AddScoped<IEmployeeBAL, EmployeeBAL>();

            return services;
        }
        internal static IDBManager AddDBManager(IServiceProvider serviceProvider)
        {
            IConfiguration Configuration = serviceProvider.GetRequiredService<IConfiguration>();

            string dbconstr = Configuration.GetConnectionString("DefaultConnection");
            return GetDBManager(dbconstr);


        }
        public static IDBManager GetDBManager(string connectionString)
        {
            DbConnection dbconn = new MySqlConnection(connectionString);
            return new DBManager(dbconn);
        }
    }
}