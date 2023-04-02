using System.ComponentModel.DataAnnotations;

namespace YatzyApp.Models;

public class PlayerModel
{
    [Required]
    public string? Name { get; set; }
    public bool IsTurn { get; set; }
    public YatzyPointsHandler YatzyPoints { get; set; } = new();
}
