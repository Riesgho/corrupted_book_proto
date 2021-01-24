using System;
using Domain;
using UnityEngine;

namespace Delivery
{
    public class CatView: MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void UpdatePosition(Cat cat)
        {
            transform.position = new Vector3(cat.Position.x,transform.position.y, cat.Position.z);
        }

        public void MakeJump(Cat cat)
        {
            _rigidbody.AddForce(cat.AirForce, ForceMode.Impulse);
        }
    }
}