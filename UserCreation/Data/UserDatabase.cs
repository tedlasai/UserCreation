/*File: UserDatabase.cs
 *Description: Methods to interact with user database
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using UserCreation.Models;

namespace UserCreation.Data
{
    public class UserDatabase
    {
        //database connenction 
        readonly SQLiteAsyncConnection _database;

        //constructor
        public UserDatabase(string dbPath)
        {
            //create database connection
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        //get users as list
        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        //get a single user by id
        public Task<User> GetUserAsync(int id)
        {
            return _database.Table<User>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }


        //save a user to database
        public Task<int> SaveUserAsync(User user)
        {
            if (user.Id != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        //delete user from database
        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
    }
}
