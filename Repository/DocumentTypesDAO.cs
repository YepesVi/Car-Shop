using Dapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DocumentTypesDAO : IDocumentTypes
    {
        private readonly IDbConnection _dbconnection;

        public DocumentTypesDAO(IDbConnection dbconnection)
        {
            _dbconnection = dbconnection;
        }
        public async Task<IEnumerable<DocumentTypes>> GetAllDocumentTypesAsync()
        {
            var sql = @"SELECT * FROM DocumentTypes";

            return await _dbconnection.QueryAsync<DocumentTypes>(sql, new { });
        }
    }
}
