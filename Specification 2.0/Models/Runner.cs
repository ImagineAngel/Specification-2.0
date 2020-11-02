using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification_2._0.Models
{
    public class Runner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }
        
        public int Age { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Ranked { get; set; }

        public override string ToString()
        {
            return Name + " " + Surname + " " + ":" + " " + Ranked.ToString() + " место";
        }
    }
}
