using System.Collections;
using UnityEngine;

namespace Scripts.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField] private Vector3 _startPosition;

        [Space][Header("Movement Settings")]
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _dashForce;
        [SerializeField] private float _dashCooldown;
        private bool _canJump;
        private bool _canDash;

        [Header("Rotation Settings")]
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _minRotationZ, _maxRotationZ;

        private Rigidbody2D _heroRigidbody;
        private Quaternion _minRotation, _maxRotation;

        private void Start()
        {
            _heroRigidbody = GetComponent<Rigidbody2D>();
            _heroRigidbody.velocity = Vector2.zero;

            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

            _canDash = false;
            _canJump = false;

            ResetHero();
        }

        private void Update()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }

        public void Jump()
        {
            if (_canJump == true)
            {
                transform.rotation = _maxRotation;
                _heroRigidbody.velocity = new Vector2(0, 0);
                _heroRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
            }
        }

        public void Dash()
        {
            if (_canDash)
            {
                _heroRigidbody.AddForce(transform.right * _dashForce, ForceMode2D.Impulse);

                _canDash=false;
                StartCoroutine(DashReload());
            }
        }

        public void ResetHero()
        {
            transform.position = _startPosition;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
            _heroRigidbody.velocity= Vector2.zero;

            _canDash = true;
        }

        IEnumerator DashReload()
        {
            yield return new WaitForSeconds(_dashCooldown);

            _canDash = true;
        }

        public void ToggleJumpCapability()
        {
            if (_canJump == true)
                _canJump = false;
            else 
                _canJump = true;
        }

        public void ToggleDashCapability()
        {
            if (_canDash == true)
                _canDash = false;
            else
                _canDash = true;
        }
    }
}