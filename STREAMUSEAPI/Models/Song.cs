using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace STREAMUSEAPI.Models;

[Table("Song")]
public partial class Song
{
    [Key]
    public long Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Precision(0)]
    public TimeSpan Duration { get; set; }

    public int Type { get; set; }

    public int Genre { get; set; }

    public long Image { get; set; }

    [StringLength(50)]
    public string Path { get; set; } = null!;

    [Column("listenings")]
    public long Listenings { get; set; }

    [InverseProperty("SongNavigation")]
    public virtual ICollection<ArtistSong> ArtistSongs { get; set; } = new List<ArtistSong>();

    [ForeignKey("Genre")]
    [InverseProperty("Songs")]
    public virtual Genre GenreNavigation { get; set; } = null!;

    [ForeignKey("Image")]
    [InverseProperty("Songs")]
    public virtual Image ImageNavigation { get; set; } = null!;

    [InverseProperty("SongNavigation")]
    public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();

    [InverseProperty("SongNavigation")]
    public virtual ICollection<SongAlbum> SongAlbums { get; set; } = new List<SongAlbum>();

    [ForeignKey("Type")]
    [InverseProperty("Songs")]
    public virtual SongType TypeNavigation { get; set; } = null!;
}
