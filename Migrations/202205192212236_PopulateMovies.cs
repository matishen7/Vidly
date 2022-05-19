namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON");
            Sql(@"INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) VALUES (1, 'Hangover', '04/23/1998', '02/21/2022', 5, 1)");
            Sql(@"INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) VALUES (2, 'Die Hard', '03/11/2022', '03/06/2022', 15, 2)");
            Sql(@"INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) VALUES (3, 'The Terminator', '03/06/2021', '03/21/2022', 3, 2)");
            Sql(@"INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) VALUES (4, 'Toy Story', '04/23/1972', '02/21/2019', 45, 5)");
            Sql(@"INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) VALUES (5, 'Titanic', '04/23/2000', '04/03/2022', 10, 4)");
            Sql(@"INSERT INTO Movies (Id, Name, ReleaseDate, DateAdded, NumberInStock, Genre_Id) VALUES (6, 'It.', '04/23/1998', '02/21/2024', 8, 6)");
        }

        public override void Down()
        {
        }
    }
}
