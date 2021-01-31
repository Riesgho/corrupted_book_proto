using Domain.Actions;
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

        public Cat(Vector3 position, int speed, CatStatus status, Vector3 airForce, int biteRange,
            Vector3 facingDirection)
        {
            Position = position;
            _speed = speed;
            _facingDirection = facingDirection;
            _biteRange = biteRange;
            Status = status;
            AirForce = airForce;
        }


        public Vector3 Position { get; private set; }
        public CatStatus Status { get; }
        public Vector3 AirForce { get; }

        private readonly int _speed;
        private readonly int _biteRange;
        private readonly Vector3 _facingDirection;


        public Cat Move(Vector3 direction, float deltaTime) =>
            new Cat(Position += deltaTime * _speed * direction, _speed, Status, AirForce, _biteRange, _facingDirection);

        public Cat Jump(Vector3 airForce) => new Cat(Position, _speed, CatStatus.Jumping, airForce, _biteRange, _facingDirection);

        public bool CanBite(Thing thing) => IsFacingThing(thing);

        private bool IsFacingThing(Thing thing) => 
            IsFacingThingOnZAxes(thing) && IsFacingThingOnXAxes(thing) && IsFacingThingOnYAxes(thing);

        private bool IsFacingThingOnZAxes(Thing thing) =>
            thing.Position.z >= Position.z &&
            thing.Position.z <= (_biteRange * _facingDirection).z;

        private bool IsFacingThingOnXAxes(Thing thing) =>
            thing.Position.x >= Position.x &&
            thing.Position.x <= (_biteRange * _facingDirection).x;

        private bool IsFacingThingOnYAxes(Thing thing) =>
            thing.Position.y >= Position.y &&
            thing.Position.y <= (_biteRange * _facingDirection).y;

        public override string ToString()
        {
            return $"Position: {Position}, Speed: {_speed}, Status: {Status}, AirForce: {AirForce}";
        }
    }
}