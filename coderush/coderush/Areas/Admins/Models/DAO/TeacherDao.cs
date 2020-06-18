using coderush.Areas.Admins.Models.EF;
using coderush.Areas.Admins.Models.EF.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coderush.Areas.Admins.Models.DAO
{
    public class TeacherDao
    {
        DBIeltsContext db;
        public TeacherDao()
        {
            db = new DBIeltsContext();
        }
        #region["GET"]
        public List<teacher> GetAll()
        {
            return db.teachers.ToList();
        }
        public List<teacher> GetAllPageNumber(int Pagenum, int PageSize)
        {
            return db.teachers.Skip((Pagenum - 1) * PageSize).Take(PageSize).ToList();
        }
        public teacher GetById(int? id)
        {
            return db.teachers.Single(i => i.te_id == id);
        }
        public IEnumerable<TeacherViewModel> GetAllSearch(int Pagenum, int PageSize, string search)
        {
            var lst = db.Database.SqlQuery<TeacherViewModel>("select te.*,sta.sta_fullname as staff_name,pos.pos_name as position_name" +
                " from teachers as te" +
                " left join staffs as sta  on te.staff_id = sta.sta_id" +
                " right join positions as pos on te.position_id = pos.pos_id").ToList();
            if (search != null)
            {
                lst = lst.Where(x => x.te_name.ToLower().Trim().Contains(search.ToLower().Trim())).ToList();
            }
            return lst.ToList().ToPagedList<TeacherViewModel>(Pagenum, PageSize);
        }

        #endregion
        #region["CRUD"]
        public void Create(teacher te)
        {
            db.teachers.Add(te);
            db.SaveChanges();
        }
        public void Update(teacher te)
        {
            teacher teacher = GetById(te.te_id);
            if (teacher != null)
            {
                teacher.te_name = te.te_name;
                teacher.te_content = te.te_content;
                teacher.te_image = te.te_image;
                teacher.te_status = te.te_status;
                teacher.te_updated_at = te.te_updated_at;
                teacher.staff_id = te.staff_id;
                teacher.position_id = te.position_id;
                db.SaveChanges();
            }
        }
        public int Delete(int id)
        {
            teacher te = db.teachers.Find(id);
            if (te != null)
            {
                db.teachers.Remove(te);
                return db.SaveChanges();
            }
            else
                return -1;
        }
        #endregion
    }
}