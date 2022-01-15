using System;
using System.Collections.Generic;

#nullable disable

namespace IAPL_Assignment.Data
{
    public partial class Measurement
    {
        public int Measurementid { get; set; }
        public int Unitid { get; set; }
        public decimal Meter { get; set; }
        public decimal Kilometer { get; set; }
        public decimal Kelvin { get; set; }
        public decimal Fahrenherint { get; set; }
        public decimal Hectare { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
