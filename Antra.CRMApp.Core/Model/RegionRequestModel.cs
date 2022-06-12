using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.CRMApp.Core.Model
{
    public class RegionRequestModel
    {
        public int Id { get; set; }
        [Required, Column(TypeName = "varchar"), MaxLength(20)]
        public string Name { get; set; }
    }
}
