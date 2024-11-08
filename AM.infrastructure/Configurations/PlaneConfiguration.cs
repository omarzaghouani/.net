using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Am.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.infrastructure.Configurations
{
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.HasKey(p => p.PlaneId);//PlaneId est la clé primaire de la table
            builder.ToTable("MyPlanes");// Le nom de la table correspondante à l’entité Plane dans la base de données doit être “MyPlanes
            builder.Property(p => p.Capacity).HasColumnName("PlaneCpacity");//Le nom de la colonne correspondante à la propriété Capacity dans la base de données doit être PlaneCapacity

        }
    }
}
