namespace GravitationalFieldEstimator
{
	public interface IStatementParser
	{
		public CelestialBody Meteor { get; }
		public CelestialBody Planet { get; }
		public void Parse();
		public List<Vector2D> TimeDistribution { get; }
	}
}