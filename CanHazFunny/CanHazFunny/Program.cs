
namespace CanHazFunny
{
    class Program
    {
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
