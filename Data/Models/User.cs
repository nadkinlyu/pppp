using Data.Enums;

namespace Data.Models;

public class User
{
    public long Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Fio { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string PasswordKey { get; set; } = string.Empty;
    public EnumUserRole Role { get; set; } = EnumUserRole.User;

    public EnumUserStatus Status { get; set; } = EnumUserStatus.New;
    public List<MailToken> Tokens { get; set; } = null!;
    public Person Person { get; set; } 
    
    


}