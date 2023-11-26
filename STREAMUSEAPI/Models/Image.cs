using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace STREAMUSEAPI.Models;

[Table("Image")]
public partial class Image
{
    [Key]
    public long Id { get; set; }

    [StringLength(50)]
    public string Path { get; set; } = null!;

    [InverseProperty("ImageNavigation")]
    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

    [InverseProperty("ImageNavigation")]
    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();

    [InverseProperty("ImageNavigation")]
    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();

    [InverseProperty("ImageNavigation")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
