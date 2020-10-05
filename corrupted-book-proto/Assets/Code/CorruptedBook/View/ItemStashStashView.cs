using System;
using CorruptedBook.Core;
using CorruptedBook.Presentation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CorruptedBook.View
{
    public  class ItemStashStashView : MonoBehaviour, IItemStashView
    {
        [SerializeField] private TextMeshProUGUI textLabel;
        [SerializeField] private Button itemButton;

        public void UpdateItemInformation(Item item)
        {
            textLabel.text = item.Id.ToString();
        }

        public void Init(Action action)
        {
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(action.Invoke);
        }
    }
}