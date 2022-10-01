using RollABall.Args;
using RollABall.Interactivity;
using RollABall.Interfaces;
using RollABall.SO;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall.Managers
{
    public class DoorsManager : MonoBehaviour, IObserver<PlayerArgs>, System.IDisposable
    {
        #region Links
        [SerializeField] private List<Door> doors;
        [SerializeField] private PlayerEvent playerEvent;
        #endregion

        #region MonoBehaviour methods
        private void OnEnable() => playerEvent.AddObserver(this);
        private void OnDisable() => Dispose();

        #endregion

        #region Functionality
        public void OnEventRaised(IHead<PlayerArgs> head, PlayerArgs args)
        {
            foreach(Door d in doors)
            {
                if (args.Keys == 0) d._isOpen = false;
                else d._isOpen = true; 
            }            
        }

        public void Dispose()
        {
            playerEvent.RemovObserver(this);
        }
        #endregion
    }
}
