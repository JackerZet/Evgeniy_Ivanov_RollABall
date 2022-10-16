using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RollABall.Game
{
    
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private List<Button> but_levels;
        private void OnEnable()
        {
            OnClick(1);
            OnClick(2);
            OnClick(3);          
        }

        private void OnDisable()
        {
            foreach (var but in but_levels)
            {                                
                but.onClick.RemoveAllListeners();               
            }
        }
        private void OnClick(int i)
        {
            but_levels[i - 1].onClick.AddListener(() => LoadLevel(i));
        }
        private void LoadLevel(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}

