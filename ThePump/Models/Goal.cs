using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThePump.Models
{
    public class Goal
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You msut Enter the Id")]
        public String FitnessGoal { get; set; }

        [Required(ErrorMessage="You msut Enter your Goal")]

        public long StartingDate { get; set; }
        public long FinishingDate { get; set; }

        public List<AddData> AddData { get; set; }
    }
}
