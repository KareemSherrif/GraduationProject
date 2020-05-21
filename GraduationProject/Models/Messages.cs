using System;
using System.Collections.Generic;

namespace GraduationProject.Models
{
    public partial class Messages
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ChatId { get; set; }

        public virtual Chats Chat { get; set; }
    }
}
