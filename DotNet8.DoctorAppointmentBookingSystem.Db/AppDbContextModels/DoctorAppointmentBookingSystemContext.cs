using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DotNet8.DoctorAppointmentBookingSystem.Db.AppDbContextModels;

public partial class DoctorAppointmentBookingSystemContext : DbContext
{
    public DoctorAppointmentBookingSystemContext()
    {
    }

    public DoctorAppointmentBookingSystemContext(DbContextOptions<DoctorAppointmentBookingSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAppointment> TblAppointments { get; set; }

    public virtual DbSet<TblDoctor> TblDoctors { get; set; }

    public virtual DbSet<TblFeedback> TblFeedbacks { get; set; }

    public virtual DbSet<TblPatient> TblPatients { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAppointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId);

            entity.ToTable("Tbl_Appointment");

            entity.Property(e => e.AppointmentId).HasMaxLength(50);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DoctorId).HasMaxLength(50);
            entity.Property(e => e.PatientId).HasMaxLength(50);
            entity.Property(e => e.Slot).HasMaxLength(50);

            entity.HasOne(d => d.Doctor).WithMany(p => p.TblAppointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_Appointment_Tbl_Doctor");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblAppointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_Appointment_Tbl_Patient");
        });

        modelBuilder.Entity<TblDoctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId);

            entity.ToTable("Tbl_Doctor");

            entity.Property(e => e.DoctorId).HasMaxLength(50);
            entity.Property(e => e.DoctorName).HasMaxLength(50);
            entity.Property(e => e.Speciality).HasMaxLength(50);
        });

        modelBuilder.Entity<TblFeedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId);

            entity.ToTable("Tbl_Feedback");

            entity.Property(e => e.FeedbackId).HasMaxLength(50);
            entity.Property(e => e.Content).HasMaxLength(50);
            entity.Property(e => e.PatientId).HasMaxLength(50);

            entity.HasOne(d => d.Patient).WithMany(p => p.TblFeedbacks)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_Feedback_Tbl_Patient");
        });

        modelBuilder.Entity<TblPatient>(entity =>
        {
            entity.HasKey(e => e.PatientId);

            entity.ToTable("Tbl_Patient");

            entity.Property(e => e.PatientId).HasMaxLength(50);
            entity.Property(e => e.PatientName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
