using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Qualification { get; set; }
        public string Specilization { get; set; }
        public string City { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Doctor(int id, string name, string address, double phoneNumber, int age, string qualification, string specilization, string city, string username, string password)
        {
            Id = id;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Age = age;
            Qualification = qualification;
            Specilization = specilization;
            City = city;
            Username = username;
            Password = password;
        }
    }
}
