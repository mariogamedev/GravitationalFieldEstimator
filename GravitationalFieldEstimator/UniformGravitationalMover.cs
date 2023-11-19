
namespace GravitationalFieldEstimator
{
	 public class UniformGravitationalMover : IGravitationalMovable
    {
        private GravitationalField _gravitationField;
        private CelestialBody _gravitationalSourceBody;
        private CelestialBody _evaluationBody;

        private Vector2D _distance;
        private double _distanceMagnitude;
        private Vector2D _acceleration;

        public UniformGravitationalMover(GravitationalField gravitationalField,
            CelestialBody gravitationalSourceBody, CelestialBody evaluationBody)
        {
            _gravitationField = gravitationalField;
            _gravitationalSourceBody = gravitationalSourceBody;
            _evaluationBody = evaluationBody;
        }

        public Vector2D EstimatePosition(double time)
        {
            if (_gravitationalSourceBody.Mass > 0)
            {
                 CalculateBodiesDistance();
            
                if (_distanceMagnitude == 0)
                {
                    return _evaluationBody.Position;
                }
                
                CalculateAcceleration();
                UpdatePosition(time);
            }
            else
            {
                _evaluationBody.Position = new Vector2D(_evaluationBody.Position.X   
                + _evaluationBody.Speed.X * time, _evaluationBody.Position.Y + 
                _evaluationBody.Speed.Y * time);
            }
            return _evaluationBody.Position;
        }

        private void CalculateBodiesDistance()
        {
            _distance = new Vector2D(_gravitationalSourceBody.Position.X - 
            _evaluationBody.Position.X,           
            _gravitationalSourceBody.Position.Y - _evaluationBody.Position.Y);
            _distanceMagnitude = _distance.Length();    
        }

        private void CalculateAcceleration()
        {
            double forceMagnitude = (_gravitationField.GravitationalConstant *
             _evaluationBody.Mass * _gravitationalSourceBody.Mass) / 
             (_distanceMagnitude * _distanceMagnitude);
            Vector2D forceDirection = new Vector2D(_distance.X /
             _distanceMagnitude, _distance.Y / _distanceMagnitude);
            Vector2D gravitationalForce = new Vector2D(forceDirection.X * 
            forceMagnitude, forceDirection.Y * forceMagnitude);
            
            _acceleration = new Vector2D(gravitationalForce.X / 
            _evaluationBody.Mass, gravitationalForce.Y / _evaluationBody.Mass);
       }

        private void UpdatePosition(double time)
        {
            _evaluationBody.Speed.X += _acceleration.X * time;
            _evaluationBody.Speed.Y += _acceleration.Y * time;

            _evaluationBody.Position.X += _evaluationBody.Speed.X * time;
            _evaluationBody.Position.Y += _evaluationBody.Speed.Y * time;
        }
    }
}