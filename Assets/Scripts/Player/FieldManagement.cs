using UnityEngine;

namespace RollABall.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class FieldManagement : MonoBehaviour
    {
        #region Links
        [SerializeField] private float angleOfRotation = 8f;
        [SerializeField] private Transform player;
        #endregion

        #region Consts
        private const string horisontal = "Horizontal";
        private const string vertical = "Vertical";
        #endregion

        #region Fields
        private float _velX = 0.0f;
        private float _velZ = 0.0f;
        private Rigidbody _rig;
        private float _rotX;
        private float _rotZ;
        private float _delay = 0.17f;       
        #endregion

        #region MonoBehaviors methods
        private void Start()
        {
            _rig = GetComponent<Rigidbody>();            
        }
        private void Update()
        {
            RotateField();          
        }
        #endregion
        private void RotateField()
        {
            if (player == null) return;
            _delay = 0.17f * Mathf.Sqrt(Vector3.Distance(transform.position, player.position));
            _rotX = Mathf.SmoothDamp(_rotX, Input.GetAxis(horisontal) * angleOfRotation, ref _velX, _delay);
            _rotZ = Mathf.SmoothDamp(_rotZ, Input.GetAxis(vertical) * angleOfRotation, ref _velZ, _delay);
            _rig.MoveRotation(Quaternion.Euler(_rotX, 0f, _rotZ));
        }
    }
}
