using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Models.Entities;
using WebApplication1.Domain.Models;

namespace WebApplication1.Infraestrutura.Context
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }

    }
}
