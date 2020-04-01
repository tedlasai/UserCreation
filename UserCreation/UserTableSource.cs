using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using UserCreation.Models;

namespace UserCreation
{
    public class UserTableSource : UITableViewSource
    {

        List<User> users;
        string CellIdentifier = "TableCell";

        public UserTableSource(List<User> users)
        {
            this.users = users;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return users.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            User user = users[indexPath.Row];
            string item = "Username: " + user.username + " Password: " + user.password;

            //if there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            }

            cell.TextLabel.Text = item;

            return cell;
        }

        public override async void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    // remove the item from the underlying data source
                    User userToDelete = users[indexPath.Row];
                    users.RemoveAt(indexPath.Row); //remove user from current list view

                    //remove userr from database
                    await AppDelegate.Database.DeleteUserAsync(userToDelete);

                    // delete the row from the table
                    tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
                    break;
                case UITableViewCellEditingStyle.None:
                    Console.WriteLine("CommitEditingStyle:None called");
                    break;
            }
        }

        //metthods to delete items from list
        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true; // return false if you wish to disable editing for a specific indexPath or for all rows
        }
        
    }
}