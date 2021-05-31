using GFN.PrivateWebApi.AppLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace GFN.PrivateWebApi.Repositories
{
    public class SampleSQLRepository : ISampleRepository
    {
        IDbConnection connection;

        public SampleSQLRepository(IDbConnection connection)
        {
            this.connection = connection;
        }


        public List<string> GetLastValues(int count)
        {
            return this.connection.Query<string>($"SELECT TOP {count} value from TestTable order by id desc ").ToList();
        }
    }
}
