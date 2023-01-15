using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Sortech.DBConn;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
//using static Syncfusion.Common.CommonList;
using System.Data;

namespace Sortech.Common
{
    public class CommonList
    {
        public CommonList()
        {
        }

        /// <summary>
        /// DropDown Y/N
        /// </summary>
        public class DwCodeval
        {
            public string Name { get; set; }

            public string Code { get; set; }
        }

        private DataSet DataCall(string db, string manageCD)
        {
            DBConnection dbconn = new(db);

            using (SqlConnection connection = new(dbconn.ConnectionString))
            {
                // 사업장 코드 DW
                string queryString = @"SELECT ManageCD AS codeCD, ManageNM AS codeNM 
                                        FROM SortechSQL..CodeInfo 
                                        WHERE manageCD = '" + manageCD + "' User_yn = 'Y' ";

                SqlDataAdapter adapter = new(queryString, connection);
                
                DataSet dt = new DataSet();
                try
                {
                    connection.Open();
                    adapter.Fill(dt);// using sqlDataAdapter we process the query string and fill the data into dataset
                }
                catch (SqlException se)
                {
                    Console.WriteLine(se.ToString());
                }
                finally
                {
                    connection.Close();
                }

                return dt;
            }
        }

        /// <summary>
        /// DropDown에 Y/N 셋팅
        /// </summary>
        /// <returns></returns>
        public List<DwCodeval> CommDropdownYN()
        {
            List<DwCodeval> _DropdownYN = new List<DwCodeval>
            {
                new DwCodeval() { Name = "Y", Code = "Y" },
                new DwCodeval() { Name = "N", Code = "N" }
            };

            return _DropdownYN;

        }

        /// <summary>
        /// 기준정보를 DropDown에 셋팅
        /// </summary>
        /// <param name="db">데이터 베이스 접속이름</param>
        /// <param name="manageCD">관리코드</param>
        /// <returns></returns>
        public List<DwCodeval> CommDropdownCode(string db, string manageCD)
        {
            DataSet dt = DataCall(db, manageCD);

            List<DwCodeval> _DropdownCode = dt.Tables[0].AsEnumerable().Select(r => new DwCodeval
            {
                Name = r.Field<string>("codeNM"),
                Code = r.Field<string>("codeCD")
            }
                ).ToList();  // here we convert dataset into list

            return _DropdownCode;
        }
    }
}
