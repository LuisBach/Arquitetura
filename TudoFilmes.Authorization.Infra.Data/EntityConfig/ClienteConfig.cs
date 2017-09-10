using System.Data.Entity.ModelConfiguration;
using TudoFilmes.Authorization.Domain.Entities;

namespace TudoFilmes.Authorization.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.ClientId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.ClientId)
                .IsRequired()
                .HasMaxLength(32);

            Property(c => c.Base64Secret)
                .IsRequired()
                .HasMaxLength(80);

            Ignore(c => c.ValidationResult);

            ToTable("Cliente");
        }
    }
}
