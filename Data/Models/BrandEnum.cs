using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("BrandEnum")]
public partial class BrandEnum
{
    [Key]
    [StringLength(50)]
    public string Brand { get; set; } = null!;

    enum BrandBrandEnum
    {
        ElAl,
        AirUsa,
        AirAfrica,
        AirAsia
    }
}