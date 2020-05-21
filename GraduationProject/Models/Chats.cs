using System;
using System.Collections.Generic;

namespace GraduationProject.Models
{
    public partial class Chats
    {
        public Chats()
        {
            Messages = new HashSet<Messages>();
        }

        public int RecipientId { get; set; }
        public int Id { get; set; }
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
    }
}
