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
    public partial class MainForm : Form
    {
        private Project _project { get; set; }


        public MainForm()
        {
            InitializeComponent();
            _project = new Project();
            _project = ProjectManager.LoadFromFile();
        }

        private void UpdateListBox()
        {
            ContactsListBox.Items.Clear();
            foreach (var contact in _project.Contacts)
            {
                ContactsListBox.Items.Add(contact);
            }
        }
        /// <summary>
        /// Добавляет контакт с выбранными полями(заглушка по заданию).
        /// </summary>
        private void AddContact()
        {
            var randomNames = new List<string>
            {
                "name", "oleg", "kirill", "shisha"
            };
            var randomSurnames = new List<string>
            {
                "khromov", "pakhomov", "podushkin"
            };
            var randomEmails = new List<string>
            {
                "khromov@mail.ru", "pakhomov@mail.ru", "podushkin@mail.ru"
            };
            _project.Contacts.Add(new Contact(
                randomNames[new Random().Next(randomNames.Count)],
                randomSurnames[new Random().Next(randomSurnames.Count)],
                new PhoneNumber(new Random().Next()),
                DateTime.Now,
                randomEmails[new Random().Next(randomEmails.Count)],
                new Random().Next().ToString()
                ));
        }
        /// <summary>
        /// Удаляет выбранный контакт по индексу.
        /// </summary>
        /// <param name="index"></param>
        private void RemoveContact(int index)
        {
            if (index == -1 || ContactsListBox.Items.Count == 0)
            {
                return;
            }
            var result = MessageBox.Show($"Do you really want to remove {_project.Contacts[index].Surname}?",
                "Warning", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            _project.Contacts.RemoveAt(index);
        }
        /// <summary>
        /// Обновляет выбранный контакт по индексу.
        /// </summary>
        /// <param name="index"></param>
        private void UpdateSelectedContact(int index)
        {
            if (index == -1)
            {
                ClearSelectedContact();
                return;
            }

            var contact = _project.Contacts[index];
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            PhoneTextBox.Text = contact.PhoneNumber.Number.ToString();
            BirthdayDateTimePicker.Value = contact.DateOfBirth;
            VkTextBox.Text = contact.VkId;
            EmailTextBox.Text = contact.Email;
        }
        /// <summary>
        /// Удаляет выбранный контакт.
        /// </summary>
        private void ClearSelectedContact()
        {
            SurnameTextBox.Text = String.Empty;
            NameTextBox.Text = String.Empty;
            PhoneTextBox.Text = String.Empty;
            BirthdayDateTimePicker.Value = DateTime.MinValue;
            VkTextBox.Text = String.Empty;
            EmailTextBox.Text = String.Empty;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            UpdateSelectedContact(ContactsListBox.SelectedIndex);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var form = new ContactForm();
            form.ShowDialog();
        }

        private void VkLabel_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Are you sure want to exit?", "Warning", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void AddButton_Click_1(object sender, EventArgs e)
        {
            AddContact();
            UpdateListBox();
        }

        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
            UpdateListBox();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveContact(ContactsListBox.SelectedIndex);
            UpdateListBox();
        }

        private void removeContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveContact(ContactsListBox.SelectedIndex);
            UpdateListBox();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
