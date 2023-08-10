using System;
using Microsoft.EntityFrameworkCore;
using SchoolAPI_Service.Model;
using SchoolAPI_Service.Helper;

namespace SchoolAPI_Service.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
		{
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<Correspondence> Correspondences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var subject = new List<Subject>()
            {
                new Subject(){ SubjectId = Guid.Parse("c2ad5688-4d69-486d-909b-01499578f03c"), SubjectName = "English" },
                new Subject(){ SubjectId = Guid.Parse("ead900b8-baa2-4b4f-8914-35e3dbf71e2d"), SubjectName = "Hindi" },
                new Subject(){ SubjectId = Guid.Parse("fe567db9-e7f6-4c6c-ae63-3138eb913975"), SubjectName = "Marathi" },
                new Subject(){ SubjectId = Guid.Parse("2a52b738-e89b-489a-9963-3512d84fcfe4"), SubjectName = "Science" },
                new Subject(){ SubjectId = Guid.Parse("df9d90ce-7081-4790-9e23-37b106e1e2dd"), SubjectName = "Maths" },
                new Subject(){ SubjectId = Guid.Parse("688cb3c2-e4a7-4e48-adf0-6864f32b8754"), SubjectName = "Social Studies" },
            };
            var students = new List<Student>()
            {
                new Student(){StudentId = Guid.Parse("8539cce1-8908-4788-b1e1-2b547680c7a0"),FirstName = "Abigail",LastName="Adam",RollNo=1,Grade = Helper.Helper.Grade.Grade1.ToString(), CorrespondenceId = Guid.Parse("910814f2-6e6c-4a55-af36-d785638dfd74")},
                new Student(){StudentId = Guid.Parse("ebd260a4-ea6f-4e79-8f91-802b27eacf00"),FirstName = "Alexandra",LastName="Adrian",RollNo=2,Grade=Helper.Helper.Grade.Grade2.ToString(), CorrespondenceId = Guid.Parse("778ee675-8d7f-4e94-bbfe-6fea7d70097c")},
                new Student(){StudentId = Guid.Parse("81b6b89d-1451-42ea-b838-5e03c3323a78"),FirstName = "Alison",LastName="Alan",RollNo=3,Grade=Helper.Helper.Grade.Grade3.ToString(), CorrespondenceId = Guid.Parse("0bba256d-699c-4249-8b11-8b2b1b318028")},
                new Student(){StudentId = Guid.Parse("3e65dd64-d9a5-4c85-ac07-0d7123c8dc62"),FirstName = "Amanda",LastName="Alexander",RollNo=4,Grade=Helper.Helper.Grade.Grade4.ToString(), CorrespondenceId = Guid.Parse("d53218c9-6edc-4934-a893-ddbf78181172")},
                new Student(){StudentId = Guid.Parse("b4a8b5eb-fb5c-4b90-bda7-51a1a418619c"),FirstName = "Amelia",LastName="Andrew",RollNo=5,Grade=Helper.Helper.Grade.Grade5.ToString(), CorrespondenceId = Guid.Parse("c3440248-bb52-44e2-a8cd-50d9d7da3767")},
                new Student(){StudentId = Guid.Parse("4451304a-1f6f-473a-bfae-82c464f588a4"),FirstName = "Amy",LastName="Anthony",RollNo=6,Grade=Helper.Helper.Grade.Grade6.ToString(), CorrespondenceId = Guid.Parse("3c0a12df-3290-4e6d-a743-a0e74ad7cd6e")},
                new Student(){StudentId = Guid.Parse("3cbd3e62-fa8f-4959-afa0-b04cef5e27dd"),FirstName = "Andrea",LastName="Austin",RollNo=7,Grade=Helper.Helper.Grade.Grade7.ToString(), CorrespondenceId = Guid.Parse("52403dc8-2dd5-442a-8f78-90ac0037ac7e")},
                new Student(){StudentId = Guid.Parse("ee18c914-94c2-4be5-8831-73934622e65f"),FirstName = "Angela",LastName="Benjamin",RollNo=8,Grade=Helper.Helper.Grade.Grade8.ToString(),  CorrespondenceId = Guid.Parse("a3d407cb-bc3e-48f6-9041-7dd44440fb9d")},
                new Student(){StudentId = Guid.Parse("152c4f83-81b0-4141-9d8c-3d83af70ab4d"),FirstName = "Anna",LastName="Blake",RollNo=9,Grade=Helper.Helper.Grade.Grade9.ToString(), CorrespondenceId = Guid.Parse("8752d7ed-a11a-4ffc-960f-0be22d7688ac")},
                new Student(){StudentId = Guid.Parse("3bf9d8b6-9cbe-4f91-800e-c86ad4c44211"),FirstName = "Anne",LastName="Boris",RollNo=10,Grade=Helper.Helper.Grade.Grade10.ToString(),  CorrespondenceId = Guid.Parse("d1795d18-6fe0-4372-83fd-ebd7ff528a04")}
            };

            var teacher = new List<Teacher>()
            {
                new Teacher(){ TeacherId = Guid.Parse("7dc33b2c-f4cf-436d-b8aa-1b02221c6c05"), FirstName = "James", LastName = "Theresa", ClassRoom = Helper.Helper.Grade.Grade1.ToString(), SubjectId = Guid.Parse("c2ad5688-4d69-486d-909b-01499578f03c"), CorrespondenceId = Guid.Parse("aa3ac82f-b49e-4739-89ad-5946d1d35639")},
                new Teacher(){ TeacherId = Guid.Parse("f7161400-798f-44b0-94d1-7e5ed1758cdc"), FirstName = "Jason", LastName = "Stephanie", ClassRoom = Helper.Helper.Grade.Grade2.ToString(), SubjectId = Guid.Parse("ead900b8-baa2-4b4f-8914-35e3dbf71e2d"), CorrespondenceId = Guid.Parse("6f53cee3-5291-466b-aafe-07878846199c")},
                new Teacher(){ TeacherId = Guid.Parse("8ef46b31-2a1d-4c5d-a322-206b80d4bb0b"), FirstName = "John", LastName = "Pippa", ClassRoom = Helper.Helper.Grade.Grade3.ToString(), SubjectId = Guid.Parse("fe567db9-e7f6-4c6c-ae63-3138eb913975"), CorrespondenceId = Guid.Parse("39e98a23-31e6-4cea-9d87-fd58098c2d18")},
                new Teacher(){ TeacherId = Guid.Parse("e412ddf2-6da7-470a-bc55-34330369ea30"), FirstName = "Jonathan", LastName = "Olivia", ClassRoom = Helper.Helper.Grade.Grade4.ToString(), SubjectId = Guid.Parse("2a52b738-e89b-489a-9963-3512d84fcfe4"), CorrespondenceId = Guid.Parse("6ab8f7c5-b0aa-4e10-a614-9402770fe3b6")},
                new Teacher(){ TeacherId = Guid.Parse("f73a4fd5-06b7-4846-825f-491dfa0bcd6e"), FirstName = "Joshua", LastName = "Nicola", ClassRoom = Helper.Helper.Grade.Grade5.ToString(), SubjectId = Guid.Parse("df9d90ce-7081-4790-9e23-37b106e1e2dd"), CorrespondenceId = Guid.Parse("b2c4ee92-b191-4c5b-b968-dd9244a5d0d0")},
                new Teacher(){ TeacherId = Guid.Parse("40af3097-fa34-43cc-96f8-1c269bc29c64"), FirstName = "Justin", LastName = "Megan", ClassRoom = Helper.Helper.Grade.Grade6.ToString(), SubjectId = Guid.Parse("688cb3c2-e4a7-4e48-adf0-6864f32b8754"), CorrespondenceId = Guid.Parse("fc5bcd44-ab53-4e3a-9d25-1e4dcf53c488")},
            };
            var correspondence = new List<Correspondence>()
            {
                new Correspondence(){ CorrespondenceId = Guid.Parse("910814f2-6e6c-4a55-af36-d785638dfd74"), AddressLine1 = "936", AddressLine2 = "Kiehn", AddressLine3 = "Route", City = "West Ned", State = "Tennessee", PostalCode = "11230" , ContactNo = "609-808-5659"},
                new Correspondence(){ CorrespondenceId = Guid.Parse("778ee675-8d7f-4e94-bbfe-6fea7d70097c"), AddressLine1 = "4059", AddressLine2 = "Carling", AddressLine3 = "Avenue", City = "Ottawa", State = "Ontario", PostalCode = "K1Z 7B5" , ContactNo = "641-895-1620"},
                new Correspondence(){ CorrespondenceId = Guid.Parse("0bba256d-699c-4249-8b11-8b2b1b318028"), AddressLine1 = "60", AddressLine2 = "Caradon", AddressLine3 = "Hill", City = "Ugglebarnby", State = "England", PostalCode = "YO22 3NJ" , ContactNo = "501-645-1799"},
                new Correspondence(){ CorrespondenceId = Guid.Parse("d53218c9-6edc-4934-a893-ddbf78181172"), AddressLine1 = "289", AddressLine2 = "Mohr", AddressLine3 = "Heights", City = "Aprilville", State = "Oklahoma", PostalCode = "6765" , ContactNo = "443-296-3808"},
                new Correspondence(){ CorrespondenceId = Guid.Parse("c3440248-bb52-44e2-a8cd-50d9d7da3767"), AddressLine1 = "15", AddressLine2 = "Sellamuttu", AddressLine3 = "Avenue", City = "Colombo", State = "Colombo", PostalCode = "00130" , ContactNo = "509-398-0516"},
                new Correspondence(){ CorrespondenceId = Guid.Parse("3c0a12df-3290-4e6d-a743-a0e74ad7cd6e"), AddressLine1 = "Avenida", AddressLine2 = "Mireia", AddressLine3 = "Los", City = "Pedro", State = "Cuenca", PostalCode = "50268" , ContactNo = "314-284-0343"},
                new Correspondence(){ CorrespondenceId = Guid.Parse("52403dc8-2dd5-442a-8f78-90ac0037ac7e"), AddressLine1 = "832", AddressLine2 = "Boulevard", AddressLine3 = "Ceulemans", City = "Hannut", State = "Mortsel", PostalCode = "0748" , ContactNo = "626-851-7016"},
                new Correspondence(){ CorrespondenceId = Guid.Parse("a3d407cb-bc3e-48f6-9041-7dd44440fb9d"), AddressLine1 = "3064", AddressLine2 = "Schinner", AddressLine3 = "Village", City = "South", State = "Louisiana", PostalCode = "72052" , ContactNo = "336-709-5740"},
                new Correspondence(){ CorrespondenceId = Guid.Parse("8752d7ed-a11a-4ffc-960f-0be22d7688ac"), AddressLine1 = "25", AddressLine2 = "Ronald", AddressLine3 = "Crescent", City = "Boyne", State = "Queensland", PostalCode = "4680" , ContactNo = "361-658-4955"},
                new Correspondence(){ CorrespondenceId = Guid.Parse("d1795d18-6fe0-4372-83fd-ebd7ff528a04"), AddressLine1 = "Thorsten", AddressLine2 = "Busse", AddressLine3 = "Platz", City = "Friedrichsdorf", State = "Baden", PostalCode = "73556" , ContactNo = "502-930-3132"},
                new Correspondence(){ CorrespondenceId = Guid.Parse("aa3ac82f-b49e-4739-89ad-5946d1d35639"), AddressLine1 = "89", AddressLine2 = "Katherine", AddressLine3 = "Street", City = "AdedayoVille", State = "IfeomaVille", PostalCode = "40937" , ContactNo = "703-989-3495"},
                new Correspondence(){ CorrespondenceId = Guid.Parse("6f53cee3-5291-466b-aafe-07878846199c"), AddressLine1 = "74", AddressLine2 = "rue", AddressLine3 = "Sébastopol", City = "Sainte", State = "Martinique", PostalCode = "97230" , ContactNo = "573-691-0786"},
                new Correspondence(){ CorrespondenceId = Guid.Parse("39e98a23-31e6-4cea-9d87-fd58098c2d18"), AddressLine1 = "678", AddressLine2 = "Hayhurst", AddressLine3 = "Lane", City = "Southfield", State = "Michigan", PostalCode = "48034" , ContactNo = "248-827-8867"},
                new Correspondence(){ CorrespondenceId = Guid.Parse("6ab8f7c5-b0aa-4e10-a614-9402770fe3b6"), AddressLine1 = "3562", AddressLine2 = "Ritter", AddressLine3 = "Street", City = "Anniston", State = "Alabama", PostalCode = "36207" , ContactNo = "256-210-5724"},
                new Correspondence(){ CorrespondenceId = Guid.Parse("b2c4ee92-b191-4c5b-b968-dd9244a5d0d0"), AddressLine1 = "4716", AddressLine2 = "Anthony", AddressLine3 = "Avenue", City = "Abilene", State = "Texas", PostalCode = "79605" , ContactNo = "325-668-4254"},
                new Correspondence(){ CorrespondenceId = Guid.Parse("fc5bcd44-ab53-4e3a-9d25-1e4dcf53c488"), AddressLine1 = "2846", AddressLine2 = "Valley", AddressLine3 = "Street", City = "Laurel", State = "New Jersey", PostalCode = "08021" , ContactNo = "732-859-6840"},
            };
            modelBuilder.Entity<Subject>().HasData(subject);
            modelBuilder.Entity<Correspondence>().HasData(correspondence);
            modelBuilder.Entity<Teacher>().HasData(teacher);
            modelBuilder.Entity<Student>().HasData(students);
        }

    }
}

