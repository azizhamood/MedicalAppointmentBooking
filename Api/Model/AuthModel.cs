namespace Api.Model
{
	public class AuthModel
	{
		public string UserName { get; set; }
		public string PasswordHash { get; set; }
		public string Email { get; set; }
		public string Message { get; set; }
		public bool IsAuthenticated { get; set; }
		public List<string> Roles { get; set; }
		public string Token { get; set; }
		public int ExpiresOn { get; set; }
	}
}
