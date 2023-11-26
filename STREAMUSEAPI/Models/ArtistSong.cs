using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace STREAMUSEAPI.Models;

[Table("ArtistSong")]
public partial class ArtistSong
{
    [Key]
    public long Id { get; set; }

    public long Artist { get; set; }

    public long Song { get; set; }

    [ForeignKey("Artist")]
    [InverseProperty("ArtistSongs")]
    public virtual User ArtistNavigation { get; set; } = null!;

    [ForeignKey("Song")]
    [InverseProperty("ArtistSongs")]
    public virtual Song SongNavigation { get; set; } = null!;
}
