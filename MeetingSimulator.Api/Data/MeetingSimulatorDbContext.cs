using MeetingSimulator.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MeetingSimulator.Api.Data
{
    public class MeetingSimulatorDbContext : DbContext
    {
        public DbSet<MemberEntity> Members { get; set; }
        public DbSet<MeetingEntity> Meetings { get; set; }
        public DbSet<MemberMeetingEntity> MemberMeetings { get; set; }

        public MeetingSimulatorDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberMeetingEntity>()
                .HasKey(t => new { t.MemberId, t.MeetingId });

            modelBuilder.Entity<MemberMeetingEntity>()
                .HasOne(sc => sc.Member)
                .WithMany(s => s.MemberMeetings)
                .HasForeignKey(sc => sc.MemberId);

            modelBuilder.Entity<MemberMeetingEntity>()
                .HasOne(sc => sc.Meeting)
                .WithMany(c => c.MemberMeetings)
                .HasForeignKey(sc => sc.MeetingId);

            modelBuilder.Entity<MemberEntity>().HasData(
            new MemberEntity[]
            {
            new MemberEntity {Id = 1, Surname = "Менделеев", Name = "Дмитрий", Mail = "Mendeleev@mail.ru" },
            new MemberEntity {Id = 2, Surname = "Циолковский", Name = "Константин", Mail = "Tsiolkovsky@yandex.ru" },
            new MemberEntity {Id = 3, Surname = "Пирогов", Name = "Николай", Mail = "Pirogov@gmail.com" },
            new MemberEntity {Id = 4, Surname = "Королёв", Name = "Сергей", Mail = "Korolev@rambler.ru" }
            });

            modelBuilder.Entity<MeetingEntity>().HasData(
            new MeetingEntity[]
            {
             new MeetingEntity {Id = 1, Name = "«Современные научные исследования: актуальные вопросы, достижения и инновации»", 
                 Place = "Невский 104", DateTimeMeeting = DateTime.Now },
             new MeetingEntity {Id = 2, Name = "«Научно-практические исследования: прикладные науки»", 
                 Place = "Пушкинская 5", DateTimeMeeting = DateTime.Now },
             new MeetingEntity {Id = 3, Name = "«Цифровизация образования: история, тенденции и перспективы DETP 2020»", 
                 Place = "Тютчево 9", DateTimeMeeting = DateTime.Now },
            });

            modelBuilder.Entity<MemberMeetingEntity>().HasData(
            new MemberMeetingEntity[]
            {
                new MemberMeetingEntity { MeetingId = 1, MemberId = 1 },
                new MemberMeetingEntity { MeetingId = 1, MemberId = 2 },
                new MemberMeetingEntity { MeetingId = 1, MemberId = 3 },
                new MemberMeetingEntity { MeetingId = 1, MemberId = 4 },
                new MemberMeetingEntity { MeetingId = 2, MemberId = 1 },
                new MemberMeetingEntity { MeetingId = 2, MemberId = 3 },
                new MemberMeetingEntity { MeetingId = 2, MemberId = 4 },
                new MemberMeetingEntity { MeetingId = 3, MemberId = 2 }
            });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-PS4FLU8;Database=MemberMeetingTestDb;Trusted_Connection=True;");
        }
    }
}
