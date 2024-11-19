using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KovserHediyyeler.Application.Constants
{
    public class FileConstants
    {
        readonly IHttpContextAccessor _accessor;
        readonly IWebHostEnvironment _env;

        public FileConstants()
        {
        }

        public FileConstants(IHttpContextAccessor accessor, IWebHostEnvironment env)
        {
            _accessor = accessor;
            _env = env;
        }

        public string root
        {
            get
            {
                return _env.WebRootPath;
            }
        }
        public HostString host
        {
            get
            {
                return _accessor.HttpContext.Request.Host;
            }
        }

        public string scheme
        {
            get
            {
                return _accessor.HttpContext.Request.Scheme;
            }
        }
    }
}
