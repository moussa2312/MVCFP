using Demo.DAL.Data.Repositries.Interfacies;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositries.Classes
{
    public class GenericRepositry<TEntity>(AppDbContext _dbcontext) : IGenericRepositry<TEntity> where TEntity : BaseEntity
    {
        public int Add(TEntity Entity)
        {
            _dbcontext.Set<TEntity>().Add(Entity); // Add the entity to the DbSet
            return _dbcontext.SaveChanges(); // Save changes to the database (Update DB)
        }

        public int Delete(TEntity Entity)
        {
            _dbcontext.Set<TEntity>().Remove(Entity); // Remove the entity from the DbSet
            return _dbcontext.SaveChanges(); // Save changes to the database (Update DB)
        }

        public IEnumerable<TEntity> GetAll(bool withtracking = false)
        {
            if (withtracking)
                return _dbcontext.Set<TEntity>().ToList();
            else
                return _dbcontext.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbcontext.Set<TEntity>().Find(id); // Find the department by ID
                                                    //find<Department>(id)
        }

        public int Update(TEntity Entity)
        {
            _dbcontext.Set<TEntity>().Update(Entity); // Update the entity in the DbSet
            return _dbcontext.SaveChanges(); // Save changes to the database (Update DB)
        }
    }
}
