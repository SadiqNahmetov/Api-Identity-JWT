using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Book;
using ServiceLayer.DTOs.Category;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
                _repo = repo;
               _mapper = mapper;
        }

        public async Task CreateAsync(CategoryCreateDto category)
        {
            await _repo.Create(_mapper.Map<Category>(category));
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await _repo.Get(id);
            if (category == null) throw new NullReferenceException();
            await _repo.Delete(category);
        }
        public async Task SoftDeleteAsync(int id)
        {
            Category category = await _repo.Get(id);
            await _repo.SoftDelete(category);
        }

        public async Task<List<CategoryListDto>> GetAllAsync()
        {
            return _mapper.Map<List<CategoryListDto>>(await _repo.GetAll());
        }

        public async Task<Category> GetById(int id)
        {
            return await _repo.Get(id);
        }

        public async Task<List<CategoryListDto>> SearchAsync(string? searchText)
        {
            List<Category> searchDatas = new();
            if (searchText != null)
            {
                searchDatas = await _repo.FindAllByExceptionAsync(m => m.Name.Contains(searchText));

            }
            else
            {
                searchDatas = await _repo.GetAll();
            }
            return _mapper.Map<List<CategoryListDto>>(searchDatas);
        }

      

        public async Task UpdateAsync(int id, CategoryUpdateDto category)
        {
            var dbCategory = await _repo.Get(id);
            _mapper.Map(category, dbCategory);

            await _repo.Update(dbCategory);
        }
    }
}
