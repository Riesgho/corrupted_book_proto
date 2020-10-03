using System;
using System.Collections;
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
        [SerializeField] private ItemStashStashView[] items;
        [SerializeField] private Button closeStashButton;
        [SerializeField] private GameObject panel;
        
        private StashPresenter presenter;
        private IInventoryRepository inventoryRepository;
        
        
        public void OnStart(IItemProvider itemProvider, IRandomProvider randomProvider, IInventoryRepository inventoryRepository)
        {
            HideItems();
            presenter = new StashPresenter(this, itemProvider, randomProvider );
            closeStashButton.onClick.AddListener(()=> presenter.Close());
            this.inventoryRepository = inventoryRepository;
        }

        public void DisplayItems(List<Item> itemsToDisplay)
        {
            panel.SetActive(true);
            for (var i = 0; i < itemsToDisplay.Count; i++)
            {
                items[i].gameObject.SetActive(true);
                items[i].OnStart(inventoryRepository,itemsToDisplay[i]);
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
}