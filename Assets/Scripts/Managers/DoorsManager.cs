using RollABall.Args;
using RollABall.Interactivity;
using RollABall.Interfaces;
using RollABall.SO;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall.Managers
{
    public class DoorsManager : MonoBehaviour, IObserver<PlayerArgs>
    {
        #region Links
        [SerializeField] private List<Door> doors;
        [SerializeField] private PlayerEvent playerEvent;
        #endregion

        #region MonoBehaviour methods
        private void OnEnable() => playerEvent.AddListener(this);
        private void OnDisable() => playerEvent.RemoveListener(this);
        
        #endregion
        
        public void OnEventRaised(IHead<PlayerArgs> head, PlayerArgs args)
        {
            foreach(Door d in doors)
            {
                if (args.Keys == 0) d._isOpen = false;
                else d._isOpen = true; 
            }            
        }
    }
}
