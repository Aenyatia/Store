using Microsoft.EntityFrameworkCore;
using Store.Core;

namespace Store.Web.Infrastructure
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Movie> Movies { get; set; }

		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}
	}
}
