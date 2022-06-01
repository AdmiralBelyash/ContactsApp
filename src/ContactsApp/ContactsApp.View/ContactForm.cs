﻿using ContactsApp.Model;
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

        private string _error { get; set; }

        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
                UpdateForm();
            }
        }


        public ContactForm()
        {
            InitializeComponent();
            _error = String.Empty;
            if (_contact == null)
            {
                _contact = new Contact("Ivan", "Burakov", new PhoneNumber(123123123), DateTime.Now,
                                            "chupachups@mail.ru", "123123");
            }
            UpdateForm();
        }
        /// <summary>
        /// Обновление информации контакта на форме.
        /// </summary>
        private void UpdateForm()
        {
            SurnameTextBox.Text = _contact.Surname;
            NameTextBox.Text = _contact.Name;
            BirthdayDateTimePicker.Value = _contact.DateOfBirth;
            PhoneTextBox.Text = _contact.PhoneNumber.Number.ToString();
            EmailTextBox.Text = _contact.Email;
            VkTextBox.Text = _contact.VkId;
        }

        /// <summary>
        /// Проверка формы на ошибки и складывание ошибок в общую строку.
        /// </summary>
        private void CheckFormOnErrors()
        {
            if (_error != string.Empty)
            {
                MessageBox.Show(_error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Surname = SurnameTextBox.Text;
                SurnameTextBox.BackColor = Color.White;
            }
            catch (ArgumentException exception)
            {
                SurnameTextBox.BackColor = Color.LightPink;
                _error += $"\n{ exception.Message}";
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Name = NameTextBox.Text;
                NameTextBox.BackColor = Color.White;
            }
            catch (ArgumentException exception)
            {
                NameTextBox.BackColor = Color.LightPink;
                _error += $"\n{ exception.Message}";
            }
        }

        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.DateOfBirth = BirthdayDateTimePicker.Value;
                BirthdayDateTimePicker.BackColor = Color.White;
            }
            catch (ArgumentException exception)
            {
                BirthdayDateTimePicker.BackColor = Color.LightPink;
                _error += $"\n{ exception.Message}";
            }
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.PhoneNumber.Number = Int64.Parse(PhoneTextBox.Text);
                PhoneTextBox.BackColor = Color.White;
            }
            catch (ArgumentException exception)
            {
                PhoneTextBox.BackColor = Color.LightPink;
                _error += $"\n{ exception.Message}";
            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = Color.White;
            }
            catch (ArgumentException exception)
            {
                EmailTextBox.BackColor = Color.LightPink;
                _error += $"\n{ exception.Message}";
            }
        }

        private void VkTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.VkId = VkTextBox.Text;
                VkTextBox.BackColor = Color.White;
            }
            catch (ArgumentException exception)
            {
                VkTextBox.BackColor = Color.LightPink;
                _error += $"\n{ exception.Message}";
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
            CheckFormOnErrors();
        }
    }
}
