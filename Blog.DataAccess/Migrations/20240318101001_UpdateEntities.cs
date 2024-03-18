using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Administrators");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Posts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Administrators",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "CommentsId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    AdministratorId = table.Column<int>(type: "int", nullable: true),
                    CommentsId = table.Column<int>(type: "int", nullable: true),
                    NewPostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Comments_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Posts_NewPostId",
                        column: x => x.NewPostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CommentsId",
                table: "Posts",
                column: "CommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AdministratorId",
                table: "Users",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CommentsId",
                table: "Users",
                column: "CommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NewPostId",
                table: "Users",
                column: "NewPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Comments_CommentsId",
                table: "Posts",
                column: "CommentsId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Comments_CommentsId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CommentsId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CommentsId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Posts",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Administrators",
                newName: "AdminId");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Administrators",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
