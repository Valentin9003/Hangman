using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Server.Data.Models
{
    public class UserWord
    {
        public string UserId {get; set; }

        public User User { get; set; }

        public string WordId { get; set; }

        public Word Word { get; set; }
    }
}
