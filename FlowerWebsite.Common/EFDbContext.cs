using FlowerWebsite.Model.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWebsite.Common
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options)
       : base(options)
        {
        }

        // 定义 DbSet 属性，映射到数据库表
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        // 使用 Fluent API 配置实体映射关系
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Flower>().ToTable("Flower", "dbo");
            modelBuilder.Entity<User>().ToTable("User", "dbo");
            modelBuilder.Entity<Order>().ToTable("Order", "dbo");

            modelBuilder.Entity<Flower>(entity =>
            {
                entity.HasKey(f => f.Id); // 配置主键

                entity.Property(f => f.Title)
                    .IsRequired()
                    .HasMaxLength(200); // 配置 Title 字段，必须有值，最大长度200

                entity.Property(f => f.Type)
                    .IsRequired(); // 配置 Type 字段，必须有值

                entity.Property(f => f.Image)
                    .HasMaxLength(500); // 配置 Image 字段，最大长度500

                entity.Property(f => f.BigImage)
                    .HasMaxLength(500); // 配置 BigImage 字段，最大长度500

                entity.Property(f => f.Description)
                    .HasMaxLength(1000); // 配置 Description 字段，最大长度1000

                entity.Property(f => f.Price).HasPrecision(18, 2); // 配置 Price 字段为 decimal 类型，精度为18，小数位为2

                entity.Property(f => f.Language)
                    .HasMaxLength(100); // 配置 Language 字段，最大长度100

                entity.Property(f => f.Material)
                    .HasMaxLength(100); // 配置 Material 字段，最大长度100

                entity.Property(f => f.Packing)
                    .HasMaxLength(100); // 配置 Packing 字段，最大长度100

                entity.Property(f => f.DeliveryRemarks)
                    .HasMaxLength(1000); // 配置 DeliveryRemarks 字段，最大长度1000
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id); // 配置主键

                entity.Property(o => o.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(50); // 配置 OrderNumber 字段，必须有值，最大长度50

                entity.Property(o => o.Price)
                    .HasPrecision(18, 2); // 配置 Price 字段为 decimal 类型，精度18，小数位2

                entity.Property(o => o.OrderDate)
                    .IsRequired(); // 配置 OrderDate 字段，必须有值

                // 配置 FlowerId 字段
                entity.Property(o => o.FlowerId)
                    .IsRequired(); // 外键 FlowerId，必须有值

                // 配置 UserId 字段
                entity.Property(o => o.UserId)
                    .IsRequired(); // 外键 UserId，必须有值

                // 你可以在这里配置与其他实体的关系（外键约束等）
                // 例如，如果你有 Flower 和 User 实体，你可以使用 HasOne/WithMany 进行关联。
                // entity.HasOne<Flower>().WithMany().HasForeignKey(o => o.FlowerId);
                // entity.HasOne<User>().WithMany().HasForeignKey(o => o.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id); // 配置主键

                entity.Property(u => u.UserName)
                    .IsRequired()
                    .HasMaxLength(100); // 配置 UserName 字段，必须有值，最大长度100

                entity.Property(u => u.NickName)
                    .HasMaxLength(100); // 配置 NickName 字段，最大长度100

                entity.Property(u => u.Password)
                    .IsRequired()
                    .HasMaxLength(200); // 配置 Password 字段，必须有值，最大长度200

                entity.Property(u => u.CreateTime);
                     // 配置 CreateTime 字段为 datetime 类型

                entity.Property(u => u.UserType)
                    .IsRequired(); // 配置 UserType 字段，必须有值

                // 你可以在这里添加更多配置或关系设置，如果需要的话
            });
        }
    }
}
