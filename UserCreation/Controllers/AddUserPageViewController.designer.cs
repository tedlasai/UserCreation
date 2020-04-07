// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace UserCreation.Controllers
{
    [Register ("AddUserPageViewController")]
    partial class AddUserPageViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton addUserButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField password { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView passwordAlphaNumericIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView passwordAtLeast1CharacterIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView passwordAtLeast1NumberIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView passwordCharacterCountIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView passwordNoIdenticalSequencesIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField username { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView usernameNotEmptyIndicator { get; set; }

        [Action ("AddUserButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddUserButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("FormEdited:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void FormEdited (UIKit.UITextField sender);

        void ReleaseDesignerOutlets ()
        {
            if (addUserButton != null) {
                addUserButton.Dispose ();
                addUserButton = null;
            }

            if (password != null) {
                password.Dispose ();
                password = null;
            }

            if (passwordAlphaNumericIndicator != null) {
                passwordAlphaNumericIndicator.Dispose ();
                passwordAlphaNumericIndicator = null;
            }

            if (passwordAtLeast1CharacterIndicator != null) {
                passwordAtLeast1CharacterIndicator.Dispose ();
                passwordAtLeast1CharacterIndicator = null;
            }

            if (passwordAtLeast1NumberIndicator != null) {
                passwordAtLeast1NumberIndicator.Dispose ();
                passwordAtLeast1NumberIndicator = null;
            }

            if (passwordCharacterCountIndicator != null) {
                passwordCharacterCountIndicator.Dispose ();
                passwordCharacterCountIndicator = null;
            }

            if (passwordNoIdenticalSequencesIndicator != null) {
                passwordNoIdenticalSequencesIndicator.Dispose ();
                passwordNoIdenticalSequencesIndicator = null;
            }

            if (username != null) {
                username.Dispose ();
                username = null;
            }

            if (usernameNotEmptyIndicator != null) {
                usernameNotEmptyIndicator.Dispose ();
                usernameNotEmptyIndicator = null;
            }
        }
    }
}