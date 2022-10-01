using RollABall.SO;
using System.Collections;
using UnityEngine;

namespace RollABall.Game
{
    public class MainCamera : MonoBehaviour
    {
        #region Links
        [SerializeField] private float velocity = 5f;
        [SerializeField] private float minHeight = 2f;
        [SerializeField] private float maxHeight = 10f;
        [SerializeField] private DelegateEvent hitEvent;
        #endregion

        #region Consts
        private const string mouseScroll = "Mouse ScrollWheel";
        private const string mouseX = "Mouse X";
        private const string mouseY = "Mouse Y";
        #endregion

        #region Fields
        private float _posX;
        private float _posZ;
        private float _scroll;
        private float _range;
        private float _isMoving;
        #endregion

        #region Monobehaivor methods

        private void LateUpdate()
        {
            Approximation();
            Moving();
        }
        private void OnEnable() => hitEvent.RegisterListener(ShakeOnEvent);
        private void OnDisable() => hitEvent.UnregisterListener(ShakeOnEvent);
        #endregion

        #region Functionality
        private void Approximation()
        {
            _scroll = Mathf.Clamp(Input.GetAxis(mouseScroll), transform.position.y < maxHeight ? -1f : 0f, transform.position.y > minHeight ? 1f : 0f);
            _range = Mathf.Lerp(_range, _scroll * velocity, 0.15f);
            transform.Translate(0, 0, _range * Time.timeScale, Space.Self);
        }
        private void Moving()
        {
            if (Input.GetMouseButtonDown(0)) _isMoving = 1f;
            if (Input.GetMouseButtonUp(0)) _isMoving = 0f;

            _posX = Mathf.Lerp(_posX, _isMoving * Input.GetAxis(mouseX) * velocity / 10, 0.15f);
            _posZ = Mathf.Lerp(_posZ, _isMoving * Input.GetAxis(mouseY) * velocity / 10, 0.15f);

            transform.Translate(_posZ * Time.timeScale, 0, -_posX * Time.timeScale, Space.World);
        }
        public void ShakeOnEvent() => StartCoroutine(Shaking());
        
        private IEnumerator Shaking()
        {           
            Vector3 dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            transform.Translate(dir);
            yield return new WaitForSeconds(0.1f);
            transform.Translate(-dir);
            transform.Translate(-dir);
            yield return new WaitForSeconds(0.1f);
            transform.Translate(dir);
            StopCoroutine(Shaking());
        }
        #endregion
    }
}
