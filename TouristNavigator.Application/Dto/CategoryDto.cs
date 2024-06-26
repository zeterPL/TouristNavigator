﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristNavigator.Domain.Entities;

namespace TouristNavigator.Application.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[]? Icon { get; set; }
    }

    public static class CategoryExtensions
    {
        public static CategoryDto toCategoryDto(this Category category)
        {
            var dto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                //Icon = category.Icon.Icon
            };
            if (category.Icon != null)
            {
                dto.Icon = category.Icon.Icon;
            }
            return dto;
        }
    }
}
