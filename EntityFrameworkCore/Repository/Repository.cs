using RepositoryPatternEF.DataContext;
using RepositoryPatternEF.Interfaces;

namespace RepositoryPatternEF.Repository {
    class Repository<T> : IRepository<T> where T : class {

        private readonly ApplicationContext _dbContext;

        public Repository(ApplicationContext dbContext) {
            _dbContext = dbContext;
        }

        public void Cadastrar(T elemento) {
            _dbContext.Set<T>().Add(elemento);
            _dbContext.SaveChanges();
        }

        public void RemoverPorId(int id) {
            var elementoPorId = _dbContext.Set<T>().Find(id);
            if (elementoPorId != null) {
                _dbContext.Remove(elementoPorId);
                _dbContext.SaveChanges();
            }
        }

        public void Atualizar(T elemento) {
            _dbContext.Set<T>().Update(elemento);
            _dbContext.SaveChanges();
        }

        public List<T> GetAll() {
            return _dbContext.Set<T>().ToList();
        }




    }
}
