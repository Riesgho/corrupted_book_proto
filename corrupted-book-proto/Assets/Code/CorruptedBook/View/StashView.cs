using System;
using System.Collections.Generic;
using CorruptedBook.Core;
using CorruptedBook.Core.Providers;
using CorruptedBook.Presentation;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace CorruptedBook.View
{
    public class StashView : MonoBehaviour, IStashView
    {
        [SerializeField] private Image[] items;
        
        private StashPresenter presenter;
        
        public void OnStart(IItemProvider itemProvider, IRandomProvider randomProvider)
        {
            presenter = new StashPresenter(this, itemProvider, randomProvider );
        }

        public void DisplayItems(List<Item> itemsToDisplay)
        {
            for (var i = 0; i < itemsToDisplay.Count; i++)
            {
                items[i].gameObject.SetActive(true);
            }
        }

        public void Open()
        {
           presenter.Open();
        }
    }

//    [Serializable]
//    public class ItemView
//    {
//        [SerializeField] private Image image;
//
//        public Image Image
//        {
//            get => image;
//            set => image = value;
//        }
//    }
}