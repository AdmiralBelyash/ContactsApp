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
        private DateTime _birthday;

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
                    throw new ArgumentException(value + "слишком большое или пустое значение");
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
                    throw new ArgumentException(value + "слишком большое или пустое значение");
                }
                _name = value;
            }
        }
        public DateTime Birthday
        {
            get 
            {
                return _birthday;
            }
            set 
            {
                if (value.Year < 1900)
                {
                    throw new ArgumentException(
                        "Год меньше чем 1900");
                }

                if (value > DateTime.Now)
                {
                    throw new ArgumentException(
                        "Дата позже чем сегодня");
                }
                _birthday = value;
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
                    throw new ArgumentException(value + "слишком большое или пустое значение");
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
                    throw new ArgumentException(value + "слишком большое или пустое значение");
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
            this.Birthday = birthday;
            this.Email = email;
            this.VkId = vkId;
        }

        object ICloneable.Clone()
        {
            return new Contact(this.Name, this.Surname,
               new PhoneNumber(this.PhoneNumber.Number),
               this.Birthday, this.Email, this.VkId);
        }
    }
}
