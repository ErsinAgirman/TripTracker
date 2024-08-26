using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripTrackerCore.DTOs
{
	public class UserRegisterDto
	{
		[Required(ErrorMessage = "Lütfen Adınızı giriniz")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Lütfen Soyadınızı giriniz")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "Lütfen Kullanıcı Adınızı giriniz")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Lütfen Mail Adresinizi giriniz")]
		[EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
		public string Mail { get; set; }

		[Required(ErrorMessage = "Lütfen Şifreyi giriniz")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen Şifreyi tekrar giriniz")]
		[Compare("Password", ErrorMessage = "Şifreler uyumlu değil!")]
		public string ConfirmPassword { get; set; }

		public int? AdminId { get; set; }
		public bool isAdmin { get; set; }
		public bool Active { get; set; }
	}
}

