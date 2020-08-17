using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class UserAnswersConfiguration : IEntityTypeConfiguration<UserAnswers>
    {
        public void Configure(EntityTypeBuilder<UserAnswers> builder)
        {
            builder.ToTable("UserAnswers");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.UserAnswers).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
