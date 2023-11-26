using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace STREAMUSEAPI.Models;

public partial class STREAMUSEDbContext : DbContext
{
    public STREAMUSEDbContext()
    {
    }

    public STREAMUSEDbContext(DbContextOptions<STREAMUSEDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<AlbumType> AlbumTypes { get; set; }

    public virtual DbSet<AlbumUser> AlbumUsers { get; set; }

    public virtual DbSet<ArtistSong> ArtistSongs { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<PlaylistSong> PlaylistSongs { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<SongAlbum> SongAlbums { get; set; }

    public virtual DbSet<SongType> SongTypes { get; set; }

    public virtual DbSet<Subscriber> Subscribers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:STREAMUSEDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasOne(d => d.ImageNavigation).WithMany(p => p.Albums)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Album_Image");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Albums)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Album_AlbumType");
        });

        modelBuilder.Entity<AlbumUser>(entity =>
        {
            entity.HasOne(d => d.AlbumNavigation).WithMany(p => p.AlbumUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlbumUser_Album");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.AlbumUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlbumUser_User");
        });

        modelBuilder.Entity<ArtistSong>(entity =>
        {
            entity.HasOne(d => d.ArtistNavigation).WithMany(p => p.ArtistSongs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArtistSong_User");

            entity.HasOne(d => d.SongNavigation).WithMany(p => p.ArtistSongs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArtistSong_Song");
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasOne(d => d.ImageNavigation).WithMany(p => p.Playlists).HasConstraintName("FK_Playlist_Image");
        });

        modelBuilder.Entity<PlaylistSong>(entity =>
        {
            entity.HasOne(d => d.PlaylistNavigation).WithMany(p => p.PlaylistSongs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlaylistSong_Playlist");

            entity.HasOne(d => d.SongNavigation).WithMany(p => p.PlaylistSongs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlaylistSong_Song");
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasOne(d => d.GenreNavigation).WithMany(p => p.Songs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Song_Genre");

            entity.HasOne(d => d.ImageNavigation).WithMany(p => p.Songs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Song_Image");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Songs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Song_SongType");
        });

        modelBuilder.Entity<SongAlbum>(entity =>
        {
            entity.HasOne(d => d.AlbumNavigation).WithMany(p => p.SongAlbums)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SongAlbum_Album");

            entity.HasOne(d => d.SongNavigation).WithMany(p => p.SongAlbums)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SongAlbum_Song");
        });

        modelBuilder.Entity<SongType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MusicType");
        });

        modelBuilder.Entity<Subscriber>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Subscriber1Navigation).WithMany(p => p.SubscriberSubscriber1Navigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subscriber_User1");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.SubscriberUserNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subscriber_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasOne(d => d.ImageNavigation).WithMany(p => p.Users).HasConstraintName("FK_User_Image");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
