using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    public class Project
    {
        public List<Contact> Contacts { set; get; } = new List<Contact>();

		/// <summary>
		/// Возвращает список контактов отсортированных по фамилии.
		/// </summary>
		/// <returns></returns>
		public void SortContacts()
		{
			for (int i = 0; i < Contacts.Count; i++)
			{
				if (Contacts[i] == null)
				{
					Contacts.RemoveAt(i);
				}
			}
			Contacts = Contacts.OrderBy(
				contact => contact.Surname).ToList<Contact>();
			var contacts = new List<Contact>();
		}
	}
}
