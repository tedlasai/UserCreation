using System;
namespace UserCreation.Models
{
    public class PasswordValidation
    {
        public bool passwordAlphaNumeric { get; set; }
        public bool passwordCharacterCount { get; set; }
        public bool passwordAtLeast1Character { get; set; }
        public bool passwordAtLeast1Number { get; set; }
        public bool oIdenticalSequences { get; set; }
    }
}
