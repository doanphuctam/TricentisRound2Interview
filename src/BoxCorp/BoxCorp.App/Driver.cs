using System;

namespace BoxCorp.App {
    public static class Driver
    {
        private static void Main()
        {
            var program = new Program();
            Console.Write("Amount of boxes left: {0}", program.SortBoxes());
        }
    }
}
