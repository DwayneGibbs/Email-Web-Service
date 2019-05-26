// Used as the Data Transfer Object 
namespace SMTPapi.Models
{
    public class EmailMessageDto
    {
        public string Subject { get; set; }
        public string HtmlBody { get; set; }
    }
}