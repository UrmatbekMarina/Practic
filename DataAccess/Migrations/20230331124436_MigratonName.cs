using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class MigratonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    INN = table.Column<int>(type: "int", nullable: true),
                    location = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    user_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    user_role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    user_password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    user_address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    customer_id = table.Column<int>(type: "int", nullable: true),
                    manufacturer_id = table.Column<int>(type: "int", nullable: true),
                    value = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<int>(type: "int", nullable: true),
                    discount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.id);
                    table.ForeignKey(
                        name: "FK__Goods__customer___45F365D3",
                        column: x => x.customer_id,
                        principalTable: "Customer",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Goods__manufactu__46E78A0C",
                        column: x => x.manufacturer_id,
                        principalTable: "Manufacturer",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    category_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    goods_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                    table.ForeignKey(
                        name: "FK__Category__goods___47DBAE45",
                        column: x => x.goods_id,
                        principalTable: "Goods",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    delivery_status = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    delivery_price = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    goods_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.id);
                    table.ForeignKey(
                        name: "FK__Delivery__goods___49C3F6B7",
                        column: x => x.goods_id,
                        principalTable: "Goods",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Delivery__user_i__48CFD27E",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_goods_id",
                table: "Category",
                column: "goods_id");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_goods_id",
                table: "Delivery",
                column: "goods_id");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_user_id",
                table: "Delivery",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_customer_id",
                table: "Goods",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_manufacturer_id",
                table: "Goods",
                column: "manufacturer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Manufacturer");
        }
    }
}
