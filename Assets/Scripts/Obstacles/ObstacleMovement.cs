using UnityEngine;

namespace Scripts.Obstacles
{
    public class ObstacleMovement : MonoBehaviour
    {
        [SerializeField] private float _obstacleSpeed;
        private void Update()
        {
            transform.Translate(-_obstacleSpeed * Time.deltaTime, 0, 0);
        }
    }
}