using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("Flight")]
public partial class Flight
{
    [Key]
    public int FlId { get; set; }
    
    public int? Number { get; set; }

    [StringLength(50)]
    public  string? SerialNumber { get; set; }

    public int? PassengersCount { get; set; }

    [Column("isLanding")]
    public bool IsLanding { get; set; }
    
    [NotMapped]
    public bool IsDeparture { get; set; }

    public int? TerId { get; set; }

    [ForeignKey("TerId")]
    [InverseProperty("Flights")]
    public virtual Terminal? Ter { get; set; }

    private readonly int number = 0;
    public Flight()
    {
        TerId = ++number;
        Ter = new Terminal();
    }

    public void NextTerminal(AirplaneDB data)
    {
        if (Ter != null)
        {
            Ter!.IsFree = true;
            Ter.NextTerminal(this, data);
        }
    }

    public static implicit operator Flight(List<Flight> v)
    {
        throw new NotImplementedException();
    }
}