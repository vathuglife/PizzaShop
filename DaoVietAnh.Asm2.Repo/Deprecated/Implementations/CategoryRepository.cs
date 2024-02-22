using DaoVietAnh.Asm2.Repo.Deprecated;
using DaoVietAnh.Asm2.Repo.Entities;
using Microsoft.EntityFrameworkCore;

namespace DaoVietAnh.Asm2.Repo.Deprecated.Implementations
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        private ShoppingWebsiteDBContext? _dbContext;
        private bool disposed = false;
        public CategoryRepository(ShoppingWebsiteDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteCategory(int CategoryID)
        {
            Category Category = _dbContext?.Categories.Find(CategoryID)!;
            _dbContext?.Categories.Remove(Category);
        }



        public Category GetCategoryByID(int CategoryId)
        {
            return _dbContext!.Categories.Find(CategoryId)!;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _dbContext!.Categories.ToList();
        }

        public void InsertCategory(Category Category)
        {
            _dbContext?.Categories.Add(Category);
        }

        public void Save()
        {
            _dbContext?.SaveChanges();
        }

        public void UpdateCategory(Category Category)
        {
            _dbContext!.Entry(Category).State = EntityState.Modified;
        }
        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext?.Dispose();
                }
            }
            disposed = true;
        }
    }
}
