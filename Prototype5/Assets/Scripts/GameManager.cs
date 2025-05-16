using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1f;
    public TextMeshProUGUI scoreText;
    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }
    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            UpdateScore(1);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
