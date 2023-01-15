﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
//using Syncfusion.Blazor.Data;
using Sortech.DBConn;

namespace Sortech.Model_SqlServerDB
{
    public class Repository_GroupCodeInfo : IRepository_GroupCodeInfo
    {
        private readonly sortech_SqlServerDB_Context _DB;

        public Repository_GroupCodeInfo(sortech_SqlServerDB_Context DB)
        {
            _DB = DB;
        }

        public async Task<List<CGroupCodeInfo>> SelectAll()
        {
            return await _DB.GroupCodeInfo.OrderBy(i => i.ManageCd).ToListAsync();
        }

        public async Task<List<CGroupCodeInfo>> Select(string manageCD)
        {
            //return await _DB.GroupCodeInfo.Where(x=>x.CorpCd == corpCD & x.ManageCd == manageCD).ToListAsync();
            return await _DB.GroupCodeInfo.Where(x => x.ManageCd == manageCD).OrderBy(i => i.ManageCd).ToListAsync();
        }

        public async void Insert(CGroupCodeInfo groupCodeInfo)
        {
            try
            {
                await _DB.GroupCodeInfo.AddAsync(groupCodeInfo);
                _DB.SaveChanges();

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Delete(string manageCD)
        {
            try
            {
                CGroupCodeInfo groupCodeInfo = _DB.GroupCodeInfo.Find(manageCD);
                _DB.GroupCodeInfo.Remove(groupCodeInfo);
                _DB.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void Update(string manageCd, CGroupCodeInfo groupCodeInfo)
        {
            try
            {
                var local = _DB.Set<CGroupCodeInfo>().Local.SingleOrDefault(x => x.ManageCd.Equals(manageCd));
                // check if local is not null
                if (local != null)
                {
                    // detach
                    _DB.Entry(local).State = EntityState.Detached;
                }
                _DB.Entry(groupCodeInfo).State = EntityState.Modified;
                _DB.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}