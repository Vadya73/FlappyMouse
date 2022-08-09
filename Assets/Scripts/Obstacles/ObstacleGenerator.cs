using UnityEngine;

namespace Scripts.Obstacles
{
    public class ObstacleGenerator : ObstaclePool
    {
        [SerializeField] private GameObject _obstaclePrefab;

        [SerializeField] private float _minSpawnPositionY, _maxSpawnPositionY;
        [SerializeField] private float _spawnRate;

        private float _elapsedTime = 0;

        private void Start()
        {
            Initialize(_obstaclePrefab);
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _spawnRate)
            {
                if (TryGetObject(out GameObject obstacle))
                {
                    _elapsedTime = 0;

                    float spawnPositionY = Random.Range(_minSpawnPositionY,_maxSpawnPositionY);
                    Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                    obstacle.SetActive(true);
                    obstacle.transform.position = spawnPoint;

                    DisableObjectAbroadScreen();
                }
            }
        }
    }
}