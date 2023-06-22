using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Share.Model
{
	public class JwtTokenModel
	{
		[Description("Jwt Access Token")]
		public string AccessToken { get; set; }
		[Description("In seconds")]
		public int ExpiresIn { get; set; }
		[Description("Token Type, Bearer")]
		public string TokenType { get; set; }

        public DateTime IssueDate { get; set; }
    }
}
