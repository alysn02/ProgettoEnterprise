using Unicam.Paradigmi.Progetto.Models.Context;


namespace Unicam.Paradigmi.Models.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {
        protected MydbContext _ctx;
        public GenericRepository(MydbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AggiungiAsync(T entity)
        {
            await _ctx.Set<T>().AddAsync(entity);
        }

        public async Task SaveAsync()
        {
           await _ctx.SaveChangesAsync();
        }

    }
}

