using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QYH.BlukInsertTest.FileMange;
using QYH.BlukInsertTest.DataBase;
using System.Diagnostics;

namespace QYH.BlukInsertTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //用于生成海量数据
            //GenerateTestData();

            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                BulkInsertTest();
            }
            catch (Exception)
            {

                //throw;
            }

            stopwatch.Stop();
            string strResult = "批量插入耗时：" + stopwatch.ElapsedMilliseconds.ToString();

            Stopwatch stopwatch1 = Stopwatch.StartNew();
            CommonInsertTest();
            stopwatch1.Stop();
            string str1Result = "普通插入耗时：" + stopwatch1.ElapsedMilliseconds.ToString();

            string strTestResult = "result";
            File.WriteTextAsync(strResult + "\r\n" + str1Result, strTestResult);

            //Console.Read();
        }

        /// <summary>
        /// 批量插入测试
        /// </summary>
        private static void BulkInsertTest()
        {
            string strFilePath = @"D:\学习\ASP.NET\QYH.BlukInsertTest\sql.txt";
            string strTableName = "Student";

            /* 每一个字段的信息以“,”分割 
            *每一条数据以“|”符号分隔
            * 每10万条数据一个事务*/
            string sql = string.Format("BULK INSERT {0} FROM '{1}' WITH (FIELDTERMINATOR = ',',ROWTERMINATOR ='|',BATCHSIZE = 50000)", strTableName, strFilePath);
            DBHelper dbHelper = new DBHelper();
            dbHelper.Excute(sql);

        }

        /// <summary>
        /// 普通插入测试
        /// </summary>
        private static void CommonInsertTest()
        {
            int i = 1;
            while (i <= 500000)
            {
                string sqlInsert = string.Format("insert into Student1(id,Name,Age) values({0},'test{0}',{0})", i);
                new DBHelper().Excute(sqlInsert);
                i++;
            }
        }

        /// <summary>
        /// 生成测试数据
        /// </summary>
        private static void GenerateTestData()
        {
            string fileName = "sql";

            int i = 1;
            while (i <= 500000)
            {
                string strInsert = string.Format("{0},'test{0}',{0}|", i);
                File.AppendText(strInsert, fileName);
                i++;
            }
        }
    }
}
