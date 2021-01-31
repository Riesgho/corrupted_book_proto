using System;
using Domain;
using Domain.Actions;
using Infrastructure;
using NSubstitute;
using UniRx;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Delivery
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private CatView _cat;
        [SerializeField] private CatInputControl catInputControl;

        private void Start()
        {
            var startPosition = new Vector3(0, _cat.transform.position.y, 0);
            var cat = new Cat(startPosition, 10, Cat.CatStatus.Grounded, Vector3.zero, 1,Vector3.forward);
            var inGameCat = new InGameCat(cat);
            var moveAction = new MoveCat(inGameCat);
            var jumpAction = new Jump(inGameCat);
            catInputControl.Initialize(moveAction, jumpAction, inGameCat);
        }
    }
}