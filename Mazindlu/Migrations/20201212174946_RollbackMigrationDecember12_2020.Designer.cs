// <auto-generated />
using Mazindlu.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mazindlu.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20201212174946_RollbackMigrationDecember12_2020")]
    partial class RollbackMigrationDecember12_2020
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mazindlu.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BookProviderId")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookProviderId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Mazindlu.Model.BookPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("URI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("BookPictures");
                });

            modelBuilder.Entity("Mazindlu.Model.BookProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortBio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BookProviders");
                });

            modelBuilder.Entity("Mazindlu.Model.BookProviderPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BookProviderId")
                        .HasColumnType("int");

                    b.Property<string>("URI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookProviderId");

                    b.ToTable("BookProviderPictures");
                });

            modelBuilder.Entity("Mazindlu.Model.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("PropertyProviderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PropertyProviderId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Mazindlu.Model.PropertyPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("int");

                    b.Property<string>("URI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyPictures");
                });

            modelBuilder.Entity("Mazindlu.Model.PropertyProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortBio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PropertyProviders");
                });

            modelBuilder.Entity("Mazindlu.Model.PropertyProviderPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("PropertyProviderId")
                        .HasColumnType("int");

                    b.Property<string>("URI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyProviderId");

                    b.ToTable("PropertyProviderPictures");
                });

            modelBuilder.Entity("Mazindlu.Model.Book", b =>
                {
                    b.HasOne("Mazindlu.Model.BookProvider", null)
                        .WithMany("Books")
                        .HasForeignKey("BookProviderId");
                });

            modelBuilder.Entity("Mazindlu.Model.BookPicture", b =>
                {
                    b.HasOne("Mazindlu.Model.Book", null)
                        .WithMany("BookPictures")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("Mazindlu.Model.BookProviderPicture", b =>
                {
                    b.HasOne("Mazindlu.Model.BookProvider", null)
                        .WithMany("BookProviderPictures")
                        .HasForeignKey("BookProviderId");
                });

            modelBuilder.Entity("Mazindlu.Model.Property", b =>
                {
                    b.HasOne("Mazindlu.Model.PropertyProvider", null)
                        .WithMany("Properties")
                        .HasForeignKey("PropertyProviderId");
                });

            modelBuilder.Entity("Mazindlu.Model.PropertyPicture", b =>
                {
                    b.HasOne("Mazindlu.Model.Property", null)
                        .WithMany("Pictures")
                        .HasForeignKey("PropertyId");
                });

            modelBuilder.Entity("Mazindlu.Model.PropertyProviderPicture", b =>
                {
                    b.HasOne("Mazindlu.Model.PropertyProvider", null)
                        .WithMany("PropertyProviderPictures")
                        .HasForeignKey("PropertyProviderId");
                });
#pragma warning restore 612, 618
        }
    }
}
