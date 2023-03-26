using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("Terminal")]
public partial class Terminal
{
    [Key]
    public int TerId { get; set; }

    public int? Number { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? WaitTime { get; set; }

    [Column("isFree")]
    public bool IsFree { get; set; }

    [InverseProperty("Ter")]
    public virtual ICollection<Flight> Flights { get; } = new List<Flight>();
    public virtual void NextTerminal(Flight currentFlight, AirplaneDB data) { }
}