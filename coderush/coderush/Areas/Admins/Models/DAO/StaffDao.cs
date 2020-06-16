using coderush.Areas.Admins.Models.EF;
using coderush.Areas.Admins.Models.EF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coderush.Areas.Admins.Models.DAO
{
    public class StaffDao
    {
        DBIeltsContext db;
        public StaffDao()
        {
            db = new DBIeltsContext();
        }
        #region["GET"]
        public List<staff> GetAll()
        {
            return db.staffs.ToList();
        }
        public List<staff> GetAllPageNumber(int Pagenum, int PageSize)
        {
            return db.staffs.Skip((Pagenum - 1) * PageSize).Take(PageSize).ToList();
        }
        public staff GetById(int? id)
        {
            return db.staffs.Single(i => i.sta_id == id);
        }
        public List<StaffViewModel> GetAllSearch(int Pagenum, int PageSize)
        {
            //select sta.*, gr.gr_name
            //from staffs as sta left join group_role as gr on sta.group_role_id = gr.gr_id

            var lst = db.Database.SqlQuery<StaffViewModel>("select sta.sta_email as sta_email, sta.sta_fullname as sta_fullname" +
                ", sta.sta_username as sta_username,sta.sta_image as sta_image,sta_created_at as sta_created_at, gr.gr_name as gr_name" +
                "from staffs sta left join group_role gr on sta.group_role_id = gr.gr_id").ToList();
            //if (search != null)
            //{
            //    lst = lst.Where(x => x.sta_fullname.ToLower().Trim().Contains(search.ToLower().Trim())
            //                    || x.sta_username.ToLower().Trim().Contains(search.ToLower().Trim())
            //                    || x.sta_email.ToLower().Trim().Contains(search.ToLower().Trim())
            //    ).ToList();
            //}
            //if(gr_id != 0)
            //{
            //    lst = lst.Where(x => x.group_role_id == gr_id).ToList();
            //}
            return lst.Skip((Pagenum - 1) * PageSize).Take(PageSize).ToList();
        }

        #endregion
        #region["CRUD"]
        public void Create(staff sta)
        {
            db.staffs.Add(sta);
            db.SaveChanges();
        }
        public void Update(staff sta)
        {
            staff staff = GetById(sta.sta_id);
            if (staff != null)
            {
                staff.group_role_id = sta.group_role_id;
                staff.sta_email = sta.sta_email;
                staff.sta_fullname = sta.sta_fullname;
                staff.sta_password = sta.sta_password;
                staff.sta_username = sta.sta_username;
                staff.sta_update_at = sta.sta_update_at;
                db.SaveChanges();
            }
        }
        public int Delete(int id)
        {
            staff sta = db.staffs.Find(id);
            if (sta != null)
            {
                db.staffs.Remove(sta);
                return db.SaveChanges();
            }
            else
                return -1;
        }
        #endregion
        #region [Check_Duplicate]
        public bool Check_UserName(string name, int? sta_id = null)
        {
            bool results = true;
            if (sta_id == null)
            {
                var user = db.staffs.Where(x => x.sta_username.Trim().ToLower().Equals(name.Trim().ToLower())).FirstOrDefault();
                if (user != null) results = true;
                else results = false;
            }
            else
            {
                List<staff> list_staff = db.staffs.ToList();
                staff temp = db.staffs.Find(sta_id);
                list_staff.Remove(temp);
                bool res = list_staff.Exists(x => x.sta_fullname.Trim().ToLower().Equals(name.Trim().ToLower()));
                results = res;
            }
            return results;
        }
        #endregion
    }
}