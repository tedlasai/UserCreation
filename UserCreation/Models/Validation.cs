/*File: Validation.cs
*Description: Class to manage validation
*/

using System;
using System.Collections.Generic;

namespace UserCreation.Models
{
    public class Validation
    {
        //store username and password
        public string _username;
        public string _password;

        //validation variables
        //variable is true if validation is met
        //variable is false if validation is failed
        public bool usernameNotEmpty { get; set; }
        public bool passwordAlphaNumeric { get; set; }
        public bool passwordCharacterCount { get; set; }
        public bool passwordAtLeast1Character { get; set; }
        public bool passwordAtLeast1Number { get; set; }
        public bool passwordNoIdenticalSequences { get; set; }

        //allValid if all the other validators are true
        public bool allValid
        {
            get
            {
                return usernameNotEmpty && passwordAlphaNumeric && passwordCharacterCount && passwordAtLeast1Character && passwordAtLeast1Number && passwordNoIdenticalSequences;

            }

        }

        
        public string username
        {
            get
            {
                return _username;
            }

            //setter of username will update the usernameNotEmpty validator
            set
            {
                _username = value;
                //username is not empty if username is not null and not empty
                usernameNotEmpty = username != null && username != ""; 
            }
        }

        
        public string password
        {
            get
            {
                return _password;
            }
            //setter of password will update the password validators
            set
            {
                _password = value;

                //check if password is alphanumeric with regex
                passwordAlphaNumeric = (System.Text.RegularExpressions.Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"));

                //check if password is between 5 and 12 chars
                passwordCharacterCount = password.Length >= 5 && password.Length <= 12;

                //check for at least 1 char and number with regex
                passwordAtLeast1Character = (System.Text.RegularExpressions.Regex.IsMatch(password, @"[a-zA-Z]"));
                passwordAtLeast1Number = (System.Text.RegularExpressions.Regex.IsMatch(password, @"[0-9]"));

                //check for no identical sequences(little more complicated so I put it in a method)
                passwordNoIdenticalSequences = checkForNoIdenticalSequences(password);
            }
        }





        


        /*Algorithm for CheckForNoIdenticalSequences:
               We are looking for consecutive identical sequences.
               We know that second identical sequences could start at any character in the string except at position 1.
               Our algorithm will look for the second identical sequence by using a approach that will look at left side of a "divide" and right side of a "divide"
               Example: appleapple

               Imagine we consider the divide to be between the "e"(Charracter 5) and the "a"(Character 6)
               We can construct all the possible strings on the left side that would cause a duplicate if seen on the right side: [apple, pple, ple, le, e]
               We can construct all the possible strings on the right side that might have duplicated the left side: [a, ap, app, appl, apple]

               We notice that there is a duplicate (apple) between both lists and thus can say there are consecutive identical sequences.

               We can find all consecutive identical sequences like this by moving the "divide" through all points in the string.

               NOTE: For implementation, instead of using lists we will use a dictionary to find the duplicate sequences. However, lists make explaining the algorithm easier.
        */
        public bool checkForNoIdenticalSequences(string password)
        {
            bool identicalSequences = false;

            //Divide starts at 1 and ends right before the last character 
            for (int divide = 1; divide < password.Length; divide++)
            {
                //split string from divide to create left side string and right side string
                string left = password.Substring(0, divide);
                string right = password.Substring(divide);

                //count sequences
                var sequenceMap = new Dictionary<string, bool>();

                //construct left substrings
                for (int i = 0; i < left.Length; i++)
                {
                    sequenceMap.Add(left.Substring(i), true); //add sequence to dictionary and mark that it exists
                }

                Console.WriteLine("HI IN METHOD");

                foreach (string key in sequenceMap.Keys)
                {
                    Console.WriteLine(key);
                    Console.WriteLine(right);
                        Console.WriteLine(left);
                }
                //loop through all rightside substrings to check if they were duplicated on the left side
                for (int i = 1; i <= right.Length; i++)
                {
                    //check if substring was on the left side
                    if (sequenceMap.ContainsKey(right.Substring(0, i)))
                    {
                        identicalSequences = true;
                    }
                }

            }

            return !identicalSequences;
        }

       
        //constructor starts validators all at false
        public Validation()
        {
            usernameNotEmpty = false;
            passwordAlphaNumeric = false;
            passwordCharacterCount = false;
            passwordAtLeast1Character = false;
            passwordAtLeast1Number = false;
            passwordAtLeast1Number = false;
            passwordNoIdenticalSequences = false;
         
        }

        //function to update username and password
        public void updatedInfo(String username, String password)
        {

            this.username = username;
            this.password = password;

        }



    }


}
