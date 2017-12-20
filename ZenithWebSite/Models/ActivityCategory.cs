using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ass2.Models
{
    public partial class ActivityCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public int ActivityCategoryId { get; set; }


        [Required(ErrorMessage = "Activity Description is required.")]
        [Display(Name = "Activity Description")]
        public string ActivityDescription { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreationDate { get; set; }

        //public virtual List<Event> Events { get; set; }
    }
}
