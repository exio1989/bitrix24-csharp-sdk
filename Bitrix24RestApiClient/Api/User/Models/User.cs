#nullable enable
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bitrix24ApiClient.Api.User.Models
{
	/// <summary>
	/// Пользователи
	/// </summary>
	public class User
	{
		/// <summary>
		/// ID
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.Id)]
		public int? Id { get; set; }

		/// <summary>
		/// Активность
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.Active)]
		public string? Active { get; set; }

		/// <summary>
		/// E-Mail
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.Email)]
		public string? Email { get; set; }

		/// <summary>
		/// Последняя авторизация
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.LastLogin)]
		public string? LastLogin { get; set; }

		/// <summary>
		/// Дата регистрации
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.DateRegister)]
		public string? DateRegister { get; set; }

		/// <summary>
		/// IS_ONLINE
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.IsOnline)]
		public string? IsOnline { get; set; }

		/// <summary>
		/// Имя
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.Name)]
		public string? Name { get; set; }

		/// <summary>
		/// Фамилия
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.LastName)]
		public string? LastName { get; set; }

		/// <summary>
		/// Отчество
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.SecondName)]
		public string? SecondName { get; set; }

		/// <summary>
		/// Пол
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.PersonalGender)]
		public string? PersonalGender { get; set; }

		/// <summary>
		/// Профессия
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.PersonalProfession)]
		public string? PersonalProfession { get; set; }

		/// <summary>
		/// Домашняя страничка
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.PersonalWww)]
		public string? PersonalWww { get; set; }

		/// <summary>
		/// Дата рождения
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.PersonalBirthday)]
		public string? PersonalBirthday { get; set; }

		/// <summary>
		/// Фотография
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.PersonalPhoto)]
		public string? PersonalPhoto { get; set; }

		/// <summary>
		/// ICQ
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.PersonalIcq)]
		public string? PersonalIcq { get; set; }

		/// <summary>
		/// Личный телефон
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.PersonalPhone)]
		public string? PersonalPhone { get; set; }

		/// <summary>
		/// Факс
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.PersonalFax)]
		public string? PersonalFax { get; set; }

		/// <summary>
		/// Личный мобильный
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.PersonalMobile)]
		public string? PersonalMobile { get; set; }

		/// <summary>
		/// Пейджер
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.PersonalPager)]
		public string? PersonalPager { get; set; }

		/// <summary>
		/// Улица проживания
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.PersonalStreet)]
		public string? PersonalStreet { get; set; }

		/// <summary>
		/// Город проживания
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.PersonalCity)]
		public string? PersonalCity { get; set; }

		/// <summary>
		/// Область / край
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.PersonalState)]
		public string? PersonalState { get; set; }

		/// <summary>
		/// Почтовый индекс
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.PersonalZip)]
		public string? PersonalZip { get; set; }

		/// <summary>
		/// Страна
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.PersonalCountry)]
		public string? PersonalCountry { get; set; }

		/// <summary>
		/// TIME_ZONE_OFFSET
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.TimeZoneOffset)]
		public string? TimeZoneOffset { get; set; }

		/// <summary>
		/// Компания
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.WorkCompany)]
		public string? WorkCompany { get; set; }

		/// <summary>
		/// Должность
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.WorkPosition)]
		public string? WorkPosition { get; set; }

		/// <summary>
		/// Телефон компании
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.WorkPhone)]
		public string? WorkPhone { get; set; }

		/// <summary>
		/// Подразделения
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.UfDepartment)]
		public List<int> UfDepartment { get; set; }

		/// <summary>
		/// Интересы
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.UfInterests)]
		public string? UfInterests { get; set; }

		/// <summary>
		/// Навыки
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.UfSkills)]
		public string? UfSkills { get; set; }

		/// <summary>
		/// Другие сайты
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.UfWebSites)]
		public string? UfWebSites { get; set; }

		/// <summary>
		/// Xing
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.UfXing)]
		public string? UfXing { get; set; }

		/// <summary>
		/// LinkedIn
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.UfLinkedin)]
		public string? UfLinkedin { get; set; }

		/// <summary>
		/// Facebook
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.UfFacebook)]
		public string? UfFacebook { get; set; }

		/// <summary>
		/// Twitter
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.UfTwitter)]
		public string? UfTwitter { get; set; }

		/// <summary>
		/// Логин Skype
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.UfSkype)]
		public string? UfSkype { get; set; }

		/// <summary>
		/// Район
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.UfDistrict)]
		public string? UfDistrict { get; set; }

		/// <summary>
		/// Внутренний телефон
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.UfPhoneInner)]
		public string? UfPhoneInner { get; set; }

		/// <summary>
		/// USER_TYPE
		/// Тип: string
		/// </summary>
		[JsonProperty(UserFields.UserType)]
		public string? UserType { get; set; }

	}
}
