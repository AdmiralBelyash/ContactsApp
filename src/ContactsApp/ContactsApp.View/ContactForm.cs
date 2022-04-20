using ContactsApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApp.View
{
    public partial class ContactForm : Form
    {
        private Contact _contact { get; set; }

        private string _nameError { get; set; }

        private string _surnameError { get; set; }

        private string _birthdayError { get; set; }

        private string _phoneNumberError { get; set;}

        private string _emailError { get; set;}

        private string _vkIdError { get; set; }

        public ContactForm()
        {
            InitializeComponent();
            _contact = new Contact("Ivan", "Burakov", new PhoneNumber(123123123), DateTime.Now,
                "chupachups@mail.ru", "123123");
            UpdateForm();
        }
        private void UpdateForm()
        {
            SurnameTextBox.Text = _contact.Surname;
            NameTextBox.Text = _contact.Name;
            BirthdayDateTimePicker.Value = _contact.DateOfBirth;
            PhoneTextBox.Text = _contact.PhoneNumber.Number.ToString();
            EmailTextBox.Text = _contact.Email;
            VkTextBox.Text = _contact.VkId;
        }

        private void CheckFromOnErrors()
        {
            if (_nameError != string.Empty)
            {
                MessageBox.Show(_nameError);
            }
            if (_surnameError != string.Empty)
            {
                MessageBox.Show(_surnameError);
            }
            if (_birthdayError != string.Empty)
            {
                MessageBox.Show(_birthdayError);
            }
            if (_phoneNumberError != string.Empty)
            {
                MessageBox.Show(_phoneNumberError);
            }
            if (_emailError != string.Empty)
            {
                MessageBox.Show(_emailError);
            }
            if (_vkIdError != string.Empty)
            {
                MessageBox.Show(_vkIdError)
            }

        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Surname = SurnameTextBox.Text;
                SurnameTextBox.BackColor = Color.White;
                _surnameError = string.Empty;
            }
            catch (ArgumentException exception)
            {
                SurnameTextBox.BackColor = Color.LightPink;
                _surnameError = exception.Message;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Name = NameTextBox.Text;
                NameTextBox.BackColor = Color.White;
                _nameError = string.Empty;
            }
            catch (ArgumentException exception)
            {
               NameTextBox.BackColor = Color.LightPink;
                _nameError = exception.Message;
            }
        }

        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.DateOfBirth = BirthdayDateTimePicker.Value;
                BirthdayDateTimePicker.BackColor = Color.White;
                _birthdayError = string.Empty;
            }
            catch (ArgumentException exception)
            {
                BirthdayDateTimePicker.BackColor = Color.LightPink;
                _birthdayError = exception.Message;
            }
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.PhoneNumber.Number = Int64.Parse(PhoneTextBox.Text);
               PhoneTextBox.BackColor = Color.White;
                _phoneNumberError = string.Empty;
            }
            catch (ArgumentException exception)
            {
                PhoneTextBox.BackColor = Color.LightPink;
                _phoneNumberError= exception.Message;
            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = Color.White;
                _emailError = string.Empty;
            }
            catch (ArgumentException exception)
            {
               EmailTextBox.BackColor = Color.LightPink;
                _emailError= exception.Message;
            }
        }

        private void VkTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.VkId = VkTextBox.Text;
               VkTextBox.BackColor = Color.White;
                _vkIdError = string.Empty;
            }
            catch (ArgumentException exception)
            {
               VkTextBox.BackColor = Color.LightPink;
                _vkIdError= exception.Message;
            }
        }

        private void PhoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            CheckFromOnErrors();
        }
    }
}
