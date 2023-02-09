using Business.Interfaces;
using Data.Config;
using Data.RepositoryGeneric;
using Microsoft.EntityFrameworkCore;
using Model.Entity;

namespace Data.ProductRepository
{
    public  class ProductRepository : RepositoryGenerics<Product>, IProduct
    {
        private readonly DbContextOptions<AppDBContext> _context;
        public ProductRepository()
        {
            _context= new DbContextOptions<AppDBContext>();
        }
    }
}
