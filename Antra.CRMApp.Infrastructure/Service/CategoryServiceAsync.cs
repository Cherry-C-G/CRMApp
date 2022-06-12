using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Antra.CRMApp.Core.Contract.Service;

namespace Antra.CRMApp.Infrastructure.Service
{
    public class CategoryServiceAsync : ICategoryServiceAsync
    {
        private readonly ICategoryRepositoryAsync categoryRepositoryAsync;

        public CategoryServiceAsync(ICategoryRepositoryAsync _categoryRepositoryAsync)
        {
            categoryRepositoryAsync = _categoryRepositoryAsync;
        }

        public async Task<int> AddCategoryAsync(CategoryRequestModel category)
        {
            Category cat = new Category();
            cat.Id = category.Id;
            cat.Name = category.Name;
            cat.Description = category.Description;
            return await categoryRepositoryAsync.InsertAsync(cat);
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            return await categoryRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryResponseModel>> GetAllAsync()
        {
            var collection = await categoryRepositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<CategoryResponseModel> result = new List<CategoryResponseModel>();
                foreach (var item in collection)
                {
                    CategoryResponseModel model = new CategoryResponseModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Description = item.Description;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<CategoryResponseModel> GetByIdAsync(int id)
        {
            var item = await categoryRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CategoryResponseModel model = new CategoryResponseModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Description = item.Description;
                return model;
            }
            return null;
        }

        public async Task<CategoryRequestModel> GetCategoryForEditAsync(int id)
        {
            var item = await categoryRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CategoryRequestModel model = new CategoryRequestModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Description = item.Description;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateCategoryAsync(CategoryRequestModel category)
        {
            Category cat = new Category();
            cat.Id = category.Id;
            cat.Name = category.Name;
            cat.Description = category.Description;
            return await categoryRepositoryAsync.UpdateAsync(cat);
        }
    }
}
