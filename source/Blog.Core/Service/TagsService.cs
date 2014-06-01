﻿using System.Collections.Generic;
using System.Linq;
using Blog.Core.Infrastructure.Persistence;
using Blog.Core.Infrastructure.Persistence.Entities;

namespace Blog.Core.Service
{
    public class TagsService
    {
        public IEnumerable<string> Search(string term)
        {
            using (var repository = new Repository<Tag>())
            {
                return repository.Find(t => t.Name.ToLower().Contains(term.ToLower())).Select(t => t.Name);
            }
        }
    }
}