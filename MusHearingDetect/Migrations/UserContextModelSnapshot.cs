﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusHearingDetect.DbContexts;

namespace MusHearingDetect.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MusHearingDetect.Models.UserProfile.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Answer1");

                    b.Property<bool>("Answer10");

                    b.Property<bool>("Answer11");

                    b.Property<bool>("Answer12");

                    b.Property<bool>("Answer13");

                    b.Property<bool>("Answer14");

                    b.Property<bool>("Answer15");

                    b.Property<bool>("Answer16");

                    b.Property<bool>("Answer17");

                    b.Property<bool>("Answer18");

                    b.Property<bool>("Answer19");

                    b.Property<bool>("Answer2");

                    b.Property<bool>("Answer20");

                    b.Property<bool>("Answer3");

                    b.Property<bool>("Answer4");

                    b.Property<bool>("Answer5");

                    b.Property<bool>("Answer6");

                    b.Property<bool>("Answer7");

                    b.Property<bool>("Answer8");

                    b.Property<bool>("Answer9");

                    b.Property<int>("Result");

                    b.Property<int>("UserAge");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
