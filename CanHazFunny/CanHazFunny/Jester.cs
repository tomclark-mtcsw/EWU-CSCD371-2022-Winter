using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CanHazFunny;

public class Jester : IJokeService, IJokeOutput
{
    public string GetJoke()
    {
        JokeService jokeService = new();
        string joke = jokeService.GetJoke();
        return joke;
    }

    public bool TellJoke()
    {
        string joke;

        do
        {
            joke = GetJoke();
        }
        while (IsChuckNorrisJoke(joke));

        return DisplayJoke(joke);
    }

    // Not implementing Globalization
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>")]
    public bool DisplayJoke(string theJoke)
    {
        bool success = false;
        if (string.IsNullOrEmpty(theJoke))
        {
            OutputText("I didn't get the joke.");
        }
        else
        {
            OutputText(theJoke);
            success = true;
        }
        return success;
    }

    public static bool IsChuckNorrisJoke(string joke)
    {
        if (!string.IsNullOrEmpty(joke))
        {
            return joke.Contains("Chuck", StringComparison.OrdinalIgnoreCase) || joke.Contains("Norris", StringComparison.OrdinalIgnoreCase);
        }

        return false;
    }

    public void OutputText(string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            Console.WriteLine(UnicodeConverter(text));
        }
    }

    // Not implementing Globalization
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "<Pending>")]
    private static string UnicodeConverter(string text)
    {
        while (text.Contains(@"\u"))
        {
            int index = text.IndexOf(@"\u");
            string replaceString = text.Substring(index, 6);
            string ucode = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Unicode, Encoding.UTF8, Encoding.Unicode.GetBytes(Regex.Unescape(replaceString))));
            text = text.Replace(replaceString, ucode);
        }

        return text;
    }
}
