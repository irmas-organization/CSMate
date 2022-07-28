﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SynonymsDB;

#nullable disable

namespace SynonymsDB.Migrations
{
    [DbContext(typeof(SynonymsDbContext))]
    [Migration("20220723213407_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SynonymsDB.Synonym", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("SynonymString")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("synonym");

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("synonyms", (string)null);
                });

            modelBuilder.Entity("SynonymsDB.Word", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("WordString")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("word");

                    b.HasKey("Id");

                    b.ToTable("words", (string)null);
                });

            modelBuilder.Entity("SynonymsDB.WordSynonym", b =>
                {
                    b.Property<long>("WordId")
                        .HasColumnType("bigint")
                        .HasColumnName("word_id");

                    b.Property<long>("SynonymId")
                        .HasColumnType("bigint")
                        .HasColumnName("synonym_id");

                    b.HasKey("WordId", "SynonymId");

                    b.HasIndex("SynonymId");

                    b.ToTable("wordSynonyms", (string)null);
                });

            modelBuilder.Entity("SynonymsDB.WordSynonym", b =>
                {
                    b.HasOne("SynonymsDB.Synonym", "Synonym")
                        .WithMany("WordSynonyms")
                        .HasForeignKey("SynonymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SynonymsDB.Word", "Word")
                        .WithMany("WordSynonyms")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Synonym");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("SynonymsDB.Synonym", b =>
                {
                    b.Navigation("WordSynonyms");
                });

            modelBuilder.Entity("SynonymsDB.Word", b =>
                {
                    b.Navigation("WordSynonyms");
                });
#pragma warning restore 612, 618
        }
    }
}