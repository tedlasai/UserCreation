/*File: AddUserPageViewController.cs
 *Description: Add User Page controller that handles anything on add user page
 */
using System;
using UIKit;
using UserCreation.Models;
using UserCreation.ViewModels;

namespace UserCreation.Controllers
{
    public partial class AddUserPageViewController : UIViewController
    {

        //declare viewmodel
        public AddUserPageViewModel addUserPageViewModel { get; set; }

        //constructor
        public AddUserPageViewController(IntPtr handle) : base(handle)
        {
         
        }
        //when view loads initialize models
        public override void ViewDidLoad()
        {
    
            base.ViewDidLoad();
            addUserPageViewModel = new AddUserPageViewModel(); //initialize models
            // Perform any additional setup after loading the view, typically from a nib.
        }

        //what do when coming back to this page after loading it(coming back from users view)
        public override void ViewDidAppear(bool animated)
        {
      
            base.ViewDidAppear(animated);
            //clear text fields if coming back to page
            username.Text = @"";
            password.Text = @"";
            FormEdited(null); //update validators
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


        //What do when the textfield changes
        //This method will automatically update the colors of the indicators for the username/password validation
        partial void FormEdited(UITextField sender)
        {

            //Update validation class with current username and password text
            addUserPageViewModel.validation.updatedInfo(username.Text, password.Text);

            //based on the validaiton results set the colors of the indicators to green(good) or red(fail)
            passwordAtLeast1CharacterIndicator.TintColor = SetColor(addUserPageViewModel.validation.passwordAtLeast1Character);
            passwordAlphaNumericIndicator.TintColor = SetColor(addUserPageViewModel.validation.passwordAlphaNumeric);
            passwordAtLeast1NumberIndicator.TintColor = SetColor(addUserPageViewModel.validation.passwordAtLeast1Number);
            passwordCharacterCountIndicator.TintColor = SetColor(addUserPageViewModel.validation.passwordCharacterCount);
            passwordNoIdenticalSequencesIndicator.TintColor = SetColor(addUserPageViewModel.validation.passwordNoIdenticalSequences);
            usernameNotEmptyIndicator.TintColor = SetColor(addUserPageViewModel.validation.usernameNotEmpty);

            //enable user button when all the validators are good
            addUserButton.Enabled = addUserPageViewModel.validation.allValid;
        }


        //return green for true and red for false(helper function)
        UIColor SetColor(bool input)
        {
            return input ? UIColor.Green : UIColor.Red;
        }

        // Method called when add user button is hit
        partial void AddUserButton_TouchUpInside(UIButton sender)
        {
            //Create user and add the username and password text to it
            User newUser = new User();
            newUser.username = username.Text;
            newUser.password = password.Text;

            //Store user to database
            AppDelegate.Database.SaveUserAsync(newUser);

            //Go back to user view
            NavigationController.PopViewController(true);
        }
    }
}