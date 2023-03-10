// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.Data.SqlClient;
using MySqlConnector;
using Microsoft.EntityFrameworkCore;
using Sortech.DBConn;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Sortech.Model_MariaDB
{
    public class Repository_M_Menulist : IRepository_M_Menulist
    {
        DBConnection dbconn = new DBConnection("sortech_MARIADB");

        public static List<M_Menulist> menuAll = new List<M_Menulist>();

        private readonly sortech_MariaDB_Context _DB;

        public Repository_M_Menulist(sortech_MariaDB_Context DB)
        {
            _DB = DB;
        }

        public List<M_Menulist> MenuCall_SQL()
        {
            menuAll.Clear();

            List<M_Menulist> rootmenu = new List<M_Menulist>();

            rootmenu = SelectNode_SQL(1);

            foreach (var _m in rootmenu)
            {
                menuAll.Add(new M_Menulist() 
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
                    Class = _m.Class
                });

                if (_m.Leaf_Yn == "N")
                {
                    List<M_Menulist> menuSub = new List<M_Menulist>();

                    menuSub = SubMenuCreate(menuSub, _m);

                    if (menuSub.Count > 0)
                        menuAll.AddRange(menuSub);
                }
            }

            return menuAll;
        }

        private List<M_Menulist> SubMenuCreate(List<M_Menulist> makemenu, M_Menulist parmenu)
        {
            List<M_Menulist> submenu = new List<M_Menulist>();

            string query = @"SELECT MenuId
                         , ParentMenuId
                         , PageName
                         , MenuName
                         , Menu_Type
                         , IFNULL(Icon, '') AS Icon
                         , User_yn
                         , Sort_No
                         , Leaf_YN
                         , Class
                        FROM MenuList
                        WHERE ParentMenuId = " + parmenu.MenuId + " ORDER BY Sort_No";

            submenu = _DB.M_Menulist.FromSqlRaw(query).ToList();

            foreach (var _m in submenu)
            {
                makemenu.Add(new M_Menulist()
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
                    Class = _m.Class
                });

                if (_m.Leaf_Yn == "N")
                {
                    List<M_Menulist> menuSub = new List<M_Menulist>();

                    menuSub = SubMenuCreate(menuSub, _m);

                    if (menuSub.Count > 0)
                        makemenu.AddRange(menuSub);
                }
            }

            return makemenu;
        }

        private List<M_Menulist> SelectNode_SQL(int menuid)
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
                         , Class
                        FROM MenuList
                        WHERE ParentMenuId = " + menuid + " ORDER BY Sort_No";

            return _DB.M_Menulist.FromSqlRaw(query).ToList();
        }

        public void Insert_SQL(M_Menulist menulist)
        {
            using (MySqlConnection connection = new MySqlConnection(dbconn.ConnectionString))
            {
                try
                {
                    string query = @"INSERT INTO MenuList
                       (MenuId, ParentMenuId, PageName, MenuName, Menu_Type, Icon, User_yn, Sort_No ,Leaf_Yn, Class)
                    VALUES
                        (@MenuId, @ParentMenuId, @PageName, @MenuName, @Menu_Type, @Icon, @User_yn, @Sort_No, @Leaf_Yn, @Class)";

                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = query;

                    command.Parameters.AddWithValue("@MenuId", menulist.MenuId);
                    command.Parameters.AddWithValue("@ParentMenuId", menulist.ParentMenuId);
                    command.Parameters.AddWithValue("@PageName", menulist.PageName);
                    command.Parameters.AddWithValue("@MenuName", menulist.MenuName == null ? "" : menulist.MenuName);
                    command.Parameters.AddWithValue("@Menu_Type", menulist.Menu_Type == null ? "" : menulist.Menu_Type);
                    command.Parameters.AddWithValue("@Icon", menulist.Icon == null ? "" : menulist.Icon);
                    command.Parameters.AddWithValue("@User_yn", menulist.User_yn);
                    command.Parameters.AddWithValue("@Sort_No", menulist.Sort_No == null ? 999 : menulist.Sort_No);
                    command.Parameters.AddWithValue("@Leaf_Yn", menulist.Leaf_Yn);
                    command.Parameters.AddWithValue("@Class", menulist.Class);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Update_SQL(M_Menulist menulist)
        {
            using (MySqlConnection connection = new MySqlConnection(dbconn.ConnectionString))
            {
                try
                {
                    string query = @"UPDATE MenuList
                                          SET
                                            ParentMenuId = @ParentMenuId,
                                            PageName = @PageName,
                                            MenuName = @MenuName,
                                            Menu_Type = @Menu_Type,
                                            Icon = @Icon,
                                            User_yn = @User_yn,
                                            Sort_No = @Sort_No,
                                            Leaf_Yn = @Leaf_Yn,
                                            Class = @Class
                                         WHERE MenuId = @MenuId ";

                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = query;

                    command.Parameters.AddWithValue("@MenuId", menulist.MenuId);
                    command.Parameters.AddWithValue("@ParentMenuId", menulist.ParentMenuId);
                    command.Parameters.AddWithValue("@PageName", menulist.PageName);
                    command.Parameters.AddWithValue("@MenuName", menulist.MenuName == null ? "" : menulist.MenuName);
                    command.Parameters.AddWithValue("@Menu_Type", menulist.Menu_Type == null ? "" : menulist.Menu_Type);
                    command.Parameters.AddWithValue("@Icon", menulist.Icon == null ? "" : menulist.Icon);
                    command.Parameters.AddWithValue("@User_yn", menulist.User_yn);
                    command.Parameters.AddWithValue("@Sort_No", menulist.Sort_No == null ? "" : menulist.Sort_No);
                    command.Parameters.AddWithValue("@Leaf_Yn", menulist.Leaf_Yn);
                    command.Parameters.AddWithValue("@Class", menulist.Class);

                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        
        public void Delete_SQL(M_Menulist menulist)
        {
            using (MySqlConnection connection = new MySqlConnection(dbconn.ConnectionString))
            {
                try
                {
                    string query = @"DELETE MenuList WHERE MenuId = @MenuId ";

                    MySqlCommand command = connection.CreateCommand();

                    command.CommandText = query;

                    command.Parameters.AddWithValue("@MenuId", menulist.MenuId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

    }
}