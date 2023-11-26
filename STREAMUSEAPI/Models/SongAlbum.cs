using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace STREAMUSEAPI.Models;

[Table("SongAlbum")]
public partial class SongAlbum
{
    [Key]
    public long Id { get; set; }

    public long Song { get; set; }

    public long Album { get; set; }

    [ForeignKey("Album")]
    [InverseProperty("SongAlbums")]
    public virtual Album AlbumNavigation { get; set; } = null!;

    [ForeignKey("Song")]
    [InverseProperty("SongAlbums")]
    public virtual Song SongNavigation { get; set; } = null!;
}
