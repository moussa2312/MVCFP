using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositries.Interfacies
{
    public interface IGenericRepositry< TEntity > where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll(bool withtracking = false); 
        //Get by id
        TEntity GetById(int id);
        //Add
        int Add(TEntity Entity); 
        //Update
        int Update(TEntity Entity);
        //Delete
        int Delete(TEntity Entity);
    }
}

