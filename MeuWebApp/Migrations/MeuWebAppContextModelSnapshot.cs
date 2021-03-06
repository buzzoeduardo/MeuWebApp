// <auto-generated />
using System;
using MeuWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeuWebApp.Migrations
{
    [DbContext(typeof(MeuWebAppContext))]
    partial class MeuWebAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("MeuWebApp.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("MeuWebApp.Models.Oficial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<double>("SalarioBase")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Oficial");
                });

            modelBuilder.Entity("MeuWebApp.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Montante")
                        .HasColumnType("double");

                    b.Property<int?>("OficialId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OficialId");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("MeuWebApp.Models.Oficial", b =>
                {
                    b.HasOne("MeuWebApp.Models.Department", "Department")
                        .WithMany("Oficiais")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MeuWebApp.Models.Venda", b =>
                {
                    b.HasOne("MeuWebApp.Models.Oficial", "Oficial")
                        .WithMany("Vendas")
                        .HasForeignKey("OficialId");

                    b.Navigation("Oficial");
                });

            modelBuilder.Entity("MeuWebApp.Models.Department", b =>
                {
                    b.Navigation("Oficiais");
                });

            modelBuilder.Entity("MeuWebApp.Models.Oficial", b =>
                {
                    b.Navigation("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}
