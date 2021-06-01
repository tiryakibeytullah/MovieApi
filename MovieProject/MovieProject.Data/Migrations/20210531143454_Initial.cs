using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieProject.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    NumberOfHalls = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InnerBarkod = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InnerBarkod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CinemaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Drama" },
                    { 2, false, "Bilim Kurgu" },
                    { 3, false, "Aksiyon" },
                    { 4, false, "Komedi" }
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Address", "Capacity", "InnerBarkod", "IsDeleted", "Name", "NumberOfHalls" },
                values: new object[,]
                {
                    { 1, "Beylikdüzü / İstanbul", 250, null, false, "Beylikdüzü Sinema Salonu", 5 },
                    { 2, "Beykoz / İstanbul", 500, null, false, "Beykoz Sinema Salonu", 10 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "CinemaId", "ImageUrl", "InnerBarkod", "IsDeleted", "Name", "Subject", "Time" },
                values: new object[,]
                {
                    { 1, 1, null, "1.jpg", null, false, "7.Koğuştaki Mucize", "Yedinci Koğuştaki Mucize, 7 yaşındaki kızı ile aynı zeka yaşına sahip bir babanın adalet arayışını konu ediyor. 1983 yılında bir Ege kasabasında küçük bir kız ölür. Ölen küçük kız sıkıyönetim komutanının kızıdır ve onun ölümünün sorumlusu olarak babaannesi ile yaşayan ve 7 yaşında bir kızı olan Memo görülür.", 3 },
                    { 2, 1, null, "2.jpg", null, false, "Esaretin Bedeli", "Stephen King'in Rita Hayworth ve Shawshank'in Kefareti adlı novellasından uyarlanan film, masumiyetini iddia etmesine rağmen karısını ve sevgilisini öldürdüğü gerekçesiyle Shawshank Devlet Cezaevi'nde yaklaşık 20 yılını geçiren bankacı Andy Dufresne'in hikâyesini anlatır.", 3 },
                    { 3, 2, null, "3.jpg", null, false, "The Platform", "The Platform filmi, Her katında sadece iki kişinin bulunduğu ve çok katlı olan bir hapishanede yaşanılan sınıfsal ayrımları ve haksızlıkları anlatıyor. Hapishanede dağıtılan yemekler ilk başta en üst katta olanlara veriliyor, artan yemekler ise bir alt kattakine gidiyor.", 2 },
                    { 4, 3, null, "4.jpg", null, false, "Extraction", "Extraction, silah satıcıları ve kaçakçılara ait bir dünyada, uyuşturucu lordları arasında geçen savaşta piyon olan genç bir çocuğun hikayesini konu ediliyor. Kaçırılıp, dünyanın en ücra şehrine gönderilen Hintli çocuğun işadamı olan babası, oğlunu kurtarması için bir adam kiralar.", 3 },
                    { 5, 4, null, "5.jpg", null, false, "Aykut Enişte", "Aykut Enişte, yalnızlığından şikayetçi olan ve aile özlemi çeken bir adam olan Aykut'un hikayesini konu ediyor. Aykut, evlenip yuva kurmanın hayali ile yaşayan genç bir adamdır. ... Dükkana bakmak için sigortadan gelen Gülşah'ın, Aykut'tan küçük bir iyilik istemesi hepsinin hayatının değişmesine neden olur.", 2 },
                    { 6, 4, null, "6.jpg", null, false, "Kolpaçino", "Tayfun, İstanbul'un ünlü suç adamlarından Ateş'in yanında çalışmaktadır. Kendisinden mal çaldığını düşünen Ateş, Tayfun'u 10 gün içinde eksilen mallarını geri getirmek ve 50 bin dolarla cezalandırır. Tayfun bu parayı bulmak için Dolapdereli Sabri'den yardım ister.", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CinemaId",
                table: "Movies",
                column: "CinemaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cinemas");
        }
    }
}
