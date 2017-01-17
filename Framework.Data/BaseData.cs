using log4net;
using System.Reflection;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Framework.Data
{
    public abstract class BaseData
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;

        protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IDbConnection Database { get; set; }

        public SqlConnection Connect
        {
            get { return new SqlConnection(_connectionString); }
        }

        public BaseData()
        {
            
        }
    }
}