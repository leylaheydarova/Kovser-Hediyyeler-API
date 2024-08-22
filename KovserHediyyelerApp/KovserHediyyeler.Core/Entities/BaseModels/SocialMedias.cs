using KovserHediyyeler.Core.Entities.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Core.Entities.BaseModels
{
    public class SocialMedias:BaseEntity
    {
        public string Instagram {  get; set; }
        public string TikTok {  get; set; }
        public string? Facebook {  get; set; }
        public string? YouTube {  get; set; }

    }
}
