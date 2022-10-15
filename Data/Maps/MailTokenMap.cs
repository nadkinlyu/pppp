using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class MailTokenMap
{
    public MailTokenMap(EntityTypeBuilder<MailToken> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Tokens)
            .HasForeignKey(x => x.UserId);
        
    }
}