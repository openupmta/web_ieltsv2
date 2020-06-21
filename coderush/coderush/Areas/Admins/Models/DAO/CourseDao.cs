using coderush.Areas.Admins.Models.EF;
using coderush.Areas.Admins.Models.EF.ViewModel;
using PagedList;
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
            return db.courses.Single(i => i.co_id == id);
        }
        public IEnumerable<CourseViewModel> GetAllSearch(int Pagenum, int PageSize, string search)
        {

            var lst = db.Database.SqlQuery<CourseViewModel>("select co.*,te.te_name as teacher_name" +
                " from course as co" +
                " left join teachers as te on co.teacher_id = te.te_id").ToList();

            if (search != null)
            {
                lst = lst.Where(x => x.co_name.ToLower().Trim().Contains(search.ToLower().Trim())
                                || x.co_content.ToLower().Trim().Contains(search.ToLower().Trim())
                                || x.teacher_name.ToLower().Trim().Contains(search.ToLower().Trim())
                ).ToList();
            }
            return lst.ToList().ToPagedList<CourseViewModel>(Pagenum, PageSize);
        }

        #endregion
        #region["CRUD"]
        public void Create(course co)
        {
            db.courses.Add(co);
            db.SaveChanges();
        }
        public void Update(course cou)
        {
            course course = GetById(cou.co_id);
            if (course != null)
            {
                course.teacher_id = cou.teacher_id;
                course.co_name = cou.co_name;
                course.co_image = cou.co_image;
                course.co_price = cou.co_price;
                course.co_content = cou.co_content;
                course.co_status = cou.co_status;
                course.co_type = cou.co_type;
                course.co_updated_at = cou.co_updated_at;

                db.SaveChanges();
            }
        }
        public int Delete(int id)
        {
            course cou = db.courses.Find(id);
            if (cou != null)
            {
                db.courses.Remove(cou);
                return db.SaveChanges();
            }
            else
                return -1;
        }
        #endregion
        #region [Check_Duplicate]
        public bool Check_CourseName(string name, int? cou_id = null)
        {
            bool results = true;
            if (cou_id == null)
            {
                var user = db.courses.Where(x => x.co_name.Trim().ToLower().Equals(name.Trim().ToLower())).FirstOrDefault();
                if (user != null) results = true;
                else results = false;
            }
            else
            {
                List<course> list_course = db.courses.ToList();
                course temp = db.courses.Find(cou_id);
                list_course.Remove(temp); //???????????????????????????????????????????????????????????????????????????????
                bool res = list_course.Exists(x => x.co_name.Trim().ToLower().Equals(name.Trim().ToLower()));
                results = res;
            }
            return results;
        }
        #endregion
    }
}