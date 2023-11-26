using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace STREAMUSEAPI.Models;

[Table("AlbumType")]
public partial class AlbumType
{
    [Key]
    public int Id { get; set; }

    [StringLength(5)]
    public string Name { get; set; } = null!;

    [InverseProperty("TypeNavigation")]
    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
