namespace GravitationalFieldEstimator
{
	public class Solver
	{
		private readonly float _gravitationalConstant;

		private IStatementParser _statementParser;
		private IGravitationalMovable _gravitationalMover;

		public Solver(IStatementParser statementParser, float gravitationalConstant)
		{
			_statementParser = statementParser;
			_gravitationalConstant = gravitationalConstant;
		}

		public void Initialize()
		{
			_statementParser.Parse();
            GravitationalField field = new GravitationalField(_gravitationalConstant);
            _gravitationalMover = new UniformGravitationalMover(field, 
            _statementParser.Planet, _statementParser.Meteor);
        }

        public void Solve()
        {
            foreach (Vector2D timeEntry in _statementParser.TimeDistribution)
            {
                for (int i = 0; i < timeEntry.Y; i++)
                {
                    Vector2D estimatedPosition =
                     _gravitationalMover.EstimatePosition(timeEntry.X);
                    Console.WriteLine($"{estimatedPosition.X:F2} {estimatedPosition.Y:F2}");
                }
            }
        }
	}
}