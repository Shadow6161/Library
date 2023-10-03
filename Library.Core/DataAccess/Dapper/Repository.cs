using Dapper;
using Library.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Library.Core.DataAccess.Dapper
{
    public class Repository<T> : EntityRepository<T>, IRepository<T>
        where T : class, IEntity, new()
    {
        public int Add(T entity)
        {
            int addedEntity = 0;
            try
            {
                using (var connection = Connection)
                {
                    string tableName = GetTableName();
                    string columns = GetColumns(excludeKey: true);
                    string properties = GetPropertyNames(excludeKey: true);
                    string query = $"INSERT INTO {tableName} ({columns}) VALUES ({properties})";

                    addedEntity = connection.Execute(query, entity);
                }
            }
            catch (Exception ex) { }

            return addedEntity;
        }

        public bool Delete(T entity)
        {
            int rowsEffected = 0;
            try
            {
                using (var connection = Connection)
                {
                    string tableName = GetTableName();
                    string keyColumn = GetKeyColumnName();
                    string keyProperty = GetKeyPropertyName();
                    string query = $"DELETE FROM {tableName} WHERE {keyColumn} = @{keyProperty}";

                    rowsEffected = connection.Execute(query, entity);
                }
            }
            catch (Exception ex) { }

            return rowsEffected > 0 ? true : false;
        }

        public List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            List<T> result = null;
            try
            {
                using (var connection = Connection)
                {
                    string tableName = GetTableName();
                    string query = $"SELECT * FROM {tableName}";

                    result = connection.Query<T>(query).ToList();
                }
            }
            catch (Exception ex) { }

            return result;
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            T result = null;
            try
            {
                using (var connection = Connection)
                {
                    string tableName = GetTableName();
                    string keyColumn = GetKeyColumnName();
                    string query = $"SELECT * FROM {tableName} WHERE {keyColumn} = '{filter}'";

                    result = connection.Query<T>(query).FirstOrDefault();
                }
            }
            catch (Exception ex) { }

            return result;
        }

        public int Update(T entity)
        {
            int updatedEntity = 0;
            try
            {
                using (var connection = Connection)
                {
                    string tableName = GetTableName();
                    string keyColumn = GetKeyColumnName();
                    string keyProperty = GetKeyPropertyName();

                    StringBuilder query = new StringBuilder();
                    query.Append($"UPDATE {tableName} SET ");

                    foreach (var property in GetProperties(true))
                    {
                        var columnAttr = property.GetCustomAttribute<ColumnAttribute>();

                        string propertyName = property.Name;
                        string columnName = columnAttr.Name;

                        query.Append($"{columnName} = @{propertyName},");
                    }

                    query.Remove(query.Length - 1, 1);

                    query.Append($" WHERE {keyColumn} = @{keyProperty}");

                    updatedEntity = connection.Execute(query.ToString(), entity);
                }
            }
            catch (Exception ex) { }

            return updatedEntity;
        }

        public T AddAlternative(T entity)
        {
            try
            {
                using (var connection = Connection)
                {
                    string tableName = GetTableName();
                    string columns = GetColumns(excludeKey: true);
                    string properties = GetPropertyNames(excludeKey: true);
                    string query = $"INSERT INTO {tableName} ({columns}) VALUES ({properties})";

                    connection.Query(query, entity).FirstOrDefault();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return entity;
        }
    }
}
