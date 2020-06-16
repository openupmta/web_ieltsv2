using coderush.Areas.Admins.Models.EF;
using coderush.Areas.Admins.Models.EF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coderush.Areas.Admins.Models.DAO
{
    public class GroupRoleDao
    {
        DBIeltsContext db;
        public GroupRoleDao()
        {
            db = new DBIeltsContext();
        }
        #region["GET"]
        public List<group_role> GetAll()
        {
            return db.group_role.ToList();
        }
        public List<group_role> GetAllPageNumber(int Pagenum, int PageSize)
        {
            return db.group_role.Skip((Pagenum - 1) * PageSize).Take(PageSize).ToList();
        }
        public group_role GetById(int? id)
        {
            return db.group_role.Single(i => i.gr_id == id);
        }
        public List<GroupRoleViewModel> GetAllSearch(int Pagenum, int PageSize, string search)
        {
            var lst = db.Database.SqlQuery<GroupRoleViewModel>("select * from group_role").ToList();
            if (search != null)
            {
                lst = lst.Where(x => x.gr_name.ToLower().Trim().Contains(search.ToLower().Trim())).ToList();
            }
            return lst.Skip((Pagenum - 1) * PageSize).Take(PageSize).ToList();
        }

        #endregion
        #region["CRUD"]
        public void Create(group_role gr)
        {
            db.group_role.Add(gr);
            db.SaveChanges();
        }
        public void Update(group_role gr)
        {
            group_role group_role = GetById(gr.gr_id);
            if (group_role != null)
            {
                group_role.gr_name = gr.gr_name;
                group_role.gr_description = gr.gr_description;
                db.SaveChanges();
            }
        }
        public int Delete(int id)
        {
            group_role gr = db.group_role.Find(id);
            if (gr != null)
            {
                db.group_role.Remove(gr);
                return db.SaveChanges();
            }
            else
                return -1;
        }
        #endregion
    }
}