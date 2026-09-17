using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models;

public class LibraryMember
{
    public int MemberId { get; set; }

    [Required(ErrorMessage = "Member Name is required.")]
    public string MemberName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Department is required.")]
    public string Department { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Book ID is required.")]
    public int BookId { get; set; }

    [Required(ErrorMessage = "Issue Date is required.")]
    [DataType(DataType.Date)]
    public DateTime IssueDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? ReturnDate { get; set; }
}
