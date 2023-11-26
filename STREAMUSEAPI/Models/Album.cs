using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace STREAMUSEAPI.Models;

[Table("Album")]
public partial class Album
{
    [Key]
    public long Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public long SongCount { get; set; }

    public TimeSpan Duration { get; set; }

    public long Image { get; set; }

    public int Type { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [InverseProperty("AlbumNavigation")]
    public virtual ICollection<AlbumUser> AlbumUsers { get; set; } = new List<AlbumUser>();

    [ForeignKey("Image")]
    [InverseProperty("Albums")]
    public virtual Image ImageNavigation { get; set; } = null!;

    [InverseProperty("AlbumNavigation")]
    public virtual ICollection<SongAlbum> SongAlbums { get; set; } = new List<SongAlbum>();

    [ForeignKey("Type")]
    [InverseProperty("Albums")]
    public virtual AlbumType TypeNavigation { get; set; } = null!;
}
