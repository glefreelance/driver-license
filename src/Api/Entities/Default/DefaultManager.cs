using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Api.Entities.Default
{
    public class DefaultManager
    {
        protected readonly Repository<DefaultEntity> _defaultRes;

        public DefaultManager(DbContext context)
        {
            _defaultRes = new Repository<DefaultEntity>(context);
        }

        public DefaultEntity DbInfo()
        {
            var info = _defaultRes.Query().FirstOrDefault();
            return info;
        }

        public List<TableSchema> TableSchemas()
        {
            var sqlQuery = @"
                    SELECT TABLE_NAME,COLUMN_NAME, DATA_TYPE
                    FROM INFORMATION_SCHEMA.COLUMNS
                    WHERE TABLE_NAME <> '__MigrationHistory'
                ";

            var schema = this._defaultRes.SqlQuery<Schema>(sqlQuery).ToList();

            var rs = from a in schema.GroupBy(g => g.TABLE_NAME)
                     select new TableSchema
                     {
                         TableName = a.Key,
                         Columns = a.Select(c => new ColumnSchema
                         {
                             ColumnName = c.COLUMN_NAME,
                             ColumnType = c.DATA_TYPE
                         }).ToList()
                     };

            return rs.ToList();
        }

        public class Schema
        {
            public string TABLE_NAME { get; set; }
            public string COLUMN_NAME { get; set; }
            public string DATA_TYPE { get; set; }
        }

        public class TableSchema
        {
            public string TableName { get; set; }
            public List<ColumnSchema> Columns { get; set; }

        }

        public class ColumnSchema
        {
            public string ColumnName { get; set; }
            public string ColumnType { get; set; }
        }
    }
}