using Microsoft.EntityFrameworkCore;
using WebApplication1.Infraestrutura.Context;
using WebApplication1.Domain.Models;
using WebApplication1.Domain.Models.Entities;

namespace WebApplication1.Infraestrutura.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        { }
        public DbSet<Employee> Employees { get; set; }



    }
}
