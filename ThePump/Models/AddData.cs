using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThePump.Models
{
    // Use nouns for object names
    public class AddData
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public decimal CurrentBodyWeight { get; set; }

        public decimal RequiredBodyWeight { get; set; }

        public String TypeOfExercise { get; set; }

        public int GoalId { get; set; }

        public Goal Goal { get; set; }
    }
}
