using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Infra.Data.Contexts;

namespace UsuariosApp.Infra.Data.Repositories
{
    public abstract class BaseRepository<TModel, Tkey> : IBaseRepository<TModel, Tkey>
        where TModel : class
    {
        private readonly DataContext? _dataContext;

        protected BaseRepository(DataContext? dataContext)
            => _dataContext = dataContext;


        public virtual void Add(TModel model) 
            => _dataContext?.Add(model);
        

        public virtual void Delete(TModel model)
            => _dataContext?.Remove(model);
        

        public virtual TModel Get(Func<TModel, bool> where)
        {
            return _dataContext?.Set<TModel>().FirstOrDefault(where);
        }

        public virtual List<TModel> GetAll()
        {
            return _dataContext?.Set<TModel>().ToList();
        }

        public virtual List<TModel> GetAll(Func<TModel, bool> where)
        {
            return _dataContext?.Set<TModel>().Where(where).ToList();
        }

        public virtual TModel GetById(Tkey id)
        {
            return _dataContext.Set<TModel>().Find(id);
        }

        public virtual void Update(TModel model)
            => _dataContext?.Update(model);

        public virtual void Dispose()       
            => _dataContext.Dispose();
        
    }
}
