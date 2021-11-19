﻿// <auto-generated />
using JOBTIND21.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JOBTIND21.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JOBTIND21.Dominio.Anuncio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Anuncios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Categoria")
                        .HasColumnType("int");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Anuncio");
                });

            modelBuilder.Entity("JOBTIND21.Dominio.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContraseñaEmp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailEmp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TelefonoEmp")
                        .HasColumnType("int");

                    b.Property<string>("Vacante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("JOBTIND21.Dominio.InfoAnuncio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnuncioID")
                        .HasColumnType("int");

                    b.Property<string>("EdadRequerida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Horarios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lugar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requisitos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Stado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AnuncioID");

                    b.ToTable("InfoAnuncio");
                });

            modelBuilder.Entity("JOBTIND21.Dominio.PerfilEmpresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartamentoOperario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescripcionEmpresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<bool>("States")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaID");

                    b.ToTable("PerfilEmpresas");
                });

            modelBuilder.Entity("JOBTIND21.Dominio.PerfilTrabajador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CVLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DUI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTrabajadorID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserTrabajadorID");

                    b.ToTable("PerfilTrabajadors");
                });

            modelBuilder.Entity("JOBTIND21.Dominio.UserTrabajador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserTrabajadors");
                });

            modelBuilder.Entity("JOBTIND21.Dominio.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("JOBTIND21.Dominio.Anuncio", b =>
                {
                    b.HasOne("JOBTIND21.Dominio.Empresa", "Empresa")
                        .WithMany("Anuncio")
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JOBTIND21.Dominio.Usuario", "Usuario")
                        .WithMany("Anuncio")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("JOBTIND21.Dominio.InfoAnuncio", b =>
                {
                    b.HasOne("JOBTIND21.Dominio.Anuncio", "Anuncio")
                        .WithMany("InfoAnuncio")
                        .HasForeignKey("AnuncioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anuncio");
                });

            modelBuilder.Entity("JOBTIND21.Dominio.PerfilEmpresa", b =>
                {
                    b.HasOne("JOBTIND21.Dominio.Empresa", "Empresa")
                        .WithMany("PerfilEmpresa")
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("JOBTIND21.Dominio.PerfilTrabajador", b =>
                {
                    b.HasOne("JOBTIND21.Dominio.UserTrabajador", "UserTrabajador")
                        .WithMany("PerfilTrabajador")
                        .HasForeignKey("UserTrabajadorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserTrabajador");
                });

            modelBuilder.Entity("JOBTIND21.Dominio.Anuncio", b =>
                {
                    b.Navigation("InfoAnuncio");
                });

            modelBuilder.Entity("JOBTIND21.Dominio.Empresa", b =>
                {
                    b.Navigation("Anuncio");

                    b.Navigation("PerfilEmpresa");
                });

            modelBuilder.Entity("JOBTIND21.Dominio.UserTrabajador", b =>
                {
                    b.Navigation("PerfilTrabajador");
                });

            modelBuilder.Entity("JOBTIND21.Dominio.Usuario", b =>
                {
                    b.Navigation("Anuncio");
                });
#pragma warning restore 612, 618
        }
    }
}
