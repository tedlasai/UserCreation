/*File: User.cs
*Description: User Model for SQL 
*/
using SQLite;

//User Model - Contains username, password, and ID
namespace UserCreation.Models
{
    //create table called user
    [Table("user")]
    public class User
    {
        //make ID autoincrement and make it the primary key of the SQL table
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string username { get; set; }
        public string password { get; set; }
    }
}
