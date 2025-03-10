﻿using MediatR;
using DB_ECommerce.Models;

namespace DB_ECommerce.Application.Categories
{
    public class CreateCategoryCommand : IRequest
    {
        public string CategoryName { get; set; }

        public Category ToCategory()
        {
            var category = new Category
            {
                CategoryName = this.CategoryName
            };

            return category;
        }
    }
}
