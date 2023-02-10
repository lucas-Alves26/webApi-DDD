using Business.Interfaces;
using Data.Config;
using Data.RepositoryGeneric;
using Microsoft.EntityFrameworkCore;
using Model.Entity;

namespace Data.Repositorys
{
    public class CategoryRepository : RepositoryGenerics<Category>, ICategory
    {
        private readonly DbContextOptions<AppDBContext> _context;

        public CategoryRepository()
        {
            _context = new DbContextOptions<AppDBContext>();
        }
    }
}
