
namespace CanHazFunny
{
    class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>")]
        static void Main()
        {
            //Feel free to use your own setup here - this is just provided as an example
            //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();

            Jester jester = new Jester();
            jester.TellJoke();
            jester.TellJoke();
            jester.TellJoke();
            jester.TellJoke();
        }
    }
}
