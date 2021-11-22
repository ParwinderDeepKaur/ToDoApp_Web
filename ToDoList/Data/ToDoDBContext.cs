using Microsoft.EntityFrameworkCore;
using System;
using ToDoList.Model;

namespace ToDoList.Data
{
    public class ToDoDBContext : DbContext
    {

        public DbSet<ToDoTable> ToDoLists { get; set; }

        public string DbPath { get; private set; }

        public ToDoDBContext()
        {
            var path = Environment.CurrentDirectory;
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}ToDoLists.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

}
