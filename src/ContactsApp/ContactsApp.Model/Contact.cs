using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    public class Contact : ICloneable
    {
        /// <summary>
        /// Фамилия контакта
        /// </summary>
        private string _surname;

        /// <summary>
        /// Имя контакта
        /// </summary>
        private string _name;

        /// <summary>
        /// Емаил контакта
        /// </summary>
        private string _email;

        /// <summary>
        /// Дата рождения
        /// </summary>
        private DateTime _date_of_birth;

        /// <summary>
        /// Айди вк контакта
        /// </summary>
        private string _vkId;

        public const int MAXLETTERCOUNT = 50;

        public string Surname
        {
            get 
            {
                return _surname;
            }
            set 
            {
                if (value.Length > MAXLETTERCOUNT || value.Length == 0)
                {
                    throw new ArgumentException(value + " very long or empty value");
                }
                _surname = value;
            }
        }
        public string Name
        {
            get 
            {
                return _name;
            }
            set 
            {
                if (value.Length > MAXLETTERCOUNT || value.Length == 0)
                {
                    throw new ArgumentException(value + " very long or empty value");
                }
                _name = value;
            }
        }
        public DateTime DateOfBirth
        {
            get 
            {
                return _date_of_birth;
            }
            set 
            {
                if (value.Year < 1900)
                {
                    throw new ArgumentException(
                        " Less than 1900");
                }

                if (value > DateTime.Now)
                {
                    throw new ArgumentException(
                        " Date late than now");
                }
                _date_of_birth = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set 
            {
                if (value.Length > MAXLETTERCOUNT || value.Length == 0)
                {
                    throw new ArgumentException(value + " very long or empty value");
                }
                _email = value;
            }
        }
        public PhoneNumber PhoneNumber { get; set; }

        public string VkId 
        {
            get
            {
                return _vkId;
            }
            set 
            {
                if (value.Length > MAXLETTERCOUNT || value.Length == 0)
                {
                    throw new ArgumentException(value + " very long or empty value");
                }
                _vkId = value;
            }
        }

        public Contact(string name, string surname,
             PhoneNumber phoneNumber, DateTime birthday,
             string email, string vkId)
        {
            this.Surname = surname;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = birthday;
            this.Email = email;
            this.VkId = vkId;
        }

        object ICloneable.Clone()
        {
            return new Contact(this.Name, this.Surname,
               new PhoneNumber(this.PhoneNumber.Number),
               this.DateOfBirth, this.Email, this.VkId);
        }
    }
}
