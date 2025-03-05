using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce.Domain
{
    public class Category : BaseDomainModel
    {
        [Column(TypeName = "NVARCHAR(100)")]
        public string? Name { get; set; }
    }
}