using RollABall.Objects;
using UnityEngine;

namespace RollABall.Managers
{
    public class OpeningElementsManager : MonoBehaviour
    {       
        #region Link
        [SerializeField] public OpeningGroup[] openingGroups;
        #endregion

        #region MonoBehaviour method
        private void OnEnable() 
        { 
            foreach (var group in openingGroups)
            {
                try
                {
                    group.SetId(group.GetHashCode());
                }
                catch
                {
                    Debug.LogWarning("The one of opening groups isn't complete. This group is removed. ");
                }
            }                                
        }
        #endregion
    }   
}
