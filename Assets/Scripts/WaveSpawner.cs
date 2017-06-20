using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {
	
	public Transform enemyPrefab;
	public Transform spawnPoint;

	public float EnemyCount = 10;
	public float timeBetweenWaves = 5f;
	private float countdown = 5f;
	
		public Text waveCountdownText;
	
		private int waveIndex = 0;
	
		void Update ()
		{
				if (countdown <= 0f)
					{
						StartCoroutine(SpawnWave());
						countdown = timeBetweenWaves;
					}
		
				countdown -= Time.deltaTime;
		
				waveCountdownText.text = Mathf.Round(countdown).ToString();
			}
	
		IEnumerator SpawnWave ()
		{
				++waveIndex;
		
				for (int i = 0; i < EnemyCount; i++)
					{
						SpawnEnemy();
						yield return new WaitForSeconds(0.5f);
					}
			}
	
		void SpawnEnemy ()
		{
				Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
			}
	
	}