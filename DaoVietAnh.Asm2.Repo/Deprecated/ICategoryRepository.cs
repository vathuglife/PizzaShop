using DaoVietAnh.Asm2.Repo.Entities;

namespace DaoVietAnh.Asm2.Repo.Deprecated
{
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryByID(int CategoryId);
        void InsertCategory(Category Category);
        void DeleteCategory(int CategoryID);
        void UpdateCategory(Category Category);
        void Save();
    }
}
