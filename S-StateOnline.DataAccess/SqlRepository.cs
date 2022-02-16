using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S_StateOnline.Core.Contracts;
using S_StateOnline.Core.Models;
using S_StateOnline.Data.Entity;

namespace S_StateOnline.DataAccess.Sql
{
    public class SqlRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext context;
        internal Dbset<T> dbset;
        public SqlRepository(DataContext context)
        {
            this.context = context;
            this.dbset = context.Set<T>;
        }
        public IQueryable<T> Collection()
        {
            return dbset;
        }
        public void Commit()
        {
            context.SaveChanges();
        }
        public void Delete(string Id)
        {
            var t = Find(Id);
            if (context.Entry(t).State == EntityState.Detatched)
                dbset.Attach(t);
            dbset.Remove(t);
        } 
        public T Find(stringId)
        {
            return dbset.Find(Id);
        }
        public void Insert(T t)
        {
            dbset.Add(t);
        }
        public void Update(T t)
        {
            dbset.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
