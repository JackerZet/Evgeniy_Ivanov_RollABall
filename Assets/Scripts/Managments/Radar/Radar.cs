using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace RollABall.Game
{
    public class Radar : MonoBehaviour
    {
        #region Links
        [SerializeField] private float _mapScale = 2;
        [SerializeField] private List<RadarObject> radarObjects;
        #endregion

        #region Fields
        private Transform _target;
        private readonly List<RadarObjectPoint> _points = new();
        #endregion

        #region MonoBahaivor methods
        private void OnEnable()
        {            
            foreach(var obj in radarObjects)           
                RegisterRadarPoint(obj);
            
            StartCoroutine(Coroutine_UpdateRadarPoints());
        }
        private void OnDisable()
        {
            StopCoroutine(Coroutine_UpdateRadarPoints());

            foreach (var obj in _points)            
                UnregisterRadarPoint(obj);
            
            _points.RemoveAll(point => point);            
        }
        private void Start()
        {
            _target = Camera.main.transform;
        }
        #endregion

        #region Functionality
        public void RegisterRadarPoint(RadarObject radarObject)
        {
            RadarObjectPoint i = Instantiate(radarObject.Icon).GetComponent<RadarObjectPoint>();
            i.SetRadarObject(radarObject.transform, radarObject.Icon);
            _points.Add(i);
        }
        public void UnregisterRadarPoint(RadarObjectPoint point)
        {
            if (point == null) return;
            Destroy(point);
        }
        private void DrawRadarPoints()
        {           
            foreach (RadarObjectPoint point in _points)
            {
                if (point.RadarObject == null || _target == null) return;

                Vector3 radarPos = point.RadarObject.position - _target.position;
                    //float distToObject = Vector3.Distance(_target.position, point.RadarObject.position) * _mapScale;
                    //float deltay = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - _target.eulerAngles.y;

                    //radarPos.x = distToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
                    //radarPos.z = distToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);
                radarPos *= _mapScale;
                
                point.transform.SetParent(transform);
                point.transform.position = new Vector3(radarPos.z, -radarPos.x, 0) + transform.position;
            }
        }
        private IEnumerator Coroutine_UpdateRadarPoints()
        {
            while (true)
            {
                DrawRadarPoints();
                yield return new WaitForSeconds(0.2f);
            }
        }
        #endregion
    }
}
