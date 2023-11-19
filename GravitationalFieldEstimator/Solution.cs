namespace GravitationalFieldEstimator
{
    class Solution
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please, provide in arguments.");
                return;
            }

            Solver solver = new Solver(new GravitationStatementParser(args), 1);
            solver.Initialize();
            solver.Solve();
        }
    }
}