using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application.DTOs.Products.ProductComment
{
    public class ProductCommentGetDto
    {
        public string Id { get; set; }
        public string CommentText { get; set; }
        public string Username { get; set; }
        public int RatingGivenByCustomer { get; set; }
    }
}
