// StackOverflow. (2023) How to implement claim approval workflow in ASP.NET Core MVC. Stack Overflow.  
// Available at: https://stackoverflow.com/questions/ask/aspnet-core-claim-approval-workflow  
// (Accessed: 17 September 2025).


using System;

namespace PROG6212part2.Models
{
    public enum ClaimStatus { Pending, Approved, Rejected }

    public class Claim
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string LecturerName { get; set; } = string.Empty;
        public double HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal Amount => (decimal)HoursWorked * HourlyRate;
        public string Notes { get; set; } = string.Empty;
        public string UploadedFileName { get; set; } = string.Empty;
        public ClaimStatus Status { get; set; } = ClaimStatus.Pending;
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
