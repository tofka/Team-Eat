﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamEat.Domain.Repositories.Abstract;
using TeamEat.Domain.Entities.Abstract;
using TeamEat.Domain.Contexts;
using System.Data.Objects;
using System.Data.Entity;

namespace TeamEat.Domain.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected DbContext _context;
        protected DbSet<T> _dbSet;

        public Repository()
        {
            _context = new EFDbContext();
            _dbSet = _context.Set<T>();
        }

        public DbContext Model
        {
            get { return _context;  }
        }

        public virtual IQueryable<T> FindAll(Func<T, bool> filter = null)
        {
            if (null == filter)
                return _dbSet;
            return _dbSet.Where(filter).AsQueryable();
        }

        public virtual T FindByID(int id)
        {
            return _dbSet.FirstOrDefault(e => e.ID == id);
        }

        public virtual void Save(T entity)
        {
            var existing = _dbSet.Where(e => e.ID == entity.ID).FirstOrDefault();
            if (null != existing)
                _context.Entry(entity).State = System.Data.EntityState.Modified;
            else
                _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _context.Entry(entity).State = System.Data.EntityState.Deleted;
            _context.SaveChanges();
        }

        /// <summary>
        /// To have any use for this method - _context.SaveChanges needs to be removed from .Save(..) and .Delete(..).
        /// After that change an entity is saved by e.g: "repo.Save(entity);repo.Commit();"
        /// 
        /// Useful in case bulk operations or more complex transactions are needed.
        /// </summary>
        public virtual void Commit()
        {
            _context.SaveChanges();
        }
    }
}