using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Domain.Models.BaseModels;
using KovserHediyyeler.Domain.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace KovserHediyyeler.Domain.Models
{
    public class ProductComment : BaseEntity
    {
        public string CommentText { get; set; }
        public Rating? RatingGivenByUser { get; set; }

        //Relationship
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(Customer))]
        public string CustomerID { get; set; }
        public WebUser Customer { get; set; }
    }
}


