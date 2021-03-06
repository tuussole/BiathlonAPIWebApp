// <auto-generated />
using System;
using BiathlonAPIWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BiathlonAPIWebApp.Migrations
{
    [DbContext(typeof(BiathlonAPIContext))]
    [Migration("20220607015236_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BiathlonAPIWebApp.Models.Biathlonist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Biathlonists");
                });

            modelBuilder.Entity("BiathlonAPIWebApp.Models.BiathlonistCupPrize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BiathlonistId")
                        .HasColumnType("integer");

                    b.Property<int>("CupId")
                        .HasColumnType("integer");

                    b.Property<int>("PrizeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BiathlonistId");

                    b.HasIndex("CupId");

                    b.HasIndex("PrizeId");

                    b.ToTable("BiathlonistCupPrizes");
                });

            modelBuilder.Entity("BiathlonAPIWebApp.Models.Cup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BeginDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cups");
                });

            modelBuilder.Entity("BiathlonAPIWebApp.Models.Prize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Prizes");
                });

            modelBuilder.Entity("BiathlonAPIWebApp.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CupId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CupId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("BiathlonAPIWebApp.Models.BiathlonistCupPrize", b =>
                {
                    b.HasOne("BiathlonAPIWebApp.Models.Biathlonist", "Biathlonist")
                        .WithMany("BiathlonistCupPrizes")
                        .HasForeignKey("BiathlonistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BiathlonAPIWebApp.Models.Cup", "Cup")
                        .WithMany("BiathlonistCupPrizes")
                        .HasForeignKey("CupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BiathlonAPIWebApp.Models.Prize", "Prize")
                        .WithMany("BiathlonistCupPrizes")
                        .HasForeignKey("PrizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Biathlonist");

                    b.Navigation("Cup");

                    b.Navigation("Prize");
                });

            modelBuilder.Entity("BiathlonAPIWebApp.Models.Race", b =>
                {
                    b.HasOne("BiathlonAPIWebApp.Models.Cup", "Cup")
                        .WithMany("Races")
                        .HasForeignKey("CupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cup");
                });

            modelBuilder.Entity("BiathlonAPIWebApp.Models.Biathlonist", b =>
                {
                    b.Navigation("BiathlonistCupPrizes");
                });

            modelBuilder.Entity("BiathlonAPIWebApp.Models.Cup", b =>
                {
                    b.Navigation("BiathlonistCupPrizes");

                    b.Navigation("Races");
                });

            modelBuilder.Entity("BiathlonAPIWebApp.Models.Prize", b =>
                {
                    b.Navigation("BiathlonistCupPrizes");
                });
#pragma warning restore 612, 618
        }
    }
}
