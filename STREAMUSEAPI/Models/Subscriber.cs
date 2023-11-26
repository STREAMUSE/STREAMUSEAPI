using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace STREAMUSEAPI.Models;

[Table("Subscriber")]
public partial class Subscriber
{
    [Key]
    public long Id { get; set; }

    [Column("Subscriber")]
    public long Subscriber1 { get; set; }

    public long User { get; set; }

    [ForeignKey("Subscriber1")]
    [InverseProperty("SubscriberSubscriber1Navigations")]
    public virtual User Subscriber1Navigation { get; set; } = null!;

    [ForeignKey("User")]
    [InverseProperty("SubscriberUserNavigations")]
    public virtual User UserNavigation { get; set; } = null!;
}
