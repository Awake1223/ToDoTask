using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoTask.DataAccess.Entities;
using ToDoTask.Domain.Models;

namespace ToDoTask.DataAccess.Configurations
{
    public class ToDoTaskConfiguration : IEntityTypeConfiguration<ToDoTaskEntity>
    {
        public void Configure(EntityTypeBuilder<ToDoTaskEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Name)
                  .IsRequired()
                  .HasMaxLength(Domain.Models.Task.MAX_NAME_LENGTH); // Используем константу правильно

            builder.Property(b => b.Description).IsRequired();

            builder.Property(b => b.IsComplited).IsRequired();


        }
    }
}