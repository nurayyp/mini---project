using Core.Constants;
using Core.Entities.Base;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbTable;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbTable = _context.Set<T>();
        }
        public void Add(T item)
        {
            _dbTable.Add(item);
        }

        public void Delete(T item)
        {
            _dbTable.Remove(item);
        }

        public List<T> GetAll()
        {
            return _dbTable.ToList();
        }

        public void Update(T item)
        {
            _dbTable.Update(item);
        }
    }
}
