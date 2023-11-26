using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace STREAMUSEAPI.Models;

[Table("User")]
public partial class User
{
    [Key]
    public long Id { get; set; }

    [StringLength(25)]
    public string Username { get; set; } = null!;

    [StringLength(256)]
    public string Password { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    public long? Image { get; set; }

    [InverseProperty("UserNavigation")]
    public virtual ICollection<AlbumUser> AlbumUsers { get; set; } = new List<AlbumUser>();

    [InverseProperty("ArtistNavigation")]
    public virtual ICollection<ArtistSong> ArtistSongs { get; set; } = new List<ArtistSong>();

    [ForeignKey("Image")]
    [InverseProperty("Users")]
    public virtual Image? ImageNavigation { get; set; }

    [InverseProperty("Subscriber1Navigation")]
    public virtual ICollection<Subscriber> SubscriberSubscriber1Navigations { get; set; } = new List<Subscriber>();

    [InverseProperty("UserNavigation")]
    public virtual ICollection<Subscriber> SubscriberUserNavigations { get; set; } = new List<Subscriber>();
}
