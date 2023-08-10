using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolAPI_Service.Migrations
{
    /// <inheritdoc />
    public partial class SchoolAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Correspondences",
                columns: table => new
                {
                    CorrespondenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correspondences", x => x.CorrespondenceId);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RollNo = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrespondenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Correspondences_CorrespondenceId",
                        column: x => x.CorrespondenceId,
                        principalTable: "Correspondences",
                        principalColumn: "CorrespondenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassRoom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorrespondenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_Teachers_Correspondences_CorrespondenceId",
                        column: x => x.CorrespondenceId,
                        principalTable: "Correspondences",
                        principalColumn: "CorrespondenceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachers_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Correspondences",
                columns: new[] { "CorrespondenceId", "AddressLine1", "AddressLine2", "AddressLine3", "City", "ContactNo", "PostalCode", "State" },
                values: new object[,]
                {
                    { new Guid("0bba256d-699c-4249-8b11-8b2b1b318028"), "60", "Caradon", "Hill", "Ugglebarnby", "501-645-1799", "YO22 3NJ", "England" },
                    { new Guid("39e98a23-31e6-4cea-9d87-fd58098c2d18"), "678", "Hayhurst", "Lane", "Southfield", "248-827-8867", "48034", "Michigan" },
                    { new Guid("3c0a12df-3290-4e6d-a743-a0e74ad7cd6e"), "Avenida", "Mireia", "Los", "Pedro", "314-284-0343", "50268", "Cuenca" },
                    { new Guid("52403dc8-2dd5-442a-8f78-90ac0037ac7e"), "832", "Boulevard", "Ceulemans", "Hannut", "626-851-7016", "0748", "Mortsel" },
                    { new Guid("6ab8f7c5-b0aa-4e10-a614-9402770fe3b6"), "3562", "Ritter", "Street", "Anniston", "256-210-5724", "36207", "Alabama" },
                    { new Guid("6f53cee3-5291-466b-aafe-07878846199c"), "74", "rue", "Sébastopol", "Sainte", "573-691-0786", "97230", "Martinique" },
                    { new Guid("778ee675-8d7f-4e94-bbfe-6fea7d70097c"), "4059", "Carling", "Avenue", "Ottawa", "641-895-1620", "K1Z 7B5", "Ontario" },
                    { new Guid("8752d7ed-a11a-4ffc-960f-0be22d7688ac"), "25", "Ronald", "Crescent", "Boyne", "361-658-4955", "4680", "Queensland" },
                    { new Guid("910814f2-6e6c-4a55-af36-d785638dfd74"), "936", "Kiehn", "Route", "West Ned", "609-808-5659", "11230", "Tennessee" },
                    { new Guid("a3d407cb-bc3e-48f6-9041-7dd44440fb9d"), "3064", "Schinner", "Village", "South", "336-709-5740", "72052", "Louisiana" },
                    { new Guid("aa3ac82f-b49e-4739-89ad-5946d1d35639"), "89", "Katherine", "Street", "AdedayoVille", "703-989-3495", "40937", "IfeomaVille" },
                    { new Guid("b2c4ee92-b191-4c5b-b968-dd9244a5d0d0"), "4716", "Anthony", "Avenue", "Abilene", "325-668-4254", "79605", "Texas" },
                    { new Guid("c3440248-bb52-44e2-a8cd-50d9d7da3767"), "15", "Sellamuttu", "Avenue", "Colombo", "509-398-0516", "00130", "Colombo" },
                    { new Guid("d1795d18-6fe0-4372-83fd-ebd7ff528a04"), "Thorsten", "Busse", "Platz", "Friedrichsdorf", "502-930-3132", "73556", "Baden" },
                    { new Guid("d53218c9-6edc-4934-a893-ddbf78181172"), "289", "Mohr", "Heights", "Aprilville", "443-296-3808", "6765", "Oklahoma" },
                    { new Guid("fc5bcd44-ab53-4e3a-9d25-1e4dcf53c488"), "2846", "Valley", "Street", "Laurel", "732-859-6840", "08021", "New Jersey" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("2a52b738-e89b-489a-9963-3512d84fcfe4"), "Science" },
                    { new Guid("688cb3c2-e4a7-4e48-adf0-6864f32b8754"), "Social Studies" },
                    { new Guid("c2ad5688-4d69-486d-909b-01499578f03c"), "English" },
                    { new Guid("df9d90ce-7081-4790-9e23-37b106e1e2dd"), "Maths" },
                    { new Guid("ead900b8-baa2-4b4f-8914-35e3dbf71e2d"), "Hindi" },
                    { new Guid("fe567db9-e7f6-4c6c-ae63-3138eb913975"), "Marathi" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "CorrespondenceId", "FirstName", "Grade", "LastName", "RollNo" },
                values: new object[,]
                {
                    { new Guid("152c4f83-81b0-4141-9d8c-3d83af70ab4d"), new Guid("8752d7ed-a11a-4ffc-960f-0be22d7688ac"), "Anna", "Grade9", "Blake", 9 },
                    { new Guid("3bf9d8b6-9cbe-4f91-800e-c86ad4c44211"), new Guid("d1795d18-6fe0-4372-83fd-ebd7ff528a04"), "Anne", "Grade10", "Boris", 10 },
                    { new Guid("3cbd3e62-fa8f-4959-afa0-b04cef5e27dd"), new Guid("52403dc8-2dd5-442a-8f78-90ac0037ac7e"), "Andrea", "Grade7", "Austin", 7 },
                    { new Guid("3e65dd64-d9a5-4c85-ac07-0d7123c8dc62"), new Guid("d53218c9-6edc-4934-a893-ddbf78181172"), "Amanda", "Grade4", "Alexander", 4 },
                    { new Guid("4451304a-1f6f-473a-bfae-82c464f588a4"), new Guid("3c0a12df-3290-4e6d-a743-a0e74ad7cd6e"), "Amy", "Grade6", "Anthony", 6 },
                    { new Guid("81b6b89d-1451-42ea-b838-5e03c3323a78"), new Guid("0bba256d-699c-4249-8b11-8b2b1b318028"), "Alison", "Grade3", "Alan", 3 },
                    { new Guid("8539cce1-8908-4788-b1e1-2b547680c7a0"), new Guid("910814f2-6e6c-4a55-af36-d785638dfd74"), "Abigail", "Grade1", "Adam", 1 },
                    { new Guid("b4a8b5eb-fb5c-4b90-bda7-51a1a418619c"), new Guid("c3440248-bb52-44e2-a8cd-50d9d7da3767"), "Amelia", "Grade5", "Andrew", 5 },
                    { new Guid("ebd260a4-ea6f-4e79-8f91-802b27eacf00"), new Guid("778ee675-8d7f-4e94-bbfe-6fea7d70097c"), "Alexandra", "Grade2", "Adrian", 2 },
                    { new Guid("ee18c914-94c2-4be5-8831-73934622e65f"), new Guid("a3d407cb-bc3e-48f6-9041-7dd44440fb9d"), "Angela", "Grade8", "Benjamin", 8 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "ClassRoom", "CorrespondenceId", "FirstName", "LastName", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("40af3097-fa34-43cc-96f8-1c269bc29c64"), "Grade6", new Guid("fc5bcd44-ab53-4e3a-9d25-1e4dcf53c488"), "Justin", "Megan", new Guid("688cb3c2-e4a7-4e48-adf0-6864f32b8754") },
                    { new Guid("7dc33b2c-f4cf-436d-b8aa-1b02221c6c05"), "Grade1", new Guid("aa3ac82f-b49e-4739-89ad-5946d1d35639"), "James", "Theresa", new Guid("c2ad5688-4d69-486d-909b-01499578f03c") },
                    { new Guid("8ef46b31-2a1d-4c5d-a322-206b80d4bb0b"), "Grade3", new Guid("39e98a23-31e6-4cea-9d87-fd58098c2d18"), "John", "Pippa", new Guid("fe567db9-e7f6-4c6c-ae63-3138eb913975") },
                    { new Guid("e412ddf2-6da7-470a-bc55-34330369ea30"), "Grade4", new Guid("6ab8f7c5-b0aa-4e10-a614-9402770fe3b6"), "Jonathan", "Olivia", new Guid("2a52b738-e89b-489a-9963-3512d84fcfe4") },
                    { new Guid("f7161400-798f-44b0-94d1-7e5ed1758cdc"), "Grade2", new Guid("6f53cee3-5291-466b-aafe-07878846199c"), "Jason", "Stephanie", new Guid("ead900b8-baa2-4b4f-8914-35e3dbf71e2d") },
                    { new Guid("f73a4fd5-06b7-4846-825f-491dfa0bcd6e"), "Grade5", new Guid("b2c4ee92-b191-4c5b-b968-dd9244a5d0d0"), "Joshua", "Nicola", new Guid("df9d90ce-7081-4790-9e23-37b106e1e2dd") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CorrespondenceId",
                table: "Students",
                column: "CorrespondenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CorrespondenceId",
                table: "Teachers",
                column: "CorrespondenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SubjectId",
                table: "Teachers",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Correspondences");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
