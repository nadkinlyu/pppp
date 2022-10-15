using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class DiscontMap
{
    public DiscontMap(EntityTypeBuilder<Discont> builder)
    {
        builder.HasKey(x => x.Id);
    }
}