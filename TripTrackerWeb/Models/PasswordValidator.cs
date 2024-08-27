namespace TripTrackerWeb.Models
{
	public class PasswordValidator
	{
		public static bool ValidatePassword(string password, out List<string> errors)
		{
			errors = new List<string>();

			if (password.Length < 8)
				errors.Add("Şifre en az 8 karakter uzunluğunda olmalıdır.");

			if (!password.Any(char.IsUpper))
				errors.Add("Şifre en az bir büyük harf içermelidir.");

			if (!password.Any(char.IsLower))
				errors.Add("Şifre en az bir küçük harf içermelidir.");

			if (!password.Any(char.IsDigit))
				errors.Add("Şifre en az bir rakam içermelidir.");

			if (!password.Any(ch => "!@#$%^&*()_+-=[]{}|;':,.<>?/".Contains(ch)))
				errors.Add("Şifre en az bir özel karakter içermelidir.(!@#$%^&*()_+-=[]{}|;':,.<>?/) ");

			return errors.Count == 0;
		}
	}
}
