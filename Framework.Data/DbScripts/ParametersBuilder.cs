using Dapper;
using System.Data;

namespace Framework.Data
{
    public static class ParametersBuilder
    {
        public static DynamicParameters Build()
        {
            return new DynamicParameters();
        }

        public static DynamicParameters Build(object template)
        {
            return new DynamicParameters(template);
        }

        public static DynamicParameters Build(string name, object value)
        {
            return Build().WithParameter(name, value);
        }

        public static DynamicParameters WithParameter(this DynamicParameters parameters, string name, object value)
        {
            parameters.Add(name, value);
            return parameters;
        }

        //public static DynamicParameters WithRowTimeStampAndIdentityOut(this DynamicParameters parameters, string name, DbType dbType = DbType.Int32)
        //{
        //    return parameters.WithParameterOut(name).WithRowTimeStampOut();
        //}

        //public static DynamicParameters WithParameterOut(this DynamicParameters parameters, string name, DbType dbType = DbType.Int32)
        //{
        //    parameters.Add(name, dbType: dbType, direction: ParameterDirection.Output);
        //    return parameters;
        //}

        //public static DynamicParameters WithRowTimeStampOut(this DynamicParameters parameters)
        //{
        //    parameters.WithParameterOut(Concurrency.ConcurrencyParameters.TimeStampOut, DbType.DateTime);
        //    return parameters;
        //}
    }
}
