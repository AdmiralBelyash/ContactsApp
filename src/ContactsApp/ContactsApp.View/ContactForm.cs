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
        /// <summary>
        /// Контакты.
        /// </summary>
        private Contact _contact { get; set; }

        /// <summary>
        /// Ошибка(вернее строка ошибок).
        /// </summary>
        private string _error { get; set; }

        /// <summary>
        /// Есть ли ошибки в данный момент.
        /// </summary>
        private bool _isContainErrors { get; set; }

        /// <summary>
        /// Публичные контакты.
        /// </summary>
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

        /// <summary>
        /// Константное значение цвета.
        /// </summary>
        public Color NormColor = Color.White;

        /// <summary>
        /// Цвет подсветки ошибки.
        /// </summary>
        public Color ErrorColor = Color.LightPink;

        /// <summary>
        /// Конструктор формы контакта.
        /// </summary>
        public ContactForm()
        {
            InitializeComponent();
            _error = String.Empty;
            if (_contact == null)
            {
                _contact = new Contact("Ivan", "Burakov", new PhoneNumber(77777777777), DateTime.Now,
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

        /// <summary>
        /// Если текст фамилии изменился, то проверяем его на корректность.
        /// </summary>
        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Surname = SurnameTextBox.Text;
                SurnameTextBox.BackColor = NormColor;
                _error = String.Empty;
            }
            catch (ArgumentException exception)
            {
                SurnameTextBox.BackColor = ErrorColor;
                _error += $"\n{ exception.Message}";
            }
        }

        /// <summary>
        /// Если текст имени изменился, то проверяем его на корректность.
        /// </summary>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Name = NameTextBox.Text;
                NameTextBox.BackColor = NormColor;
                _error = String.Empty;
            }
            catch (ArgumentException exception)
            {
                NameTextBox.BackColor = ErrorColor;
                _error += $"\n{ exception.Message}";
            }
        }

        /// <summary>
        /// Если значение поля bday изменилось, то проверяем его на корректность.
        /// </summary>
        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.DateOfBirth = BirthdayDateTimePicker.Value;
                BirthdayDateTimePicker.BackColor = NormColor;
                _error = String.Empty;
            }
            catch (ArgumentException exception)
            {
                BirthdayDateTimePicker.BackColor = ErrorColor;
                _error += $"\n{ exception.Message}";
            }
        }

        /// <summary>
        /// Если значение номера изменилось, то проверяем его на корректность.
        /// </summary>
        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.PhoneNumber.Number = Int64.Parse(PhoneTextBox.Text);
                PhoneTextBox.BackColor = NormColor;
                _error = String.Empty;
            }
            catch (ArgumentException exception)
            {
                PhoneTextBox.BackColor = ErrorColor;
                _error += $"\n{ exception.Message}";
            }
        }

        /// <summary>
        /// Если значение емайла изменилось, то проверяем его на корректность.
        /// </summary>
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = NormColor;
                _error = String.Empty;
            }
            catch (ArgumentException exception)
            {
                EmailTextBox.BackColor = ErrorColor;
                _error += $"{Environment.NewLine}{ exception.Message}";
            }
        }

        /// <summary>
        /// Если значение айди вк изменилось, то проверяем его на корректность.
        /// </summary>
        private void VkTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.VkId = VkTextBox.Text;
                VkTextBox.BackColor = NormColor;
                _error = String.Empty;
            }
            catch (ArgumentException exception)
            {
                VkTextBox.BackColor = ErrorColor;
                _error += $"\n{ exception.Message}";
            }
        }

        /// <summary>
        /// Проверяем номер телефона на содержание символов.
        /// </summary>
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
