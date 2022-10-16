using RollABall.Args;
using RollABall.Interfaces;
using RollABall.Objects;
using RollABall.SO;
using System;
using UnityEngine;

namespace RollABall.Managers
{
    public class OpeningElementsManager : MonoBehaviour//, IObserver<KeyArgs>, System.IDisposable
    {
        
        #region Links

        [SerializeField] public OpeningGroup[] openingGroups;
        
        //[SerializeField] private KeyEvent keyEvent;
        #endregion

        #region MonoBehaviour methods
        private void OnEnable() 
        { 
            //keyEvent?.AddObserver(this);

            foreach (var group in openingGroups)
                group.SetId(group.GetHashCode());
            
            
        }
        //private void OnDisable() => Dispose();
        #endregion

        #region Functionality
        /*public void OnEventRaised(IHead<KeyArgs> head, KeyArgs args)
        {
            foreach (var group in openingGroups)
            {              
                //d.isOpenable = args.Keys == 0 ? false : true;                
            }
        }*/
        /*public void Dispose()
        {
            //keyEvent?.RemovObserver(this);
        }*/
        #endregion
    }
    
}
