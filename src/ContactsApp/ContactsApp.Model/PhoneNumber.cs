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
				string numberString = value.ToString();
				if (numberString.Length != MAXDIGITCOUNT)
				{
					throw new ArgumentException("Phone number more than 11 symbols");
				}
				if (numberString[0] != '7')
				{
					throw new ArgumentException(
						"The first digit is not 7");
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
