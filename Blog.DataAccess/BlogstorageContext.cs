﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.DataAccess.Entities;

namespace Blog.DataAccess
{
    public class BlogstorageContext : DbContext
    {
        public BlogstorageContext(DbContextOptions<BlogstorageContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<NewPost> Posts { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
    }
}
