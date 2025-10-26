using Microsoft.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace hhmDapper_Test3
{
    public class DapperService
    {
        private SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "hhmDTNetTrainingTest1",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
      

        public void Read()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            //int result = db.Execute(@"SELECT [StudentId]
            //                          ,[StudentNo]
            //                      ,[StudentName]
            //                        ,[FatherName]
            //                     ,[DateOfBirth]
            //                ,[Gender]
            //                   ,[Address]
            //                 ,[DeleteFlag]
            //             FROM [dbo].[Tbl_Student1]");
            List<Student> Lst = db.Query<Student>("select * from tbl_Student1").ToList();
            for (int i = 0; i < Lst.Count; i++)

            {
                Student item = Lst[i];
                Console.WriteLine($"{i + 1}  {item.Studentno} - {item.StudentName}");
            }
        }
        public void Create()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            int results = db.Execute(@"INSERT INTO [dbo].[Tbl_Student1]
           ([StudentNo]
           ,[StudentName]
           ,[FatherName]
           ,[DateOfBirth]
           ,[Gender]
           ,[Address]
           ,[DeleteFlag])
     VALUES
           ('S006'
           ,'Thandar'
           ,'U Nyein'
           ,'23/6/2006'
           ,'Female'
           ,'Yangon'
           ,'0'");
            Console.WriteLine($"{results} rows affected");

        }

        public void Update()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            int redults = db.Execute(@"UPDATE [dbo].[Tbl_Student1]
                                       SET [StudentNo] = 'S001'
                                           [StudentName] ='Ngwe'
                                    WHERE StudentId = 5");
            Console.WriteLine($"{results} rows affected");
        }
        public void Delete()
        {
            using IDbConnection db = new SqlConnection( sb.ConnectionString);
            db.Open();
            int redults = db.Execute(@"DELETE FROM [dbo].[Tbl_Student1]
                                     SET DeleteFlag = 1
                                     WHERE StudentId = 5");
              Console.WriteLine($"{results} rows affected");

        }
    }
}
