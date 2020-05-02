using Hangman.Server.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hangman.Server.Features
{
    public class ImageController : ApiController
    {
        public ImageController()
        {
        }
       
        public async Task<byte[]> GetVictimPicture()
        {
            return new byte[0];
        }
    }
}
