using DomainLayer.Entities;
using ServiceLayer.DTOs.Book;
using ServiceLayer.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryCreateDto category);
        Task<List<CategoryListDto>> GetAllAsync();

        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, CategoryUpdateDto category);

        Task<List<CategoryListDto>> SearchAsync(string? searchText);
        Task<Category> GetById(int id);

    }
}
