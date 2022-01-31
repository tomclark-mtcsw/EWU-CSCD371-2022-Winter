
namespace CanHazFunny
{
    public class JokeModel
    {
        // Geek jokes API model uses lowercase in JSON
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "INTL0002:Properties PascalCase", Justification = "<Pending>")]
        public string joke { get; set; } = string.Empty;
    }
}
