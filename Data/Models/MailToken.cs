namespace Data.Models;


    public class MailToken
    {
        public long Id { get; set; }

        public Guid Key { get; set; }

        public DateTime DateExpire { get; set; }

        public User User { get; set; }

        public long UserId { get; set; }
    }
