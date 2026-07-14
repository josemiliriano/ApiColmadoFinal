using Application.Contract;
using Application.DTOs;
using Domain.Entities;
using Infraestructure.Eceptions;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly GeneralRepository<CDCategory> _repository;
        public CategoryAppService(GeneralRepository<CDCategory> repository)
        {
            _repository = repository;
        }
        public CDCategory AddCategory(CategoryDto dto)
        {
            try
            {
                var exist = _repository.Exists(c => c.CategoryName.ToLower() == dto.CategoryName.ToLower());
                if (exist)
                {
                    throw new AlreadyExistsException("Categoría", dto.CategoryName);
                }
                var NewCategory = new CDCategory
                {
                    CategoryName = dto.CategoryName,
                    Description = dto.Description
                };
                return _repository.Add(NewCategory);
            }
            catch (AlreadyExistsException e)
            {
                throw new(e.Message);
            }
        }

        public void DeleteCategory(int id)
        {
            var category = _repository.GetById(id);
            if (category != null)
            {
                _repository.Deleter(category);
            }
        }

        public List<CDCategory> GetAllCategory()
        {
            return _repository.GetAll();
        }

        public CDCategory GetCategoryById(int id)
        {
            var category = _repository.GetById(id);
            return category;
        }

        public List<CDCategory> GetCategoryNotDeleted()
        {
            return _repository.GetAll().Where(c => c.Isdelete == '0').ToList();
        }

        public bool SoftDelete(int id)
        {
            var SDCategory = _repository.GetById(id);
            if (SDCategory == null)
            {
                return false;
            }
            SDCategory.Isdelete = '1';
            return true;
        }

        public CDCategory UpdateCategory(int id, CategoryDto dto)
        {
            var Category = _repository.GetById(id);
            if (Category != null)
            {
                Category.CategoryName = dto.CategoryName;
                Category.Description = dto.Description;
            }
            return _repository.Update(Category);
        }
    }
}
