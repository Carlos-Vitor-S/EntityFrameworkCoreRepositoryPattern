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
        }

        public void Remover(T elemento) {
            _dbContext.Set<T>().Remove(elemento);
        }

        public void Atualizar(T elemento) {
            _dbContext.Set<T>().Update(elemento);
        }

        public List<T> GetAllElements() {
            return _dbContext.Set<T>().ToList();
        }

        public void SalvarAlteracoes() {
            _dbContext.SaveChanges();
        }

        public T GetPorId(int id) {
            return _dbContext.Set<T>().Find(id);
        }
    }
}
