using CorruptedBook.Core.Providers;
using CorruptedBook.Presentation;
using UnityEngine;
using UnityEngine.UI;

namespace CorruptedBook.View
{
    public class StashView : MonoBehaviour, IStashView
    {
        [SerializeField] private ItemStashStashView[] items;
        [SerializeField] private Button closeStashButton;
        [SerializeField] private GameObject panel;

        private StashPresenter presenter;

        public void OnStart(IItemProvider itemProvider, IRandomProvider randomProvider,
            IInventoryRepository inventoryRepository)
        {
            Hide();
            presenter = new StashPresenter(this, itemProvider, randomProvider, inventoryRepository);
            closeStashButton.onClick.AddListener(() => presenter.Close());
        }

        public void UpdateItemsInStash()
        {
            Hide();
            panel.SetActive(true);
            for (var i = 0; i < presenter.ItemsInStash.Count; i++)
            {
                items[i].gameObject.SetActive(true);
                var i1 = i;
                items[i].Init(()=>presenter.SaveItem(presenter.ItemsInStash[i1]));
                items[i].UpdateItemInformation(presenter.ItemsInStash[i]);
            }
        }

        public void Open()
        {
            presenter.Open();
        }

        public void Hide()
        {
            panel.SetActive(false);
            foreach (var item in items)
            {
                item.gameObject.SetActive(false);
            }
        }
    }
}