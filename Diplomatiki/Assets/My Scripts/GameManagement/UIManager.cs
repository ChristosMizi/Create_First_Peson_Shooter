using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenuPanel;
    [SerializeField]
    private GameObject _coin;

    public GameObject _MG;
    // It is responsible for updating OnScreen elements
    [SerializeField]
    private Text _AmmoText;
    public Text scoreText;
    static int playerScore = 0;
    static int playerCash = 0;
    static int zombiesKilled = 0;
    public Text ZombiesKilledText;
     public int zombiesForGameOver;

    public void UpdateScore()
    {
        playerScore += 10;
        scoreText.text = "Score: " + playerScore;
    }
    public void UpdateZombiesKilled() {

        zombiesKilled += 1;
        ZombiesKilledText.text = "Zombies Killed: " + zombiesKilled;
        zombiesForGameOver = zombiesKilled;
    }

    public void UpdateAmmo(int count)
    {
        _AmmoText.text = "Ammo: " + count;
    }

    public void CollectedCoin()

    {
        _coin.SetActive(true);
    }

    public void CollectedMG()

    {
        _MG.SetActive(true);
    }

    public void RemoveCoin()
    {
        _coin.SetActive(false);
    }
    public void RemoveMG()
    {
        _MG.SetActive(false);
    }
   

    //Resume Play method

    public void ResumePlay()
    {
        GameManagement gm = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        gm.ResumeGame();
        

    }


    // Back to main menu
    public void BackToMainMenu()
    {

        _pauseMenuPanel.SetActive(false);
        SceneManager.LoadScene(0);
        
       

    }

}
