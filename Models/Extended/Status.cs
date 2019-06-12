using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KickTask.Models
{
    [MetadataType(typeof(StatusMetaData))]
    public partial class Status
    {
    }

    public class StatusMetaData
    {
        [Display(Name = "Status")]
        public string StatusText { get; set; }
    }
}