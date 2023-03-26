using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("Logger")]
public partial class Logger
{
    [Key]
    public int Id { get; set; }

    public DateTime? InAirplane { get; set; }

    public DateTime? OutAirplane { get; set; }
}