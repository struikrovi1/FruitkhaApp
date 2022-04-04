﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryManager
    {
        List<Category> GetAll();
        void Create(Category Category);
        Category GetById(int? id);
        void Update(Category Category);

        void Delete(Category Category);
    }
}
