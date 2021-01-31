using Infrastructure;
using UnityEngine;

namespace Domain.Actions
{
    public struct Thing
    {
        public int Id { get; }
        public Vector3 Position { get; }

        private readonly bool _isBitten;

        public Thing(int id, bool bitten, Vector3 position)
        {
            Id = id;
            _isBitten = bitten;
            Position = position;
        }

        public override string ToString() => $"Id: {Id}, Bitten: {_isBitten}, Position: {Position}";

        public Thing Bitten(InGameCat inGameCat) => new Thing(Id, true, inGameCat.GetPosition());
    }
}