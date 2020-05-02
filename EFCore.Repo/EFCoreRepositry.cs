using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public class EFCoreRepositry : IEFCoreRepository
    {
        private readonly HeroiContext _context;

        public EFCoreRepositry(HeroiContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Heroi[]> GetAllHerois()
        {
            IQueryable<Heroi> query = _context.Herois
                 .Include(h => h.Identidade)
                 .Include(h => h.Armas);
            query.Include(h => h.HeroisBatalhas).ThenInclude(heroib => heroib.Batalha);

            query = query.AsNoTracking().OrderBy(h => h.Id);
            return await query.ToArrayAsync();

        }

        public Task<Heroi> GetHeroiById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Heroi> GetHeroiByNome(string nome)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangeAsync()
        {
           return (await _context.SaveChangesAsync()) > 0;


        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
