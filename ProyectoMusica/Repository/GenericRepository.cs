using Microsoft.EntityFrameworkCore;
using ProyectoMusica.Data;

namespace ProyectoMusica.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MusicaDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(MusicaDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
