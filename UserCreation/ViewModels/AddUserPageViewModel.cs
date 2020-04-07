/*File: AddUserPageViewModel.cs
*Description: Class to manage models for AddUserPage
*/
using UserCreation.Models;

namespace UserCreation.ViewModels
{
    public class AddUserPageViewModel
    {
        //declare model for validation
        public Validation validation;

        //initialize validation in constructor
        public AddUserPageViewModel()
        {
            validation = new Validation();
        }

        
    }
}
