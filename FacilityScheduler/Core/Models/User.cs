using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacilityScheduler.Core.Models
{
    public class User
    {
        public enum Category { Admin, Moderator, Faculty, Staff, Student };

        public static Category ConvertCategory(string category)
        {
            switch (category.Trim())
            {
                case "Admin":
                    return Category.Admin;
                case "Moderator":
                    return Category.Moderator;
                case "Faculty":
                    return Category.Faculty;
                case "Staff":
                    return Category.Staff;
                case "Student":
                    return Category.Student;
                default:
                    return Category.Student;
            }
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public Category category { get; set; }
        public bool Verified;

        public User(int Id, string Email, string FirstName, string LastName,
            string Password, Category category, bool Verified)
        {
            this.Id = Id;
            this.Email = Email;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Password = Password;
            this.category = category;
            this.Verified = Verified;
        }

        public User(int Id, string Email, string FirstName, string LastName, Category category, bool Verified)
        {
            this.Id = Id;
            this.Email = Email;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.category = category;
            this.Verified = Verified;
        }

        public User(string Email, string FirstName, string LastName, string Password, Category category)
        {
            this.Email = Email;

            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Password = Password;
            this.category = category;
        }

        public bool IsAdmin()
        {
            return Category.Admin == category;
        }
        public bool IsModerator()
        {
            return Category.Moderator == category;
        }
        public bool IsFaculty()
        {
            return Category.Faculty == category;
        }
        public bool IsStaff()
        {
            return Category.Staff == category;
        }
        public bool IsStudent()
        {
            return Category.Student == category;
        }

    }
}