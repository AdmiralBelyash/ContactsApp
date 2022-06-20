using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    public class Project
    {
		/// <summary>
		/// Список объектов контактов.
		/// </summary>
        public List<Contact> Contacts { set; get; } = new List<Contact>();

		/// <summary>
		/// Возвращает список контактов отсортированных по фамилии.
		/// </summary>
		/// <returns></returns>
		public List<Contact> SortContacts()
		{
			for (int i = 0; i < Contacts.Count; i++)
			{
				if (Contacts[i] == null)
				{
					Contacts.RemoveAt(i);
				}
			}
			return Contacts.OrderBy(
				contact => contact.Surname).ToList<Contact>();
		}
	}
}
