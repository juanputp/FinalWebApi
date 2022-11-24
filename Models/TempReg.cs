using System;
using System.Collections.Generic;

namespace FinalWebApi.Models
{
    public partial class TemperatureRegs
    {
        public int Id { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public double? Temperatura { get; set; }
        public double? HumedadRelativa { get; set; }
        public string? Identificacion { get; set; }
        public string? Email { get; set; }
    }
}
