using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KickTask.Models
{
    [MetadataType(typeof(TaskMetaData))]
    public partial class Task
    {
        
    }

    public class TaskMetaData
    {  
        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Text")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Text is required")]
        public string Text { get; set; }

        [Display(Name = "DueDate")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "DueDate is required")]
        [DataType(DataType.Date)]
        public System.DateTime Bis { get; set; }


        public virtual ICollection<TaskAccount> TaskAccount { get; set; }

        [Display(Name = "Tasksteps")]
        public virtual ICollection<Taskstep> Taskstep { get; set; }
    }
}