using Demo.DAL.Data.Repositries.Interfacies;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositries.Classes
{
    //CRUD operations
    // ask clr for create obf from dbcontext
    public class DepartmentRepository(AppDbContext dbContext ) : GenericRepositry<Department>(dbContext) , IDepartmentRepositire 
    {

    }
}
