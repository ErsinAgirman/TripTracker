using System.ComponentModel.DataAnnotations;

namespace TripTrackerWeb.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage ="Lütfen Adınızı giriniz")]
		public string Name { get; set; }
		
		[Required(ErrorMessage ="Lütfen Soyadınızı giriniz")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "Lütfen Kullanıcı Adınızı giriniz")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Lütfen Mail Adresinizi giriniz")]
		public string Mail { get; set; }

		[Required(ErrorMessage = "Lütfen Şifreyi giriniz")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen Şifreyi tekrar giriniz")]
		[Compare("Password",ErrorMessage = " Şifreler uyumlu değil! " )]
		public string ConfirmPassword { get; set; }
	}
}
