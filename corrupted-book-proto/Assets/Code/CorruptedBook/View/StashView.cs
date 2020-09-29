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
        [SerializeField] private Button closeStashButton;
        [SerializeField] private GameObject panel;
        private StashPresenter presenter;
        
        public void OnStart(IItemProvider itemProvider, IRandomProvider randomProvider)
        {
            HideItems();
            presenter = new StashPresenter(this, itemProvider, randomProvider );
            closeStashButton.onClick.AddListener(()=> presenter.Close());
        }

        public void DisplayItems(List<Item> itemsToDisplay)
        {
            panel.SetActive(true);
            for (var i = 0; i < itemsToDisplay.Count; i++)
            {
                items[i].gameObject.SetActive(true);
            }
        }

        public void Open()
        {
           presenter.Open();
        }

        public void HideItems()
        {
            panel.SetActive(false);
            foreach (var item in items)
            {
                item.gameObject.SetActive(false);
            }
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