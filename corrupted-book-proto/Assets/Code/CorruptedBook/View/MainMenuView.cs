using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CorruptedBook.View
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button startGameButton;
        [SerializeField] private TextMeshProUGUI startGameButtonLabel;
        // Start is called before the first frame update
        void Start()
        {
            startGameButton.onClick.AddListener(NavigateStartScene);
        }

        private void NavigateStartScene()
        {
            SceneManager.LoadScene("FirstLevel");
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
