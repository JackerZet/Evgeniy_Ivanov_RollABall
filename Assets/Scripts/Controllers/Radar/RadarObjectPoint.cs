using UnityEngine;
using UnityEngine.UI;

namespace RollABall.Game
{
    public class RadarObjectPoint : MonoBehaviour
    {
        public Transform RadarObject { get; private set; }
        public Image Icon { get; private set;  }
        public void SetRadarObject(Transform radarObject, Image icon)
        {
            RadarObject = radarObject;
            Icon = icon;
        }
    }
}
