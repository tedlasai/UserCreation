/*File: UserTableSource.cs
 *Description: User Table Source specifies what will be shown in the user table
 */

using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using UserCreation.Models;

namespace UserCreation.ViewModels
{
    public class UserTableSource : UITableViewSource
    {
        //Store list of users from database
        List<User> users;
        string CellIdentifier = "TableCell";

        //constructor
        public UserTableSource(List<User> users)
        {
            this.users = users;
        }

        //function to specify rows for tableview
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return users.Count;
        }

        //function used to decide string that shows in table view
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);

            //get user on current row
            User user = users[indexPath.Row];

            //construct string that contains username and password for display
            string item = "Username: " + user.username + " Password: " + user.password;

            //if there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            }


            //set cell text as the string created above
            cell.TextLabel.Text = item;

            return cell;
        }


        //allow user to edit list and delete items from list
        public override async void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    // remove the item from the underlying data source
                    User userToDelete = users[indexPath.Row];
                    users.RemoveAt(indexPath.Row); //remove user from current list view

                    //remove user from database
                    await AppDelegate.Database.DeleteUserAsync(userToDelete);

                    // delete the row from the table
                    tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
                    break;
                case UITableViewCellEditingStyle.None:
                    Console.WriteLine("CommitEditingStyle:None called");
                    break;
            }
        }
        
    }
}