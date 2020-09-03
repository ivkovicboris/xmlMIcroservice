using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using xmlMicroservice.DAL.Context;
using xmlMicroservice.DAL.Repositories.Abstract;

namespace xmlMicroservice.DAL.Repositories
{
    public class Repository<E> : IRepository<E> where E : class
    {

        private readonly DbSet<E> _dbSet;
        private readonly RentACarContext _rentACarContext;

        public Repository(RentACarContext rentACarContext)
        {
            _rentACarContext = rentACarContext;
            _dbSet = rentACarContext.Set<E>();

        }

        public async Task<bool> Create(E entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _rentACarContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }

            return true;
        }

        public async Task<bool> Delete(E entity)
        {
            try
            {
                _dbSet.Remove(entity);
                await _rentACarContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }

            return true;
        }

        public async Task<IEnumerable<E>> Find(Expression<Func<E, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();

        }

        public IEnumerable<E> GetAll()
        {
            return _dbSet;
        }

        public async Task<bool> Update(E entity)
        {
            try
            {
                //await _centerContext.SaveChangesAsync();
                await _rentACarContext.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }



        }


    }
}
