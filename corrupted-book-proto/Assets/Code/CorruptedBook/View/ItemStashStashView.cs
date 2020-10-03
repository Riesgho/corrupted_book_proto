using CorruptedBook.Core;
using CorruptedBook.Presentation;
using TMPro;
using UnityEngine;

namespace CorruptedBook.View
{
    public  class ItemStashStashView : MonoBehaviour, IItemStashView
    {
        [SerializeField] private TextMeshProUGUI textLabel;

        private ItemStashPresenter _stashPresenter;

        public void OnStart(IInventoryRepository inventory, Item item)
        {
            _stashPresenter = new ItemStashPresenter(this,inventory,item);
            _stashPresenter.OnStart();
        }
        public void UpdateItemInformation(Item item)
        {
            textLabel.text = item.Id.ToString();
        }
    }
}