using System.Data.Entity;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Data.Batch_Management.Models;
using Ingogo.Data.Employee_Management.Models;
using Ingogo.Data.Purchase_Management.Models;
using Ingogo.Data.Supplier_Management.Models;
using Ingogo.Data.Treatment_Managemnt.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ingogo.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Employees> Employeeses { get; set; }
        public DbSet<BatchType> BatchTypes { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<FeedingStock> FeedingStocks { get; set; } 
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Counter> Counters { get; set; }
        public DbSet<AnimalWeight> AnimalWeights { get; set; }
        public DbSet<Suppliers> Supplierses{ get; set; }
        public DbSet<FeedingScheme> FeedingSchemes { get; set; }
        public DbSet<Percentage> Percentages { get; set; }
        public DbSet<FeedingPercentage> FeedingPercentages { get; set; }
        public DbSet<FeedingRatio> FeedingRatios { get; set; }
        public DbSet<FeedingIngredients> FeedingIngredientses { get; set; }
        public DbSet<TreatmentRatio> TreatmentRatios { get; set; }
        public DbSet<TreatmentIngredients> TreatmentIngredients { get; set; }
        public DbSet<TreatmentPercentage> TreatmentPercentages { get; set; }
        public DbSet<TreatmentRatioTotal> TreatmentRatioTotals { get; set; }
        public DbSet<DeadAnimal> DeadAnimals { get; set; }
    }
}