using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace STREAMUSEAPI.Models;

[Table("AlbumUser")]
public partial class AlbumUser
{
    [Key]
    public long Id { get; set; }

    public long User { get; set; }

    public long Album { get; set; }

    [ForeignKey("Album")]
    [InverseProperty("AlbumUsers")]
    public virtual Album AlbumNavigation { get; set; } = null!;

    [ForeignKey("User")]
    [InverseProperty("AlbumUsers")]
    public virtual User UserNavigation { get; set; } = null!;
}
