using RollABall.Interactivity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using RollABall.SO;
//using RollABall.Args;

namespace RollABall.Player
{
    public class BunchOfKeys : MonoBehaviour
    {
        #region Links
        //[SerializeField] private KeyEvent keyEvent;
        #endregion

        #region Properties
        [field: SerializeField] public float DistanceBetweenKeys { get; private set; } = 1f;
        [field: SerializeField] public float SpeedOfKeys { get; private set; } = 2f;        
        public List<Key> CollectedKeys => _collectedKeys.Keys.ToList();
        #endregion

        #region Readonly's
        private readonly Dictionary<Key, IEnumerator> _collectedKeys = new();
        private readonly float _height = 0.05f;
        #endregion

        #region Monobehavior methods
        private void OnDisable()
        {
            StopAllCoroutines();
        }
        #endregion

        #region Functionality
        public void SetKeys(InteractiveObject i)
        {
            if (i is Key gettingKey)
            {
                if (CollectedKeys.Find(key => key == gettingKey)) return;

                Transform target = CollectedKeys.Any() ? CollectedKeys[^1].transform : transform;

                AddKey(gettingKey, Coroutine_Follow(gettingKey, target));                              
                
                //keyEvent.Notify(new KeyArgs(KeyArgs.KeysAction.Add, gettingKey));
            }
            else if (i is Locked door && CollectedKeys.Any())
            {
                var suitableKey = CollectedKeys.Find(key => key.Lockeds.Any(suitableDoor => suitableDoor == door));

                if (suitableKey != null)
                {
                    RemoveKey(suitableKey);
                    
                    suitableKey.Open(door);
                }              
            }
        }
        public Vector3 FollowWitnDistance(Vector3 follower, Vector3 target)
        {
            Vector3 curePos = target - (target - follower).normalized * DistanceBetweenKeys;
            curePos.y += _height;

            return Vector3.Lerp(follower, curePos, SpeedOfKeys * Time.deltaTime);
        }

        private void AddKey(Key key, IEnumerator enumerator)
        {
            _collectedKeys.Add(key, enumerator);
            StartCoroutine(enumerator);
        }
        private void RemoveKey(Key key)
        {
            StopCoroutine(_collectedKeys[key]);
            _collectedKeys.Remove(key);            
        }    
        
        private IEnumerator Coroutine_Follow(Key curentKey, Transform target)
        {
            while (true)
            {
                while (target.gameObject.activeInHierarchy)
                {                                                                                  
                    curentKey.transform.position = FollowWitnDistance(curentKey.transform.position, target.position);                    
                    //key.Collise(ref _dir);                
                    yield return new WaitForFixedUpdate();
                }             
                int keyIndex = CollectedKeys.IndexOf(curentKey);

                target = keyIndex == 0 ? transform : CollectedKeys[keyIndex - 1].transform;
            }           
        }               
        #endregion
    }
}
