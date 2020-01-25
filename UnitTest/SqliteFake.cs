using DomainModel;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    public class SqliteFake
    {
        private DbContextOptions<AppDbContext> _options;

        public SqliteFake()
        {
            _options = GetDbContextOptions;
        }

        public AppDbContext GetContext()
        {
            var context = new AppDbContext(_options);
            context.Database.EnsureCreated();
            return context;
        }

        private DbContextOptions<AppDbContext> GetDbContextOptions 
        {
            get
            {
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();
                var option = new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlite(connection)
                    .Options;

                return option;
            }
        }

    }
}
