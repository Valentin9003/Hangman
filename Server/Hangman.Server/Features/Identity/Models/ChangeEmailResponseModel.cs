using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman.Server.Features.Identity.Models
{
    public class ChangeEmailResponseModel
    {
        public string Token { get; set; }

        public IEnumerable<IdentityError> Error { get; set; }
    }
}
