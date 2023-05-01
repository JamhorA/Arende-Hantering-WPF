namespace Arende_hantering_wpf.Models;

internal class CommentAddModel
{
    public string Comment { get; set; } = null!;
    public UserModel User { get; set; } = null!;
    public CaseModel Case { get; set; } = null!;
}
