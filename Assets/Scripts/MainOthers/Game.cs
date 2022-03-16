using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Text bombText;
    [SerializeField] private Player player;
    [SerializeField] private Health[] enemyHealth;
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image winScreen;
    [SerializeField] private Image loseScreen;
    [SerializeField] private Image StartScreen;
    [SerializeField] private int enemyCount;
    private int count;



    private void Start()
    {
       
        Pause();
        playerHealth.HasBeenKilled += GameOver;
        player.OnBombCountChange += ChangeCount;
        enemyCount = enemyHealth.Length;
        count = player.BombCount;
        bombText.text = count.ToString();
        Subscribe();
    }



    private void OnDisable()
    {
        player.OnBombCountChange -= ChangeCount;
        playerHealth.HasBeenKilled -= GameOver;
        UnSubcribe();
    }

    private void ChangeCount()
    {
        count--;
        bombText.text = count.ToString();
    }

    private void EnemyDied()
    {
        enemyCount--;
        if (enemyCount <= 0) 
        {
            winScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void GameOver()
    {
        loseScreen.gameObject.SetActive(true);
        Pause();
    }

    private void Subscribe()
    {
        for (int i = 0; i < enemyHealth.Length; i++)
        {
            enemyHealth[i].HasBeenKilled += EnemyDied;
        }
    }
    private void UnSubcribe()
    {
        for (int i = 0; i < enemyHealth.Length; i++)
        {
            enemyHealth[i].HasBeenKilled -= EnemyDied;
        }
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }


    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
