using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract
{
    public interface ICategoryAppService
    {
        public CDCategory AddCategory(CategoryDto dto);
        public List<CDCategory> GetAllCategory();
        public CDCategory GetCategoryById(int id);
        public CDCategory UpdateCategory(int id, CategoryDto dto);
        public void DeleteCategory(int id);
        public bool SoftDelete(int id);
        public List<CDCategory> GetCategoryNotDeleted();
    }
}
