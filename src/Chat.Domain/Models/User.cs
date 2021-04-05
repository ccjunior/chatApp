using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
namespace ChatApp.Domain.Models
{
    public class User : IdentityUser
    {
        public User() : base()
        {
            Chats = new List<ChatUser>();
        }
        public ICollection<ChatUser> Chats { get; set; }
    }
}
