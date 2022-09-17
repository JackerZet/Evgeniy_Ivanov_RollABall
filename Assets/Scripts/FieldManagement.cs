using UnityEngine;

namespace RollABall
{
    public class FieldManagement : MonoBehaviour
    {
        [SerializeField] private float angleOfRotation = 10f;
        
        private const string horisontal = "Horizontal";
        private const string vertical = "Vertical";
      
        private float _rotX;
        private float _rotZ;

        private void Update()
        {
            _rotX = Mathf.Lerp(_rotX, Input.GetAxis(horisontal) * angleOfRotation, 0.2f);
            _rotZ = Mathf.Lerp(_rotZ, Input.GetAxis(vertical) * angleOfRotation, 0.2f);            
            transform.rotation = Quaternion.Euler(_rotX, 0f, _rotZ);                       
        }
    }
}
