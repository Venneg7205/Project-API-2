using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project_API_2.Models;

public partial class ProkatContext : DbContext
{
    public ProkatContext()
    {
    }

    public ProkatContext(DbContextOptions<ProkatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Автомобили> Автомобилиs { get; set; }

    public virtual DbSet<АвтомобилиВПрокате> АвтомобилиВПрокатеs { get; set; }

    public virtual DbSet<Автопарк> Автопаркs { get; set; }

    public virtual DbSet<Должности> Должностиs { get; set; }

    public virtual DbSet<ДополнительныеУслуги> ДополнительныеУслугиs { get; set; }

    public virtual DbSet<Клиенты> Клиентыs { get; set; }

    public virtual DbSet<МаркиАвтомобилей> МаркиАвтомобилейs { get; set; }

    public virtual DbSet<ОтделКадров> ОтделКадровs { get; set; }

    public virtual DbSet<Прокат> Прокатs { get; set; }

    public virtual DbSet<Сотрудники> Сотрудникиs { get; set; }

    public virtual DbSet<ФильтрАвтоAudi> ФильтрАвтоAudis { get; set; }

    public virtual DbSet<ФильтрАвтоBmw> ФильтрАвтоBmws { get; set; }

    public virtual DbSet<ФильтрАвтоMercedesBenz> ФильтрАвтоMercedesBenzs { get; set; }

    public virtual DbSet<ФильтрАвтоToyotum> ФильтрАвтоToyota { get; set; }

    public virtual DbSet<ФильтрАвтоVolkswagen> ФильтрАвтоVolkswagens { get; set; }

    public virtual DbSet<ФильтрДолжностей> ФильтрДолжностейs { get; set; }

    public virtual DbSet<ФильтрДолжностиАвтомеханик> ФильтрДолжностиАвтомеханикs { get; set; }

    public virtual DbSet<ФильтрДолжностиМенеджерПоПрокату> ФильтрДолжностиМенеджерПоПрокатуs { get; set; }

    public virtual DbSet<ФильтрДолжностиМеханики> ФильтрДолжностиМеханикиs { get; set; }

    public virtual DbSet<ФильтрНеоплаченныхАвто> ФильтрНеоплаченныхАвтоs { get; set; }

    public virtual DbSet<ФильтрОплаченныхАвто> ФильтрОплаченныхАвтоs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=Prokat;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_CI_AS");

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07447F8133");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105344BF13994").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<Автомобили>(entity =>
        {
            entity.HasKey(e => e.IdАвтомобиля).HasName("PK__Автомоби__F14F5D3F52DF69A1");

            entity.ToTable("Автомобили");

            entity.Property(e => e.IdАвтомобиля)
                .ValueGeneratedNever()
                .HasColumnName("ID_Автомобиля");
            entity.Property(e => e.IdМарки).HasColumnName("ID_Марки");
            entity.Property(e => e.IdМеханика).HasColumnName("ID_Механика");
            entity.Property(e => e.ГосНомер)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПоследнегоТо)
                .HasColumnType("date")
                .HasColumnName("ДатаПоследнегоТО");
            entity.Property(e => e.НомерДвигателя)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.НомерКузова)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Особенности)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ОтметкаОвозврате).HasColumnName("ОтметкаОВозврате");
            entity.Property(e => e.Цена).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ЦенаПроката).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<АвтомобилиВПрокате>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Автомобили в прокате");

            entity.Property(e => e.ГосНомер)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПроката).HasColumnType("date");
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.СотрудникиФио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("СотрудникиФИО");
            entity.Property(e => e.ТехническиеХарактеристики)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Услуги1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Услуги2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Услуги3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<Автопарк>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Автопарк");

            entity.Property(e => e.ГосНомер)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<Должности>(entity =>
        {
            entity.HasKey(e => e.IdДолжности).HasName("PK__Должност__9A158B47AA3CA4B4");

            entity.ToTable("Должности");

            entity.Property(e => e.IdДолжности)
                .ValueGeneratedNever()
                .HasColumnName("ID_Должности");
            entity.Property(e => e.Зарплата).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Обязанности)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Требования)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ДополнительныеУслуги>(entity =>
        {
            entity.HasKey(e => e.IdУслуги).HasName("PK__Дополнит__C62AED9B707ECB1C");

            entity.ToTable("ДополнительныеУслуги");

            entity.Property(e => e.IdУслуги)
                .ValueGeneratedNever()
                .HasColumnName("ID_Услуги");
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Описание)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Цена).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Клиенты>(entity =>
        {
            entity.HasKey(e => e.IdКлиента).HasName("PK__Клиенты__F73001119A2E0CC6");

            entity.ToTable("Клиенты");

            entity.Property(e => e.IdКлиента)
                .ValueGeneratedNever()
                .HasColumnName("ID_Клиента");
            entity.Property(e => e.Адрес)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ДатаРождения).HasColumnType("date");
            entity.Property(e => e.ПаспортныеДанные)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<МаркиАвтомобилей>(entity =>
        {
            entity.HasKey(e => e.IdМарки).HasName("PK__МаркиАвт__E6BA2233F2098AF0");

            entity.ToTable("МаркиАвтомобилей");

            entity.Property(e => e.IdМарки)
                .ValueGeneratedNever()
                .HasColumnName("ID_Марки");
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Описание)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ТехническиеХарактеристики)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ОтделКадров>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Отдел кадров");

            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<Прокат>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Прокат");

            entity.Property(e => e.IdАвтомобиля).HasColumnName("ID_Автомобиля");
            entity.Property(e => e.IdКлиента).HasColumnName("ID_Клиента");
            entity.Property(e => e.IdСотрудника).HasColumnName("ID_Сотрудника");
            entity.Property(e => e.IdУслуги1).HasColumnName("ID_Услуги1");
            entity.Property(e => e.IdУслуги2).HasColumnName("ID_Услуги2");
            entity.Property(e => e.IdУслуги3).HasColumnName("ID_Услуги3");
            entity.Property(e => e.ДатаВозврата).HasColumnType("date");
            entity.Property(e => e.ДатаПроката).HasColumnType("date");
            entity.Property(e => e.ЦенаПроката).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Сотрудники>(entity =>
        {
            entity.HasKey(e => e.IdСотрудника).HasName("PK__Сотрудни__F4052FE387835379");

            entity.ToTable("Сотрудники");

            entity.Property(e => e.IdСотрудника)
                .ValueGeneratedNever()
                .HasColumnName("ID_Сотрудника");
            entity.Property(e => e.IdДолжности).HasColumnName("ID_Должности");
            entity.Property(e => e.Адрес)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ПаспортныеДанные)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Паспортные_данные");
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ФильтрАвтоAudi>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр Авто Audi");

            entity.Property(e => e.ГосНомер)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ФильтрАвтоBmw>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр Авто BMW");

            entity.Property(e => e.ГосНомер)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ФильтрАвтоMercedesBenz>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр Авто Mercedes-Benz");

            entity.Property(e => e.ГосНомер)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ФильтрАвтоToyotum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр Авто Toyota");

            entity.Property(e => e.ГосНомер)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ФильтрАвтоVolkswagen>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр Авто Volkswagen");

            entity.Property(e => e.ГосНомер)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ФильтрДолжностей>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр Должностей");

            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ФильтрДолжностиАвтомеханик>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр Должности Автомеханик");

            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ФильтрДолжностиМенеджерПоПрокату>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр Должности Менеджер по прокату");

            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ФильтрДолжностиМеханики>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр Должности Механики");

            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ФильтрНеоплаченныхАвто>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр неоплаченных авто");

            entity.Property(e => e.ГосНомер)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ФильтрОплаченныхАвто>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр оплаченных авто");

            entity.Property(e => e.ГосНомер)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Наименование)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
