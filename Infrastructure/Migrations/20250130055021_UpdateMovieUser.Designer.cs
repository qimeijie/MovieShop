﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    [Migration("20250130055021_UpdateMovieUser")]
    partial class UpdateMovieUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationCore.Entities.Cast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(128)");

                    b.Property<string>("ProfilePath")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(2084)");

                    b.Property<string>("TmdbUrl")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.HasKey("Id");

                    b.ToTable("Casts");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Favorite", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(24)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackdropUrl")
                        .HasColumnType("NVARCHAR(2084)");

                    b.Property<decimal?>("Budget")
                        .HasColumnType("DECIMAL(18,4)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("ImdbUrl")
                        .HasColumnType("NVARCHAR(2084)");

                    b.Property<string>("OriginalLanguage")
                        .HasColumnType("NVARCHAR(64)");

                    b.Property<string>("Overview")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("PosterUrl")
                        .HasColumnType("NVARCHAR(2084)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("DECIMAL(5,2)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("DATETIME2");

                    b.Property<decimal?>("Revenue")
                        .HasColumnType("DECIMAL(18,4)");

                    b.Property<int?>("RunTime")
                        .HasColumnType("int");

                    b.Property<string>("Tagline")
                        .HasColumnType("NVARCHAR(512)");

                    b.Property<string>("Title")
                        .HasColumnType("NVARCHAR(256)");

                    b.Property<string>("TmdbUrl")
                        .HasColumnType("NVARCHAR(2084)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("DATETIME2");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("ApplicationCore.Entities.MovieCast", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("CastId")
                        .HasColumnType("int");

                    b.Property<string>("Character")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(450)");

                    b.HasKey("MovieId", "CastId");

                    b.HasIndex("CastId");

                    b.ToTable("MovieCasts");
                });

            modelBuilder.Entity("ApplicationCore.Entities.MovieGenre", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("MovieGenres");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Purchase", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDateTime")
                        .HasColumnType("DATETIME2");

                    b.Property<Guid>("PurchaseNumber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("DECIMAL(5,2)");

                    b.HasKey("MovieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Review", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DATETIME2");

                    b.Property<decimal>("Rating")
                        .HasColumnType("DECIMAL(3,2)");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.HasKey("MovieId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Trailer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(2084)");

                    b.Property<string>("TrailerUrl")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(2084)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Trailers");
                });

            modelBuilder.Entity("ApplicationCore.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(128)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(1024)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(128)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("NVARCHAR(16)");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(1024)");

                    b.Property<bool?>("isLocked")
                        .HasColumnType("BIT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ApplicationCore.Entities.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Favorite", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Movie", "Movie")
                        .WithMany("Favorites")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApplicationCore.Entities.MovieCast", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Cast", "Cast")
                        .WithMany("MovieCasts")
                        .HasForeignKey("CastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.Movie", "Movie")
                        .WithMany("MovieCasts")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cast");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("ApplicationCore.Entities.MovieGenre", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Purchase", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Movie", "Movie")
                        .WithMany("Purchases")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.User", "User")
                        .WithMany("Purchases")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Review", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Trailer", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Movie", "Movie")
                        .WithMany("Trailers")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("ApplicationCore.Entities.UserRole", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Cast", b =>
                {
                    b.Navigation("MovieCasts");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Genre", b =>
                {
                    b.Navigation("MovieGenres");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Movie", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("MovieCasts");

                    b.Navigation("MovieGenres");

                    b.Navigation("Purchases");

                    b.Navigation("Reviews");

                    b.Navigation("Trailers");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ApplicationCore.Entities.User", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("Purchases");

                    b.Navigation("Reviews");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
