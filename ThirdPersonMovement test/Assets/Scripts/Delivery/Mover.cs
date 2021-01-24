using System;
using Domain;
using Domain.Actions;
using Infrastructure;
using UniRx;
using UnityEngine;

namespace Delivery
{
    public class Mover : MonoBehaviour
    {
        private MoveCat _moveCatCat;
        private Jump _jump;
        private InGameCat _inGameCat;

        [SerializeField] private CatView _catView;
        [SerializeField] private Vector3 _airForce;
        public void Initialize(MoveCat moveCat, Jump jump, InGameCat inGameCat)
        {
            _moveCatCat = moveCat;
            _jump = jump;
            _inGameCat = inGameCat;
        }
        
        private void Update()
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jump.Execute(_airForce);
                _catView.MakeJump(_inGameCat.Get());
            }
                

            if (!(Math.Abs(h) > 0.1f) && !(Math.Abs(v) > 0.1f)) return;
            _moveCatCat.Execute(new Vector3(h, 0, v), Time.deltaTime);
            _catView.UpdatePosition(_inGameCat.Get());
        }
    }
}