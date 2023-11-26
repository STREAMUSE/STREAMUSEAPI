using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace STREAMUSEAPI.Models;

[Table("Genre")]
public partial class Genre
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    public string Name { get; set; } = null!;

    [InverseProperty("GenreNavigation")]
    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
