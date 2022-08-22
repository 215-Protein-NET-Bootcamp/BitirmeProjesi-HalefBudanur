using System;

namespace BitirmeProjesi.Model
{
    public class Person
    {
        public int AccountId { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }       
        public string Description { get; set; }       
        public string Phone { get; set; }       
        public DateTime DateOfBirth { get; set; }
    }
}
