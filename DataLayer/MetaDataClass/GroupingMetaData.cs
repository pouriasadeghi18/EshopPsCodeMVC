using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class GroupingMetaData
    {
        [Key]
        public int GroupingID { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید.")]
        [MaxLength(250)]
        public string GroupingName { get; set; }

        [Display(Name = "عنوان زیر گروه")]
        public Nullable<int> Subgroup { get; set; }
    }
   
    [MetadataType(typeof(GroupingMetaData))]
    public partial class Grouping
    {

    }
}
