using UnityEngine;

namespace Domain
{
    public struct Cat
    {
        public enum CatStatus
        {
            Grounded,
            Jumping
        }

        public Cat(Vector3 position, int speed, CatStatus status, Vector3 airForce)
        {
            Position = position;
            _speed = speed;
            Status = status;
            AirForce = airForce;
        }

        public Vector3 Position { get; private set; }
        public CatStatus Status { get; private set; }
        public Vector3 AirForce { get; private set; }

        private readonly int _speed;

        public Cat Move(Vector3 direction, float deltaTime) =>
            new Cat(Position += deltaTime * _speed * direction, _speed, Status, AirForce);

        public Cat Jump(Vector3 airForce) => new Cat(Position, _speed, CatStatus.Jumping, airForce);

        public override string ToString()
        {
            return $"Position: {Position}, Speed: {_speed}, Status: {Status}, AirForce: {AirForce}";
        }
    }
}