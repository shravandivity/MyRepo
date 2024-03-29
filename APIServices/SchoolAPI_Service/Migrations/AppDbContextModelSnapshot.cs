﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolAPI_Service.Data;

#nullable disable

namespace SchoolAPI_Service.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolAPI_Service.Model.Correspondence", b =>
                {
                    b.Property<Guid>("CorrespondenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CorrespondenceId");

                    b.ToTable("Correspondences");

                    b.HasData(
                        new
                        {
                            CorrespondenceId = new Guid("910814f2-6e6c-4a55-af36-d785638dfd74"),
                            AddressLine1 = "936",
                            AddressLine2 = "Kiehn",
                            AddressLine3 = "Route",
                            City = "West Ned",
                            ContactNo = "609-808-5659",
                            PostalCode = "11230",
                            State = "Tennessee"
                        },
                        new
                        {
                            CorrespondenceId = new Guid("778ee675-8d7f-4e94-bbfe-6fea7d70097c"),
                            AddressLine1 = "4059",
                            AddressLine2 = "Carling",
                            AddressLine3 = "Avenue",
                            City = "Ottawa",
                            ContactNo = "641-895-1620",
                            PostalCode = "K1Z 7B5",
                            State = "Ontario"
                        },
                        new
                        {
                            CorrespondenceId = new Guid("0bba256d-699c-4249-8b11-8b2b1b318028"),
                            AddressLine1 = "60",
                            AddressLine2 = "Caradon",
                            AddressLine3 = "Hill",
                            City = "Ugglebarnby",
                            ContactNo = "501-645-1799",
                            PostalCode = "YO22 3NJ",
                            State = "England"
                        },
                        new
                        {
                            CorrespondenceId = new Guid("d53218c9-6edc-4934-a893-ddbf78181172"),
                            AddressLine1 = "289",
                            AddressLine2 = "Mohr",
                            AddressLine3 = "Heights",
                            City = "Aprilville",
                            ContactNo = "443-296-3808",
                            PostalCode = "6765",
                            State = "Oklahoma"
                        },
                        new
                        {
                            CorrespondenceId = new Guid("c3440248-bb52-44e2-a8cd-50d9d7da3767"),
                            AddressLine1 = "15",
                            AddressLine2 = "Sellamuttu",
                            AddressLine3 = "Avenue",
                            City = "Colombo",
                            ContactNo = "509-398-0516",
                            PostalCode = "00130",
                            State = "Colombo"
                        },
                        new
                        {
                            CorrespondenceId = new Guid("3c0a12df-3290-4e6d-a743-a0e74ad7cd6e"),
                            AddressLine1 = "Avenida",
                            AddressLine2 = "Mireia",
                            AddressLine3 = "Los",
                            City = "Pedro",
                            ContactNo = "314-284-0343",
                            PostalCode = "50268",
                            State = "Cuenca"
                        },
                        new
                        {
                            CorrespondenceId = new Guid("52403dc8-2dd5-442a-8f78-90ac0037ac7e"),
                            AddressLine1 = "832",
                            AddressLine2 = "Boulevard",
                            AddressLine3 = "Ceulemans",
                            City = "Hannut",
                            ContactNo = "626-851-7016",
                            PostalCode = "0748",
                            State = "Mortsel"
                        },
                        new
                        {
                            CorrespondenceId = new Guid("a3d407cb-bc3e-48f6-9041-7dd44440fb9d"),
                            AddressLine1 = "3064",
                            AddressLine2 = "Schinner",
                            AddressLine3 = "Village",
                            City = "South",
                            ContactNo = "336-709-5740",
                            PostalCode = "72052",
                            State = "Louisiana"
                        },
                        new
                        {
                            CorrespondenceId = new Guid("8752d7ed-a11a-4ffc-960f-0be22d7688ac"),
                            AddressLine1 = "25",
                            AddressLine2 = "Ronald",
                            AddressLine3 = "Crescent",
                            City = "Boyne",
                            ContactNo = "361-658-4955",
                            PostalCode = "4680",
                            State = "Queensland"
                        },
                        new
                        {
                            CorrespondenceId = new Guid("d1795d18-6fe0-4372-83fd-ebd7ff528a04"),
                            AddressLine1 = "Thorsten",
                            AddressLine2 = "Busse",
                            AddressLine3 = "Platz",
                            City = "Friedrichsdorf",
                            ContactNo = "502-930-3132",
                            PostalCode = "73556",
                            State = "Baden"
                        },
                        new
                        {
                            CorrespondenceId = new Guid("aa3ac82f-b49e-4739-89ad-5946d1d35639"),
                            AddressLine1 = "89",
                            AddressLine2 = "Katherine",
                            AddressLine3 = "Street",
                            City = "AdedayoVille",
                            ContactNo = "703-989-3495",
                            PostalCode = "40937",
                            State = "IfeomaVille"
                        },
                        new
                        {
                            CorrespondenceId = new Guid("6f53cee3-5291-466b-aafe-07878846199c"),
                            AddressLine1 = "74",
                            AddressLine2 = "rue",
                            AddressLine3 = "Sébastopol",
                            City = "Sainte",
                            ContactNo = "573-691-0786",
                            PostalCode = "97230",
                            State = "Martinique"
                        },
                        new
                        {
                            CorrespondenceId = new Guid("39e98a23-31e6-4cea-9d87-fd58098c2d18"),
                            AddressLine1 = "678",
                            AddressLine2 = "Hayhurst",
                            AddressLine3 = "Lane",
                            City = "Southfield",
                            ContactNo = "248-827-8867",
                            PostalCode = "48034",
                            State = "Michigan"
                        },
                        new
                        {
                            CorrespondenceId = new Guid("6ab8f7c5-b0aa-4e10-a614-9402770fe3b6"),
                            AddressLine1 = "3562",
                            AddressLine2 = "Ritter",
                            AddressLine3 = "Street",
                            City = "Anniston",
                            ContactNo = "256-210-5724",
                            PostalCode = "36207",
                            State = "Alabama"
                        },
                        new
                        {
                            CorrespondenceId = new Guid("b2c4ee92-b191-4c5b-b968-dd9244a5d0d0"),
                            AddressLine1 = "4716",
                            AddressLine2 = "Anthony",
                            AddressLine3 = "Avenue",
                            City = "Abilene",
                            ContactNo = "325-668-4254",
                            PostalCode = "79605",
                            State = "Texas"
                        },
                        new
                        {
                            CorrespondenceId = new Guid("fc5bcd44-ab53-4e3a-9d25-1e4dcf53c488"),
                            AddressLine1 = "2846",
                            AddressLine2 = "Valley",
                            AddressLine3 = "Street",
                            City = "Laurel",
                            ContactNo = "732-859-6840",
                            PostalCode = "08021",
                            State = "New Jersey"
                        });
                });

            modelBuilder.Entity("SchoolAPI_Service.Model.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CorrespondenceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RollNo")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("CorrespondenceId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("8539cce1-8908-4788-b1e1-2b547680c7a0"),
                            CorrespondenceId = new Guid("910814f2-6e6c-4a55-af36-d785638dfd74"),
                            FirstName = "Abigail",
                            Grade = "Grade1",
                            LastName = "Adam",
                            RollNo = 1
                        },
                        new
                        {
                            StudentId = new Guid("ebd260a4-ea6f-4e79-8f91-802b27eacf00"),
                            CorrespondenceId = new Guid("778ee675-8d7f-4e94-bbfe-6fea7d70097c"),
                            FirstName = "Alexandra",
                            Grade = "Grade2",
                            LastName = "Adrian",
                            RollNo = 2
                        },
                        new
                        {
                            StudentId = new Guid("81b6b89d-1451-42ea-b838-5e03c3323a78"),
                            CorrespondenceId = new Guid("0bba256d-699c-4249-8b11-8b2b1b318028"),
                            FirstName = "Alison",
                            Grade = "Grade3",
                            LastName = "Alan",
                            RollNo = 3
                        },
                        new
                        {
                            StudentId = new Guid("3e65dd64-d9a5-4c85-ac07-0d7123c8dc62"),
                            CorrespondenceId = new Guid("d53218c9-6edc-4934-a893-ddbf78181172"),
                            FirstName = "Amanda",
                            Grade = "Grade4",
                            LastName = "Alexander",
                            RollNo = 4
                        },
                        new
                        {
                            StudentId = new Guid("b4a8b5eb-fb5c-4b90-bda7-51a1a418619c"),
                            CorrespondenceId = new Guid("c3440248-bb52-44e2-a8cd-50d9d7da3767"),
                            FirstName = "Amelia",
                            Grade = "Grade5",
                            LastName = "Andrew",
                            RollNo = 5
                        },
                        new
                        {
                            StudentId = new Guid("4451304a-1f6f-473a-bfae-82c464f588a4"),
                            CorrespondenceId = new Guid("3c0a12df-3290-4e6d-a743-a0e74ad7cd6e"),
                            FirstName = "Amy",
                            Grade = "Grade6",
                            LastName = "Anthony",
                            RollNo = 6
                        },
                        new
                        {
                            StudentId = new Guid("3cbd3e62-fa8f-4959-afa0-b04cef5e27dd"),
                            CorrespondenceId = new Guid("52403dc8-2dd5-442a-8f78-90ac0037ac7e"),
                            FirstName = "Andrea",
                            Grade = "Grade7",
                            LastName = "Austin",
                            RollNo = 7
                        },
                        new
                        {
                            StudentId = new Guid("ee18c914-94c2-4be5-8831-73934622e65f"),
                            CorrespondenceId = new Guid("a3d407cb-bc3e-48f6-9041-7dd44440fb9d"),
                            FirstName = "Angela",
                            Grade = "Grade8",
                            LastName = "Benjamin",
                            RollNo = 8
                        },
                        new
                        {
                            StudentId = new Guid("152c4f83-81b0-4141-9d8c-3d83af70ab4d"),
                            CorrespondenceId = new Guid("8752d7ed-a11a-4ffc-960f-0be22d7688ac"),
                            FirstName = "Anna",
                            Grade = "Grade9",
                            LastName = "Blake",
                            RollNo = 9
                        },
                        new
                        {
                            StudentId = new Guid("3bf9d8b6-9cbe-4f91-800e-c86ad4c44211"),
                            CorrespondenceId = new Guid("d1795d18-6fe0-4372-83fd-ebd7ff528a04"),
                            FirstName = "Anne",
                            Grade = "Grade10",
                            LastName = "Boris",
                            RollNo = 10
                        });
                });

            modelBuilder.Entity("SchoolAPI_Service.Model.Subject", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            SubjectId = new Guid("c2ad5688-4d69-486d-909b-01499578f03c"),
                            SubjectName = "English"
                        },
                        new
                        {
                            SubjectId = new Guid("ead900b8-baa2-4b4f-8914-35e3dbf71e2d"),
                            SubjectName = "Hindi"
                        },
                        new
                        {
                            SubjectId = new Guid("fe567db9-e7f6-4c6c-ae63-3138eb913975"),
                            SubjectName = "Marathi"
                        },
                        new
                        {
                            SubjectId = new Guid("2a52b738-e89b-489a-9963-3512d84fcfe4"),
                            SubjectName = "Science"
                        },
                        new
                        {
                            SubjectId = new Guid("df9d90ce-7081-4790-9e23-37b106e1e2dd"),
                            SubjectName = "Maths"
                        },
                        new
                        {
                            SubjectId = new Guid("688cb3c2-e4a7-4e48-adf0-6864f32b8754"),
                            SubjectName = "Social Studies"
                        });
                });

            modelBuilder.Entity("SchoolAPI_Service.Model.Teacher", b =>
                {
                    b.Property<Guid>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClassRoom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CorrespondenceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TeacherId");

                    b.HasIndex("CorrespondenceId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherId = new Guid("7dc33b2c-f4cf-436d-b8aa-1b02221c6c05"),
                            ClassRoom = "Grade1",
                            CorrespondenceId = new Guid("aa3ac82f-b49e-4739-89ad-5946d1d35639"),
                            FirstName = "James",
                            LastName = "Theresa",
                            SubjectId = new Guid("c2ad5688-4d69-486d-909b-01499578f03c")
                        },
                        new
                        {
                            TeacherId = new Guid("f7161400-798f-44b0-94d1-7e5ed1758cdc"),
                            ClassRoom = "Grade2",
                            CorrespondenceId = new Guid("6f53cee3-5291-466b-aafe-07878846199c"),
                            FirstName = "Jason",
                            LastName = "Stephanie",
                            SubjectId = new Guid("ead900b8-baa2-4b4f-8914-35e3dbf71e2d")
                        },
                        new
                        {
                            TeacherId = new Guid("8ef46b31-2a1d-4c5d-a322-206b80d4bb0b"),
                            ClassRoom = "Grade3",
                            CorrespondenceId = new Guid("39e98a23-31e6-4cea-9d87-fd58098c2d18"),
                            FirstName = "John",
                            LastName = "Pippa",
                            SubjectId = new Guid("fe567db9-e7f6-4c6c-ae63-3138eb913975")
                        },
                        new
                        {
                            TeacherId = new Guid("e412ddf2-6da7-470a-bc55-34330369ea30"),
                            ClassRoom = "Grade4",
                            CorrespondenceId = new Guid("6ab8f7c5-b0aa-4e10-a614-9402770fe3b6"),
                            FirstName = "Jonathan",
                            LastName = "Olivia",
                            SubjectId = new Guid("2a52b738-e89b-489a-9963-3512d84fcfe4")
                        },
                        new
                        {
                            TeacherId = new Guid("f73a4fd5-06b7-4846-825f-491dfa0bcd6e"),
                            ClassRoom = "Grade5",
                            CorrespondenceId = new Guid("b2c4ee92-b191-4c5b-b968-dd9244a5d0d0"),
                            FirstName = "Joshua",
                            LastName = "Nicola",
                            SubjectId = new Guid("df9d90ce-7081-4790-9e23-37b106e1e2dd")
                        },
                        new
                        {
                            TeacherId = new Guid("40af3097-fa34-43cc-96f8-1c269bc29c64"),
                            ClassRoom = "Grade6",
                            CorrespondenceId = new Guid("fc5bcd44-ab53-4e3a-9d25-1e4dcf53c488"),
                            FirstName = "Justin",
                            LastName = "Megan",
                            SubjectId = new Guid("688cb3c2-e4a7-4e48-adf0-6864f32b8754")
                        });
                });

            modelBuilder.Entity("SchoolAPI_Service.Model.Student", b =>
                {
                    b.HasOne("SchoolAPI_Service.Model.Correspondence", "Correspondence")
                        .WithMany()
                        .HasForeignKey("CorrespondenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Correspondence");
                });

            modelBuilder.Entity("SchoolAPI_Service.Model.Teacher", b =>
                {
                    b.HasOne("SchoolAPI_Service.Model.Correspondence", "Correspondence")
                        .WithMany()
                        .HasForeignKey("CorrespondenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolAPI_Service.Model.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Correspondence");

                    b.Navigation("Subject");
                });
#pragma warning restore 612, 618
        }
    }
}
