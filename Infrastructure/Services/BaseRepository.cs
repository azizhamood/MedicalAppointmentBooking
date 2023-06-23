using Application.Interface;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MySqlDbContex _dbContext;
        public BaseRepository(MySqlDbContex dbContext)
        {

            _dbContext = dbContext;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            try
            {
                var entity = await _dbContext.Set<T>().FindAsync(Id);
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> Get(Func<T, bool> expration)
        {
            var entity = _dbContext.Set<T>().AsNoTracking().Where(expration).ToList();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(string[] incloud)
        {
            if (incloud.Length == 3)
                return await _dbContext.Set<T>().Include(incloud[0]).Include(incloud[1]).Include(incloud[2]).ToListAsync();
            else if (incloud.Length == 1)
                return await _dbContext.Set<T>().Include(incloud[0]).ToListAsync();
            else
                return await _dbContext.Set<T>().ToListAsync();

               
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Update(entity);
                var result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
