using UnityEngine;
using UnityEngine.UI;

public class DiffucultyButton : MonoBehaviour
{
    private GameManager gameManager;
    private Button button;
    public int difficulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

    }
    public void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
