namespace GravitationalFieldEstimator
{
	public class GravitationalField
	{
		private readonly double GRAVITATIONAL_CONSTANT;

		public double GravitationalConstant { get { return GRAVITATIONAL_CONSTANT; } }

		public GravitationalField(double gravitationalConstant)
		{
			GRAVITATIONAL_CONSTANT = gravitationalConstant;
		}
	}
}

