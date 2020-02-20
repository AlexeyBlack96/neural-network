using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NeuralLibrary.Models;
 
namespace Neuron.Models
{
    public class NeuronDbContext : DbContext
    {
        public DbSet<NeuronModelDb> Neurons { get; set; }
        public DbSet<NeuronNetworkDb> NeuronNetworks { get; set; }

        public NeuronDbContext(DbContextOptions<NeuronDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}