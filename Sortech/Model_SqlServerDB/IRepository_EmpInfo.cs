﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
namespace Sortech.Model_SqlServerDB
{
    public interface IRepository_EmpInfo
    {
        // 전체 가져오기
        List<CEmpInfo_proc> Select_proc();

        // 저장하기
        void Insert_proc(CEmpInfo_proc empInfo_Proc);
        
        // 삭제하기
        void Delete_proc(CEmpInfo_proc empInfo_Proc);

        // 업데이트하기
        void Update_proc(CEmpInfo_proc empInfo_Proc);
    }
}