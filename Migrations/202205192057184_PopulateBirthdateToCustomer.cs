namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateBirthdateToCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '04/29/1968' WHERE Id = 1");
        }

        public override void Down()
        {
        }
    }
}
