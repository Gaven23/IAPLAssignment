using System;
using System.Collections.Generic;

#nullable disable

namespace IAPL_Assignment.Data
{
    public partial class Unit
    {
        public Unit()
        {
            Measurements = new HashSet<Measurement>();
        }

        public int Unitid { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<Measurement> Measurements { get; set; }
    }
}
