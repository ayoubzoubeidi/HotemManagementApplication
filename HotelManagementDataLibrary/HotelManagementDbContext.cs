using HotelManagementDataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementDataLibrary;
public class HotelManagementDbContext : DbContext
{
    public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options) : base(options)
    {
    }

    public DbSet<Guest> Guests { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Personnel> Personnels { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Reservation>(er =>
        {
            er.Property(reservation => reservation.Status).HasConversion(
                status => status.ToString(),
                status => (ReservationStatus)Enum.Parse(typeof(ReservationStatus), status)
                );

            er.Ignore(reservation => reservation.Id)
            .HasKey(reservation => new { reservation.GuestId, reservation.RoomId, reservation.PaymentId });

            er.HasOne(reservation => reservation.Guest)
            .WithMany(guest => guest.Reservations)
            .HasForeignKey(reservation => reservation.GuestId);

            er.HasOne(reservation => reservation.Room)
            .WithMany(room => room.Reservations)
            .HasForeignKey(reservation => reservation.RoomId);
            
            er.HasOne(reservation => reservation.Payment)
            .WithMany(payment => payment.Reservations)
            .HasForeignKey(reservation => reservation.PaymentId);
        });

        builder.Entity<Guest>(eg =>
        {
            eg.Property(guest => guest.FirstName).HasColumnType("varchar(20)");
            eg.Property(guest => guest.LastName).HasColumnType("varchar(20)");
            eg.Property(guest => guest.CIN).HasColumnType("varchar(20)");
            eg.Property(guest => guest.Email).HasColumnType("varchar(50)");
        });

        builder.Entity<Room>(
            er =>
            {
                er.HasOne(room => room.RoomType)
                .WithMany(roomType => roomType.Rooms)
                .HasForeignKey(room => room.RoomTypeId);

                er.Property(room => room.Label).HasColumnType("varchar(20)");
                er.Property(room => room.Price).HasPrecision(18, 2);
            });

        builder.Entity<Personnel>(ep =>
        {
            ep.Property(personnel => personnel.FirstName).HasColumnType("varchar(20)");
            ep.Property(personnel => personnel.LastName).HasColumnType("varchar(20)");
            ep.Property(personnel => personnel.CIN).HasColumnType("varchar(20)");
            ep.Property(personnel => personnel.Email).HasColumnType("varchar(50)");
            ep.Property(personnel => personnel.JobDescirption).HasColumnType("varchar(50)");
            ep.Property(personnel => personnel.Salary).HasPrecision(18, 2);
        });

        builder.Entity<Payment>(ep =>
        {
            ep.Property(payment => payment.TotalPaid).HasPrecision(18, 2);
        });

        builder.Ignore<BaseModel>();

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (entityType.ClrType.IsSubclassOf(typeof(BaseModel)))
            {
                entityType.FindProperty("CreatedOn").SetDefaultValueSql("getdate()");
                entityType.FindProperty("CreatedOn").ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;

                entityType.FindProperty("UpdatedOn").SetDefaultValueSql("getdate()");
                entityType.FindProperty("UpdatedOn").ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAddOrUpdate;
            }
        }

    }

}
