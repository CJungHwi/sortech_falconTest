// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
namespace Sortech.Model_SqlServerDB
{
    public interface IRepository_CodeInfo
    {
        // 전체 가져오기
        Task<List<CCodeInfo_sql>> SelectAll();

        List<CCodeInfo_sql> SelectAll_SQL();

        //특정 값만 가져오기
        //Task<List<CodeInfo>> Select(string corpCD, string manageCD);

        // 저장하기
        void Insert(CCodeInfo_sql CodeInfo);

        void Insert_SQL(CCodeInfo_sql CodeInfo);

        // 삭제하기
        void Delete(string corpCD, string manageCD);

        void Delete_SQL(CCodeInfo_sql CodeInfo);

        // 업데이트하기
        void Update(string corpCd, string manageCd, CCodeInfo_sql CodeInfo);

        void Update_SQL(CCodeInfo_sql CodeInfo);
    }
}