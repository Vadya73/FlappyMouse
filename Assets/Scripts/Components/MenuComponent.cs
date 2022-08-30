using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Components
{
    public class MenuComponent : MonoBehaviour
    {
        [SerializeField] private string _menuSceneName = "MainMenu";
        [SerializeField] private string _sceneToLoad;

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Menu()
        {
            SceneManager.LoadScene(_menuSceneName);
        }

        public void SceneSwitch()
        {
            SceneManager.LoadScene(_sceneToLoad);
        }
    }

}