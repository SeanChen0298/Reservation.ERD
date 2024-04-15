using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reservation.ERD.Appspace.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StartAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceEvent",
                columns: table => new
                {
                    ResourceEventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ResourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceEvent", x => x.ResourceEventId);
                    table.ForeignKey(
                        name: "FK_ResourceEvent_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceEvent_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceEventAttendee",
                columns: table => new
                {
                    ResourceEventAttendeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ResourceEventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceEventAttendee", x => x.ResourceEventAttendeeId);
                    table.ForeignKey(
                        name: "FK_ResourceEventAttendee_ResourceEvent_ResourceEventId",
                        column: x => x.ResourceEventId,
                        principalTable: "ResourceEvent",
                        principalColumn: "ResourceEventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceEvent_EventId",
                table: "ResourceEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceEvent_ResourceId",
                table: "ResourceEvent",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceEventAttendee_ResourceEventId",
                table: "ResourceEventAttendee",
                column: "ResourceEventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceEventAttendee");

            migrationBuilder.DropTable(
                name: "ResourceEvent");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Resource");
        }
    }
}
