using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace ass2.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public partial class Event
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public int EventId { get; set; }

        [ValidDate]
        [Required(ErrorMessage = "Event start date is required.")]
        [Display(Name = "Event From")]
        public DateTime EventFromDateTime { get; set; }

        [Required(ErrorMessage = "Event end date is required.")]
        [Display(Name = "Event To")]
        public DateTime EventToDateTime { get; set; }

        [ScaffoldColumn(false)]
        public String EnteredByUsername { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [ForeignKey("ActivityCategoryId")]
        [Display(Name = "Activity Description")]
        public virtual ActivityCategory ActivityCategory { get; set; }

        public virtual int ActivityCategoryId { get; set; }

    }
}