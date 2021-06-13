using Dapper;
using DapperAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.Model
{
    public class ProductRepository : IProductRepository
    {
        private string connectionString;
        public ProductRepository()
        {
            connectionString = @"Server=(localdb)\Mssqllocaldb;Database=DAPPERDB;Trusted_Connection=True;MultipleActiveResultSets=True";
        }
 
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public Product Add(Product prod)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO ProductInfo (Name,Quantity,Price) Values (@Name,@Quantity,@Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery,prod);
            }
            return prod;
        }
        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * From ProductInfo";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery);
            }
        }
        public Product GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * From ProductInfo Where ProductId = @Id";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery,new { Id = id }).FirstOrDefault();
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM ProductInfo Where ProductId = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { ID = id });
            }
        }
        public void Update(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE ProductInfo SET Name=@Name, Quantity=@Quantity,
                                                      Price=@Price  WHERE ProductId = @ProductId";
                dbConnection.Open();
                dbConnection.Query(sQuery,prod);
            }
        }
    }
}
