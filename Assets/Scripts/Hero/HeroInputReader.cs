using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Hero
{
    public class HeroInputReader : MonoBehaviour
    {
        private HeroMovement _hero;

        private void Start()
        {
            _hero = GetComponent<HeroMovement>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
                _hero.Jump();
        }

        public void OnDash(InputAction.CallbackContext context)
        {
            if (context.performed)
                _hero.Dash();
        }
    }
}