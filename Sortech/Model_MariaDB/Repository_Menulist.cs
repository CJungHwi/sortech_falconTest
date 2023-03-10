// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.Data.SqlClient;
using MySqlConnector;
using Microsoft.EntityFrameworkCore;
using Sortech.DBConn;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Sortech.Model_MariaDB
{
    public class Repository_Menulist : IRepository_Menulist
    {
        DBConnection dbconn = new DBConnection("sortech_MARIADB");

        public static List<Menulist> menuAll = new List<Menulist>();

        private readonly sortech_MariaDB_Context _DB;

        public Repository_Menulist(sortech_MariaDB_Context DB)
        {
            _DB = DB;
        }

        public async Task<List<Menulist>> MenuCall_SQL()
        {
            menuAll.Clear();

            List<Menulist> rootmenu = new List<Menulist>();

            rootmenu = SelectNode_SQL(1);

            foreach (var _m in rootmenu)
            {
                menuAll.Add(new Menulist() 
                { 
                    MenuId = _m.MenuId,
                    ParentMenuId = _m.ParentMenuId == 0 ? null : _m.ParentMenuId,
                    PageName = _m.PageName,
                    MenuName = _m.MenuName,
                    Menu_Type = _m.Menu_Type,
                    Icon = _m.Icon,
                    User_yn= _m.User_yn,
                    Sort_No= _m.Sort_No,
                    Leaf_Yn= _m.Leaf_Yn,
                    Expanded = true,
                    HasSubFolders = true,
                    Class = _m.Class
                });

                if (_m.Leaf_Yn == "N")
                {
                    List<Menulist> menuSub = new List<Menulist>();

                    menuSub = SubMenuCreate(menuSub, _m);

                    if (menuSub.Count > 0)
                        menuAll.AddRange(menuSub);
                }
            }

            return menuAll;
        }

        private List<Menulist> SubMenuCreate(List<Menulist> makemenu, Menulist parmenu)
        {
            List<Menulist> submenu = new List<Menulist>();

            string query = @"SELECT MenuId
                         , ParentMenuId
                         , PageName
                         , MenuName
                         , Menu_Type
                         , IFNULL(Icon, '') AS Icon
                         , User_yn
                         , Sort_No
                         , Leaf_YN
                         , false AS Expanded
                         , false AS HasSubFolders
                         , Class
                        FROM MenuList
                        WHERE ParentMenuId = " + parmenu.MenuId + " ORDER BY Sort_No";

            submenu = _DB.Menulist.FromSqlRaw(query).ToList();

            foreach (var _m in submenu)
            {
                makemenu.Add(new Menulist()
                {
                    MenuId = _m.MenuId,
                    ParentMenuId = _m.ParentMenuId == 0 ? null : _m.ParentMenuId,
                    PageName = _m.PageName,
                    MenuName = _m.MenuName,
                    Menu_Type = _m.Menu_Type,
                    Icon = _m.Icon,
                    User_yn = _m.User_yn,
                    Sort_No = _m.Sort_No,
                    Leaf_Yn = _m.Leaf_Yn,
                    Expanded = false,
                    HasSubFolders = _m.Menu_Type == "F" ? true : false,
                    Class = _m.Class
                });

                if (_m.Leaf_Yn == "N")
                {
                    List<Menulist> menuSub = new List<Menulist>();

                    menuSub = SubMenuCreate(menuSub, _m);

                    if (menuSub.Count > 0)
                        makemenu.AddRange(menuSub);
                }
            }

            return makemenu;
        }

        private List<Menulist> SelectNode_SQL(int menuid)
        {
            string query = @"SELECT MenuId
                         , ParentMenuId
                         , PageName
                         , MenuName
                         , Menu_Type
                         , IFNULL(Icon, '') AS Icon
                         , User_yn
                         , Sort_No
                         , Leaf_YN
                         , false AS Expanded
                         , false AS HasSubFolders
                         , Class
                        FROM MenuList
                        WHERE ParentMenuId = " + menuid + " ORDER BY Sort_No";

            return _DB.Menulist.FromSqlRaw(query).ToList();
        }
    }
}