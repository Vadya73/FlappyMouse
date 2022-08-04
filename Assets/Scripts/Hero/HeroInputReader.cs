using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Hero
{
    public class HeroInputReader : MonoBehaviour
    {
        private Hero _hero;

        private void Start()
        {
            _hero = GetComponent<Hero>();
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