using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.Models.ViewModels
{
    public class PartCategoryVM
    {
        public PartCategory PartCategory { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> VehicleList { get; set; }
    }
}
