namespace Arende_hantering_wpf.Models;

internal class CaseAddModel
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int StatusTypeId { get; set; } = 1;
    public UserModel User { get; set; } = null!;
}
