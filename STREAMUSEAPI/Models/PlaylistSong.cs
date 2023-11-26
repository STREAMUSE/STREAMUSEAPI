using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace STREAMUSEAPI.Models;

[Table("PlaylistSong")]
public partial class PlaylistSong
{
    [Key]
    public long Id { get; set; }

    public long Playlist { get; set; }

    public long Song { get; set; }

    [ForeignKey("Playlist")]
    [InverseProperty("PlaylistSongs")]
    public virtual Playlist PlaylistNavigation { get; set; } = null!;

    [ForeignKey("Song")]
    [InverseProperty("PlaylistSongs")]
    public virtual Song SongNavigation { get; set; } = null!;
}
