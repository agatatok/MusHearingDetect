using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusHearingDetect.Models.UserProfile
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public int UserAge { get; set; }

        public bool Answer1 { get; set; }
        public bool Answer2 { get; set; }
        public bool Answer3 { get; set; }
        public bool Answer4 { get; set; }
        public bool Answer5 { get; set; }
        public bool Answer6 { get; set; }
        public bool Answer7 { get; set; }
        public bool Answer8 { get; set; }
        public bool Answer9 { get; set; }
        public bool Answer10 { get; set; }
        public bool Answer11 { get; set; }
        public bool Answer12 { get; set; }
        public bool Answer13 { get; set; }
        public bool Answer14 { get; set; }
        public bool Answer15 { get; set; }
        public bool Answer16 { get; set; }
        public bool Answer17 { get; set; }
        public bool Answer18 { get; set; }
        public bool Answer19 { get; set; }
        public bool Answer20 { get; set; }

        public int Result { get; set; }
    }

}
