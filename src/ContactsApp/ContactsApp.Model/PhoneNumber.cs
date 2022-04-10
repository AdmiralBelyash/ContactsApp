using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
	/// <summary>
	/// Класс содержит номер телефона контакта
	/// </summary>
	public class PhoneNumber
	{
		/// <summary>
		/// Номер телефона
		/// </summary>
		private long _number;
		/// <summary>
		/// Максимальное количетсов цифр в номере
		/// </summary>
		public const int MAXDIGITCOUNT = 11;

		/// <summary>
		/// Устанавливает и возвращает номер
		/// </summary>
		public long Number
		{
			get
			{
				return this._number;
			}
			set
			{
				if (value.ToString().Length > MAXDIGITCOUNT)
				{
					throw new ArgumentException("Номер телефона больше 11 символов");
				}
				this._number = value;
			}
		}

		/// <summary>
		/// Устанавливает номер
		/// </param>
		public PhoneNumber(long number)
		{
			this.Number = number;
		}
	}
}
