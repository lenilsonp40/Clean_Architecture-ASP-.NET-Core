using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema_ECommerce.Domain.Entities;
using Sistema_ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_ECommerce.Infra.Mappings
{
    public class ClientesMap : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.ToTable("ECommerce_TB001_Clientes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("password")
                .HasColumnType("VARCHAR(30)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(180)");

            builder.Property(x => x.DataCreate)
                .IsRequired()                
                .HasColumnName("DataCreate")
                .HasColumnType("datetime2");

            // Converter para mapear o enum para uma string no banco de dados
            var statusConverter = new ValueConverter<ClientesStatusEnum, string>(
                v => v.ToString(),
                v => (ClientesStatusEnum)Enum.Parse(typeof(ClientesStatusEnum), v));

            builder.Property(x => x.StatusCliente)
                .IsRequired()
                .HasColumnName("StatusCliente")
                .HasColumnType("varchar(15)")
                .HasConversion(statusConverter);
        }
    }
}
