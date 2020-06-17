using coderush.Areas.Admins.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coderush.Areas.Admins.Models.DAO
{
    public class CourseDao
    {
        DBIeltsContext db;
        public CourseDao()
        {
            db = new DBIeltsContext();
        }
        #region["GET"]
        public List<course> GetAll()
        {
            return db.courses.ToList();
        }
        public List<course> GetAllPageNumber(int Pagenum, int PageSize)
        {
            return db.courses.Skip((Pagenum - 1) * PageSize).Take(PageSize).ToList();
        }
        public course GetById(int? id)
        {
            return db.courses.Single(i => i.sta_id == id);
        }
        public List<courseViewModel> GetAllSearch(int Pagenum, int PageSize)
        {
            //select sta.*, gr.gr_name
            //from courses as sta left join group_role as gr on sta.group_role_id = gr.gr_id

            var lst = db.Database.SqlQuery<courseViewModel>("select sta.sta_email as sta_email, sta.sta_fullname as sta_fullname" +
                ", sta.sta_username as sta_username,sta.sta_image as sta_image,sta_created_at as sta_created_at, gr.gr_name as gr_name" +
                "from courses sta left join group_role gr on sta.group_role_id = gr.gr_id").ToList();
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
        public void Create(course sta)
        {
            db.courses.Add(sta);
            db.SaveChanges();
        }
        public void Update(course sta)
        {
            course course = GetById(sta.sta_id);
            if (course != null)
            {
                course.group_role_id = sta.group_role_id;
                course.sta_email = sta.sta_email;
                course.sta_fullname = sta.sta_fullname;
                course.sta_password = sta.sta_password;
                course.sta_username = sta.sta_username;
                course.sta_update_at = sta.sta_update_at;
                db.SaveChanges();
            }
        }
        public int Delete(int id)
        {
            course sta = db.courses.Find(id);
            if (sta != null)
            {
                db.courses.Remove(sta);
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
                var user = db.courses.Where(x => x.sta_username.Trim().ToLower().Equals(name.Trim().ToLower())).FirstOrDefault();
                if (user != null) results = true;
                else results = false;
            }
            else
            {
                List<course> list_course = db.courses.ToList();
                course temp = db.courses.Find(sta_id);
                list_course.Remove(temp);
                bool res = list_course.Exists(x => x.sta_fullname.Trim().ToLower().Equals(name.Trim().ToLower()));
                results = res;
            }
            return results;
        }
        #endregion
    }
}