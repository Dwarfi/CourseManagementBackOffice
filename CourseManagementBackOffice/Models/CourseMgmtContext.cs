using Microsoft.EntityFrameworkCore;

namespace CourseManagementApi.Models;

public partial class CourseMgmtContext : DbContext
{
    public CourseMgmtContext()
    { }

    public CourseMgmtContext(DbContextOptions<CourseMgmtContext> options) : base(options)
    { }

    public virtual DbSet<User> AppUsers { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamQuestion> ExamQuestions { get; set; }

    public virtual DbSet<ExamReference> ExamReferences { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Media> Media { get; set; }

    public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; }

    public virtual DbSet<UserCourse> UserCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
        .UseSqlServer("Server=SOMBRA-L420\\SQLEXPRESS; Database=CourseMgmt; Trusted_Connection=true; TrustServerCertificate=true; User Id=mgmtsys; Password=admin-password");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__app_user__3214EC072E6107FE");

            entity.ToTable("app_user");

            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(500)
                .HasColumnName("password_hash");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__course__3213E83FBFE701D9");

            entity.ToTable("course");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Instructor).HasColumnName("instructor");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updated_date");
            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(255);

            entity.HasOne(d => d.InstructorNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.Instructor)
                .HasConstraintName("FK__course__instruct__619B8048");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__exam__3213E83FF2DED78E");

            entity.ToTable("exam");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.MaxGrade).HasColumnName("max_grade");
            entity.Property(e => e.MinGrade).HasColumnName("min_grade");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updated_date");

            entity.HasOne(d => d.Course).WithMany(p => p.Exams)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__exam__course_id__60A75C0F");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.Exams)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__exam__updated_by__5CD6CB2B");
        });

        modelBuilder.Entity<ExamQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__exam_que__3213E83F674D7564");

            entity.ToTable("exam_question");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer)
                .HasMaxLength(500)
                .HasColumnName("answer");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ExamId).HasColumnName("exam_id");
            entity.Property(e => e.Text)
                .HasMaxLength(500)
                .HasColumnName("text");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updated_date");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<ExamReference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__exam_ref__3213E83F71A3DA5E");

            entity.ToTable("exam_reference");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.EvalDate)
                .HasColumnType("datetime")
                .HasColumnName("eval_date");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Course).WithMany(p => p.ExamReferences)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__exam_refe__cours__6A30C649");

            entity.HasOne(d => d.User).WithMany(p => p.ExamReferences)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__exam_refe__user___4CA06362");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lesson__3213E83F11E95A64");

            entity.ToTable("lesson");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.FileUrls)
                .HasMaxLength(500)
                .HasColumnName("file_urls");
            entity.Property(e => e.Index).HasColumnName("index");
            entity.Property(e => e.Subject)
                .HasMaxLength(500)
                .HasColumnName("subject");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updated_date");
            entity.Property(e => e.Title).HasColumnName("title").HasMaxLength(255);

            entity.HasOne(d => d.Course).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__lesson__course_i__6754599E");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__lesson__updated___66603565");
        });

        modelBuilder.Entity<Media>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("media");

            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.LessonId).HasColumnName("lesson_id");
            entity.Property(e => e.MediaType).HasColumnName("media_type");

            entity.HasOne(d => d.Lesson).WithMany()
                .HasForeignKey(d => d.LessonId)
                .HasConstraintName("FK__media__lesson_id__4BAC3F29");
        });

        modelBuilder.Entity<QuestionAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__question__3213E83FFC54F2BF");

            entity.ToTable("question_answer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnswerValue)
                .HasMaxLength(500)
                .HasColumnName("answer_value");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.CorrectAnswer).HasColumnName("right_answer");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updated_date");

            entity.HasOne(d => d.Question).WithMany(p => p.QuestionAnswers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__question___quest__5FB337D6");
        });

        modelBuilder.Entity<UserCourse>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("user_course");

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Lesson).HasColumnName("lesson");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Course).WithMany()
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__user_cour__cours__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
