﻿using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class EFGenericRepository<T> : IEFGenericRepository<T> where T : class
    {
        DbContext _context;
        DbSet<T> _dbSet;

        public EFGenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> Get()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<int> Count()
        {

            return await _dbSet.AsNoTracking().CountAsync();
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public async Task<T>? FindByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async void Create(T item)
        {
            await _dbSet.AddAsync(item);
        }
        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public async Task<IEnumerable<T>> GetByConditions(Dictionary<string, string> conditions)
        {
            BinaryExpression? filter = null;
            var userData = Expression.Parameter(typeof(T));
            foreach (var toProcess in conditions)
            {
                var memberExpression = Expression.PropertyOrField(userData, toProcess.Key);
                var constantExpression = Expression.Constant(toProcess.Value);
                var binaryExpression = Expression.Equal(memberExpression, constantExpression);
                filter = (filter != null) ? Expression.And(filter, binaryExpression) : binaryExpression;
            }
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(filter, userData);
            return await _context.Set<T>()
                .Where(lambda)
                .ToListAsync();
        }
    }
}
