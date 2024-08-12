using Microsoft.EntityFrameworkCore;

namespace EF_YouTube_tutorialsEU;

public class Program {
  public static void Main(string[] args) {
    using (var context = new MyDbContext()) {
      var purchase = new Purchase() {
          Id = 1,
          Product = "Shoes",
          Price = 49.95m
      };

      context.Purchases.Add(purchase);
      context.SaveChanges();

      var allPurchases = context.Purchases.ToList();

      foreach (Purchase item in allPurchases) {
        Console.WriteLine($"Product: {item.Product}, Price: {item.Price}");
      }

      purchase.Price = 89.99m;
      context.Update(purchase);
      // context.SaveChanges();
      
      foreach (Purchase item in allPurchases) {
        Console.WriteLine($"Product: {item.Product}, Price: {item.Price}");
      }
    }
  }

  public class MyDbContext : DbContext {
    public DbSet<Purchase> Purchases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseInMemoryDatabase("MyDb");
    }
  }

  public class Purchase {
    public int Id { get; set; }

    public string? Product { get; set; }
    
    public decimal Price { get; set; }
  }
  
  
}