using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using UserCreation.Models;

namespace UserCreation
{
    public partial class UserTableViewController : UITableViewController
    {
        public UserTableViewController(IntPtr handle) : base(handle)
        { 
            
        }

     

        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            List<User> users= await AppDelegate.Database.GetUsersAsync();
            TableView.Source = new UserTableSource(users);
            TableView.ReloadData();
        }

        partial void UIButton15237_TouchUpInside(UIButton sender)
        {
            //throw new NotImplementedException();
        }
    }
    
}