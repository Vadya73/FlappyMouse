using Scripts.UI;
using System.Collections;
using UnityEngine;

namespace Scripts.Hero
{
    public class Hero : MonoBehaviour
    {
        [Header("HeroSettings")]
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _dashForce;
        [SerializeField] private float _dashCooldown;
        [SerializeField] private bool _canDash;

        private Rigidbody2D _heroRigidbody;

        private void Start()
        {
            _heroRigidbody = GetComponent<Rigidbody2D>();
            Time.timeScale = 1f;

            _canDash = true;
        }
        public void Jump()
        {
            _heroRigidbody.velocity = Vector2.up * _jumpForce;
        }

        public void Dash()
        {
            if (_canDash)
            {
                _heroRigidbody.AddForce(transform.right * _dashForce, ForceMode2D.Impulse);

                _canDash=false;
                StartCoroutine(DashReload());
            }
            else
                return;
        }

        public void Death()
        {
            _canDash = false;
            Time.timeScale = 0f;
        }



        IEnumerator DashReload()
        {
            yield return new WaitForSeconds(_dashCooldown);

            _canDash = true;
        }
    }
}