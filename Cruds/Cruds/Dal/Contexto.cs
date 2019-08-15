using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Cruds.Models
{
    public class Contexto : DbContext
    {   //nombre de la cadena de conexión que se agregara enel archivo web.config
        public Contexto() : base("Contexto")
        {
        }
        public DbSet<PersonalModels>personalModels{ get; set;}
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //propiedad que se utiliza para que las entidades sean en singular
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    
    
}