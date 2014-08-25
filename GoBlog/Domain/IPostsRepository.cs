﻿using System.Collections.Generic;
using GoBlog.Domain.Model;

namespace GoBlog.Domain
{
    public interface IPostsRepository
    {
        IEnumerable<Post> All();
        Post Find(string slug);
    }
}