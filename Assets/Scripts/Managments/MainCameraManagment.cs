using RollABall.SO;
using System.Collections;
using UnityEngine;
using static UnityEngine.Mathf;

namespace RollABall.Game
{
    public class MainCameraManagment : MonoBehaviour
    {
        #region Links
        [SerializeField] private float velocity = 5f;
        [Space(10)]
        [SerializeField] private float minHeight = 2f;
        [SerializeField] private float maxHeight = 10f;
        [Space(10)]
        [SerializeField, Range(0, 180)] private float angleLimit = 30;
        [Space(10)]
        [SerializeField] private DelegateEvent hitEvent;
        #endregion

        #region Consts
        private const string mouseScroll = "Mouse ScrollWheel";
        private const string mouseX = "Mouse X";
        private const string mouseY = "Mouse Y";
        #endregion

        #region Statics
        private static float sin45 = Sin(45f);
        #endregion

        #region Fields
        Vector3 _dir;
        private int _isMoving;

        private float _scroll;
        private float _range;

        private float _rot;
        private float _angleX;
        private int _isRotating;
        #endregion

        #region Monobehaivor methods
        private void Awake() => _angleX = transform.eulerAngles.y;
        private void LateUpdate()
        {
            Rotating();
            Moving();           
            Approximate();
        }
        private void OnEnable() => hitEvent?.RegisterListener(ShakeOnEvent);       
        private void OnDisable() => hitEvent?.UnregisterListener(ShakeOnEvent);        
        #endregion

        #region Functionality
        private void Approximate()
        {
            _scroll = Clamp(Input.GetAxis(mouseScroll), transform.position.y < maxHeight ? -1f : 0f, transform.position.y > minHeight ? 1f : 0f);
            _range = Lerp(_range, _scroll * velocity, 0.15f);

            transform.Translate(0, 0, _range * Time.timeScale, Space.Self);
        }
        private void Moving()
        {
            if (Input.GetMouseButtonDown(0)) _isMoving = 1;
            else if (Input.GetMouseButtonUp(0)) _isMoving = 0;

            _dir.x = Lerp(_dir.x, -Input.GetAxis(mouseX) * velocity / 10, 0.15f);
            _dir.z = Lerp(_dir.z, -Input.GetAxis(mouseY) * velocity / 10 * sin45, 0.15f);
            _dir.y = _dir.z;

            transform.Translate(_dir * Time.timeScale * _isMoving, Space.Self);           
        }
        private void Rotating()
        {
            if (Input.GetMouseButtonDown(1)) _isRotating = 1;
            else if (Input.GetMouseButtonUp(1)) _isRotating = 0;

            _rot += _isRotating * Input.GetAxis(mouseX) * velocity / 1.5f;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(45f, Clamp(_rot, -angleLimit, angleLimit) + _angleX, 0) , 0.15f * Time.timeScale);
        }
        public void ShakeOnEvent() => StartCoroutine(Shaking());     
        private IEnumerator Shaking()
        {           
            Vector3 dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
            transform.Translate(dir);
            yield return new WaitForSeconds(0.1f);
            transform.Translate(-dir * 2);
            yield return new WaitForSeconds(0.1f);
            transform.Translate(dir);
            StopCoroutine(Shaking());
        }
        #endregion 
    }
}
