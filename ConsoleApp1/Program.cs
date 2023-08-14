using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.DataAccess.Repository;
using System.Configuration;

namespace test.DataAccess
{
    public class Program
    {
        public void Main()
        {
            string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WKODBConnectionString"].ConnectionString);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM Book";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // 处理每一行的数据
                        string id = reader.GetString(0);
                        string name = reader.GetString(1);
                        Console.WriteLine($"ID: {id}, Name: {name}");
                    }
                }
            }
        }
        public class Book 
        {
            public string Barcode { get; set; }
            public string BookName { get; set; }
            public string Author { get; set; }
            public string PublishingHouse { get; set; }
            public DateTime PublicationDate { get; set; }
            public int Price { get; set; }
        }
        //連接資料庫
        private readonly string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["WKODBConnectionString"].ConnectionString);

        public DataTable GetFromDatabase(string sqlQuery)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }

            return dataTable;
        }
        public IEnumerable<Book> GetBook()
        {
            using (var conn = new SqlConnection(connectionString)) 
            {
                var result = conn.Query<Book>("SELECT * FROM Book");

                try
                {
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public Book GetBookOne(string id)
        {
            var sql =
                @"SELECT TOP 1 * FROM Book Where Barcode = @id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, System.Data.DbType.String);

            using (var conn = new SqlConnection(connectionString))
            {
                var result = conn.QueryFirstOrDefault<Book>(sql, parameters);

                try
                {
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// 更新卡片
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool uptBook(string id, BookRepository parameter) 
        {
            var sql =
            @"
                UPDATE Book 
                SET
                    [BookName] = @BookName
                   ,[Author] = @Author
                   ,[PublishingHouse] = @PublishingHouse
                   ,[PublicationDate] = @PublicationDate
                   ,[Price] = @Price
                Where
                    Barcode = @id";
            var parameters = new DynamicParameters(parameter);
            parameters.Add("id", id, System.Data.DbType.String);
            using (var conn = new SqlConnection(connectionString))
            {
                var result = conn.Execute(sql, parameters);
                return result > 0;
            }
        }
        /// <summary>
        /// 新增卡片
        /// </summary>
        /// <param name="parameter">參數</param>
        /// <returns></returns>
        public Book Create(BookRepository2 parameter)
        {
            var sql =
            @"
                INSERT INTO Book 
                (
                    [Barcode]
                   ,[BookName]
                   ,[Author]
                   ,[PublishingHouse]
                   ,[PublicationDate]
                   ,[Price]
                ) 
                VALUES 
                (
                    @Barcode
                   ,@BookName
                   ,@Author
                   ,@PublishingHouse
                   ,@PublicationDate
                   ,@Price
                );
        
                SELECT @@IDENTITY;
            ";

            using (var conn = new SqlConnection(connectionString))
            {
                var result = conn.QueryFirstOrDefault<Book>(sql, parameter);
                return result;
            }
        }
        /// <summary>
        /// 刪除書本
        /// </summary>
        /// <param name="id"></param>
        public void delBook(string id)
        {
            var sql =
                @"DELETE FROM Book
                WHERE Barcode = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, System.Data.DbType.String);

            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    var result = conn.QueryFirstOrDefault<Book>(sql, parameters);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

    }
}
