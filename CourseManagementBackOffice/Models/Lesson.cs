﻿namespace CourseManagementApi.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public string? Subject { get; set; }

    public int? Index { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? FileUrls { get; set; }

    public int? CourseId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual AppUser? UpdatedByNavigation { get; set; }
}
