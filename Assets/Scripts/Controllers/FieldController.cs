using UnityEngine;

namespace RollABall.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class FieldController : MonoBehaviour
    {
        #region Links
        [SerializeField] private Transform player;
        [SerializeField] private float angleOfRotation = 8f;     
        #endregion

        #region Consts
        private const string horisontal = "Horizontal";
        private const string vertical = "Vertical";
        #endregion

        #region Fields
        private float _velX = 0.0f, _velZ = 0.0f;

        private Rigidbody _rig;

        private float _rotX, _rotZ;
        private float _delay; 
        #endregion

        #region MonoBehaviors methods
        private void Awake() => _rig = GetComponent<Rigidbody>();      
        private void FixedUpdate()
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
