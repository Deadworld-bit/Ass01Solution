using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class BaseDAL
    {
        public AssignmentDataProvider dataProvider { get; set; } = null;
        public SqlConnection connection = null;

        public BaseDAL()
        {
            var connectionString = GetConnectionString();
            dataProvider = new AssignmentDataProvider(connectionString);
        }

        public string GetConnectionString()
        {
            string connectionString;
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json", true, true).Build();
            connectionString = config["ConnectionString:MyStockDB"];
            return connectionString;
        }

        public void CloseConneciton() => dataProvider.CloseConnection(connection);
    }
}

