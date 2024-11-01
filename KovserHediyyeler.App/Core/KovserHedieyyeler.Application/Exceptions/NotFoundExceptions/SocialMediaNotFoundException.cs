using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.Exceptions.NotFoundExceptions
{
    public class SocialMediaNotFoundException : BaseException
    {
        public SocialMediaNotFoundException():base("Sosyal Media hesabı tapılmadı!")
        {
        }

        public SocialMediaNotFoundException(string message) : base(message)
        {
        }
    }
}
