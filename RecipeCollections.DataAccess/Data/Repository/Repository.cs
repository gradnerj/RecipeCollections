﻿using Microsoft.EntityFrameworkCore;
using RecipeCollections.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RecipeCollections.DataAccess.Data.Repository {
    public class Repository<T> : IRepository<T> where T : class {
        protected readonly DbContext Context;
        internal DbSet<T> dbset;
        public Repository(DbContext context) {
            Context = context;
            this.dbset = Context.Set<T>();
        }

        public void Add(T entity) {
            dbset.Add(entity);
        }

        public T Get(int id) {
            return dbset.Find(id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null) {
            IQueryable<T> query = dbset;
            if (filter != null) {
                query = query.Where(filter);
            }
            if (includeProperties != null) {
                foreach (var includeProperty in includeProperties.Split(new char[]
                        {','}, StringSplitOptions.RemoveEmptyEntries)) {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null) {
                return orderBy(query);
            } else {
                return query;
            }
        }

        public T GetFirstorDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null) {
            IQueryable<T> query = dbset;
            if (filter != null) {
                query = query.Where(filter);
            }
            if (includeProperties != null) {
                foreach (var includeProperty in includeProperties.Split(new char[]
                        {','}, StringSplitOptions.RemoveEmptyEntries)) {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(int id) {
            T entityToRemove = dbset.Find(id);
            Remove(entityToRemove);
        }

        public void Remove(T entity) {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities) {
            dbset.RemoveRange(entities);
        }
    }
}
