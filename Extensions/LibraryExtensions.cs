using LibraryManagement.Models;

namespace LibraryManagement.Extensions;

public static class LibraryExtensions
{
    public static DateTime GetDueDate(this LibraryMember member)
    {
        return member.IssueDate.AddDays(14);
    }

    public static string GetDueStatus(this LibraryMember member)
    {
        DateTime today = DateTime.Today;
        DateTime dueDate = member.GetDueDate();

        if (member.ReturnDate.HasValue)
        {
            return "Returned";
        }

        if (today > dueDate)
        {
            return "Overdue";
        }

        if ((dueDate - today).TotalDays <= 3)
        {
            return "Due Soon";
        }

        return "Issued";
    }

    public static decimal CalculateFine(this LibraryMember member)
    {
        DateTime today = DateTime.Today;
        DateTime dueDate = member.GetDueDate();

        if (member.ReturnDate.HasValue)
        {
            return 0;
        }

        if (today <= dueDate)
        {
            return 0;
        }

        int overdueDays = (today - dueDate).Days;

        return overdueDays * 10;
    }
}
