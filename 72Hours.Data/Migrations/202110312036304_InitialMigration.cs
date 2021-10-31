namespace _72Hours.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reply", "Comment_CommentId", "dbo.Comment");
            DropIndex("dbo.Reply", new[] { "Comment_CommentId" });
            RenameColumn(table: "dbo.Reply", name: "Comment_CommentId", newName: "CommentId");
            AlterColumn("dbo.Reply", "CommentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reply", "CommentId");
            AddForeignKey("dbo.Reply", "CommentId", "dbo.Comment", "CommentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropIndex("dbo.Reply", new[] { "CommentId" });
            AlterColumn("dbo.Reply", "CommentId", c => c.Int());
            RenameColumn(table: "dbo.Reply", name: "CommentId", newName: "Comment_CommentId");
            CreateIndex("dbo.Reply", "Comment_CommentId");
            AddForeignKey("dbo.Reply", "Comment_CommentId", "dbo.Comment", "CommentId");
        }
    }
}
