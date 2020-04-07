/*File: UserTableViewController.cs
 *Description: Controllerthat handles anything on user view page(listview)
 */
using System;
using System.Collections.Generic;
using UIKit;
using UserCreation.Models;
using UserCreation.ViewModels;

namespace UserCreation.Controllers
{
    public partial class UserTableViewController : UITableViewController
    {
        //constructor
        public UserTableViewController(IntPtr handle) : base(handle)
        { 
            
        }

        //load UserTableSource anytime view is shown
        //this will update the list when there is a new user
        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            //get current users
            List<User> users= await AppDelegate.Database.GetUsersAsync();

            //specify tableview source
            TableView.Source = new UserTableSource(users);
            TableView.ReloadData(); //update view to show new data
        }

     
    }
    
}