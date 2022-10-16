using RollABall.Args;
using RollABall.Interactivity;
using RollABall.Interfaces;
using RollABall.SO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RollABall.Player
{
    public class BunchOfKeys : MonoBehaviour
    {
        #region Links
        [SerializeField] private KeyEvent keyEvent;
        #endregion

        #region Properties
        [field: SerializeField] public float Distance { get; private set; } = 1f;
        [field: SerializeField] public float Speed { get; private set; } = 2f;        
        public List<Key> CollectedKeys => _collectedKeys.Keys.ToList();
        #endregion

        #region Fields
        private readonly Dictionary<Key, IEnumerator> _collectedKeys = new();
        #endregion

        #region Monobehavior methods
        private void OnDisable()
        {
            StopAllCoroutines();
        }
        #endregion

        #region Functionality
        public void SetKeys(IIndexHaving i)
        {
            if (i is Key gettingKey)
            {
                if (CollectedKeys.Find(key => key == gettingKey)) return;

                Transform target = CollectedKeys.Any() ? CollectedKeys[^1].transform : transform;

                AddKey(gettingKey, Coroutine_Follow(gettingKey, target));                              
                
                //keyEvent.Notify(new KeyArgs(KeyArgs.KeysAction.Add, gettingKey));
            }
            else if (i is Door door && CollectedKeys.Any())
            {
                var suitableKeys = CollectedKeys.Where(key => key.Index.Intersect(door.Index).Any());

                if (suitableKeys.Any())
                {
                    var suitableKey = suitableKeys.First();                                       

                    RemoveKey(suitableKey);
                    
                    suitableKey.Open();
                    door.Unlock();
                }              
            }
        }
        public Vector3 FollowWitnDistance(Vector3 follower, Vector3 target, float height)
        {
            Vector3 curePos = target - (target - follower).normalized * Distance;
            curePos.y += height;

            return Vector3.Lerp(follower, curePos, Speed * Time.deltaTime);
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
                    curentKey.transform.position = FollowWitnDistance(curentKey.transform.position, target.position, 0.05f);                    
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
