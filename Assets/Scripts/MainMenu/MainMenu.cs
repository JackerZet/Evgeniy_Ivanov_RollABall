using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RollABall.Game
{
    
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private List<Button> but_levels;
        [SerializeField] private Button but_quitGame;

        private void OnEnable()
        {
            OnClick(1);
            OnClick(2);
            OnClick(3);
            but_quitGame.onClick.AddListener(() => QuitGame());
        }
        private void OnDisable()
        {
            foreach (var but in but_levels)
            {                                
                but.onClick.RemoveAllListeners();               
            }
            but_quitGame.onClick.RemoveAllListeners();
        }
        private void OnClick(int i)
        {
            but_levels[i - 1].onClick.AddListener(() => LoadLevel(i));
        }
        private void LoadLevel(int index)
        {
            SceneManager.LoadScene(index);
        }
        private void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}

