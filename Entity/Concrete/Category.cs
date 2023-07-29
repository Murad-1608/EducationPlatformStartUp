﻿using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course>? Course { get; set; }
        public List<SubCategory>? SubCategories { get; set; }
    }
}
