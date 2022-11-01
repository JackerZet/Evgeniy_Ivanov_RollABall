using RollABall.Objects;
using UnityEngine;

namespace RollABall.Managers
{
    public class OpeningElementsManager : MonoBehaviour
    {       
        #region Link
        [SerializeField] private OpeningGroup[] openingGroups;
        #endregion

        #region MonoBehaviour method
        private void OnEnable() 
        { 
            foreach (var group in openingGroups)
            {
                try
                {
                    group.SetGroup();
                    group.Init();
                }
                catch
                {
                    Debug.LogWarning("The one of opening groups isn't complete. This group is removed. ");
                }               
            }
        }
        private void OnDisable()
        {
            foreach(var group in openingGroups)
            {
                group.Dispose();
            }             
        }
        #endregion
    }   
}
