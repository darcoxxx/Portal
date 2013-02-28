using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Portal.Models
{
  public class RecipeDbContext : DbContext
  {
    public DbSet<RecipeModels> Recipes { get; set; } 
  }
}