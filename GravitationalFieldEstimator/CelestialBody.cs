using System;
using System.Numerics;

namespace GravitationalFieldEstimator
{
	public class CelestialBody
	{
        protected double _mass;
        protected Vector2D _position;
        protected Vector2D _speed;

        public double Mass { get { return _mass; } }
        public Vector2D Position { get { return _position; } set { _position = value; } }
        public Vector2D Speed { get { return _speed; } set { _speed = value; } }

        public CelestialBody(double mass, Vector2D position, Vector2D speed)
        {
            _mass = mass;
            _position = position;
            _speed = speed;
        }
    }
}