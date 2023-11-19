using System.Numerics;

namespace GravitationalFieldEstimator
{
	public class GravitationStatementParser : IStatementParser
    {
        private const int STARTING_TIME_DISTRIBUTION_ARGUMENT_INDEX = 3;
        private const int DEFAULT_METEOR_MASS = 1;
        private readonly Vector2D _planetStartingPosition;
        private readonly Vector2D _planetStartingSpeed;

        private CelestialBody _planet;
        private CelestialBody _meteor;
        private string[] _input;
        private List<Vector2D> _timesDistribution;

        public CelestialBody Planet { get { return _planet; } }
        public CelestialBody Meteor { get { return _meteor; } }
        public List<Vector2D> TimeDistribution { get { return _timesDistribution; } }
        
        public GravitationStatementParser(string[] input)
        {
            _input = input;
            _planetStartingPosition = new Vector2D(0f, 0f);
            _planetStartingSpeed = new Vector2D(0f, 0f);
            _timesDistribution = new List<Vector2D>();
        }

        public void Parse()
        {
            string planetMass = _input[0];
            string[] meteorPosition = _input[1].Split(',');
            string[] meteorSpeed = _input[2].Split(',');

            for (int i = STARTING_TIME_DISTRIBUTION_ARGUMENT_INDEX; i < _input.Length; i++)
            {
                string[] timeEntry = _input[i].Split(',');
                _timesDistribution.Add(new Vector2D(Double.Parse(timeEntry[0]), 
                Double.Parse(timeEntry[1])));
            }

            _planet = new CelestialBody(Double.Parse(planetMass),
             _planetStartingPosition, _planetStartingSpeed);
            _meteor = new CelestialBody(DEFAULT_METEOR_MASS, 
            new Vector2D(Double.Parse(meteorPosition[0]), Double.Parse(meteorPosition[1])),
                new Vector2D(Double.Parse(meteorSpeed[0]), Double.Parse(meteorSpeed[1])));
        }
    }
}