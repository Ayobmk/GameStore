using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GameStore.Frontend.Models;
using GameStore.Frontend.Converters;

public class GameDetails

{
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
    public required string Name { get; set; }

    [Required (ErrorMessage = "Genre filed is required")]
    [JsonConverter(typeof(StringConverter))]
    public string? GenreId { get; set; }

    [Range(1, 100, ErrorMessage = "Price must be between 1 and 100.")] //we can add the error msg oor just let the Blazor do them for us
    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}
