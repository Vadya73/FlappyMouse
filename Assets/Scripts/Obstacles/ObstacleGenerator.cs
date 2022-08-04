using System.Collections;
using UnityEngine;

namespace Scripts.Obstacles
{
    public class ObstacleGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _obstacle;

        [SerializeField] private float _minYRange, _maxYRange;
        [SerializeField] private float _spawnRate;

        private void Start()
        {
            StartCoroutine(ObstacleGenerate());
        }

        IEnumerator ObstacleGenerate()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnRate);
                float random = Random.Range(_minYRange, _maxYRange);
                GameObject newObstacle = Instantiate(_obstacle, new Vector2(transform.position.x + 2, random + transform.position.y), Quaternion.identity) ;
                Destroy(newObstacle, 6);
            }
        }
    }
}