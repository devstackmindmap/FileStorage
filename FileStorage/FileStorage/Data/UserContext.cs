using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FileStorage.Models;

namespace FileStorage.Data
{

    // Derives from Microsoft.EntityFrameworkCore.DbContext.
    // Specifies which entities are included in the data model.
    // Coordinates EF Core functionality, such as Create, Read, Update and Delete, for the Movie model.

    public class UserContext : DbContext
    {
        public UserContext (DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<FileStorage.Models.User> User { get; set; } = default!;
    }
}
