using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Repository.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assinatura> Assinaturas { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<CursoCategoria> CursoCategorias { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Transacao> Transacoes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Assinatura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Assinatura");

            entity.HasIndex(e => e.CursoId, "CursoId");

            entity.HasIndex(e => e.UsuarioId, "UsuarioId");

            entity.Property(e => e.Ativa)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.DataFim).HasColumnType("datetime");
            entity.Property(e => e.DataInicio)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.RenovacaoAutomatica)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)");

            entity.HasOne(d => d.Curso).WithMany(p => p.Assinaturas)
                .HasForeignKey(d => d.CursoId)
                .HasConstraintName("Assinatura_ibfk_1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Assinaturas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("Assinatura_ibfk_2");

            entity.HasOne(d => d.Transacao).WithOne().HasForeignKey<Assinatura>(d => d.TransacaoId);

        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Categoria");

            entity.HasIndex(e => e.Nome, "Nome").IsUnique();

            entity.Property(e => e.Nome).HasMaxLength(50);
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Curso");

            entity.Property(e => e.Autor).HasMaxLength(50);
            entity.Property(e => e.Descricao).HasMaxLength(500);
            entity.Property(e => e.Duracao).HasColumnType("int(11)");
            entity.Property(e => e.Imagem).HasMaxLength(200);
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Preco).HasPrecision(10, 2);
        });

        modelBuilder.Entity<CursoCategoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CategoriaId, "CategoriaId");

            entity.HasIndex(e => e.CursoId, "CursoId");

            entity.ToTable("CursoCategoria");

            entity.HasOne(d => d.Categoria).WithMany(p => p.CursoCategoria)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("CursoCategoria_ibfk_2");

            entity.HasOne(d => d.Curso).WithMany(p => p.CursoCategoria)
                .HasForeignKey(d => d.CursoId)
                .HasConstraintName("CursoCategoria_ibfk_1");
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Endereco");

            entity.HasIndex(e => e.UsuarioId, "UsuarioId");

            entity.Property(e => e.Bairro).HasMaxLength(50);
            entity.Property(e => e.Cep)
                .HasMaxLength(10)
                .HasColumnName("CEP");
            entity.Property(e => e.Cidade).HasMaxLength(50);
            entity.Property(e => e.Complemento).HasMaxLength(50);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Numero).HasMaxLength(20);
            entity.Property(e => e.Principal)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.Rua).HasMaxLength(100);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Enderecos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("Endereco_ibfk_1");
        });

        modelBuilder.Entity<Transacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Transacao");

            entity.HasIndex(e => e.TokenPagamento, "TokenPagamento").IsUnique();

            entity.Property(e => e.Data)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.MetodoPagamento).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TokenPagamento).HasMaxLength(100);
            entity.Property(e => e.Valor).HasPrecision(10, 2);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.Senha).HasMaxLength(100);
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
}
