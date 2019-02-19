using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour {

    
    public int round = 1;
    [SerializeField]
    int zombiesInRound = 3;
    int zombiesSpawnedInRound = 0;
    float zombieSpawnTimer = 0;
    public Transform[] zombieSpawnPoints;
    public GameObject zombieEnemy;

    static int playerScore = 0;
    static int playerCash = 0;
    
    [SerializeField]
    private GameObject _pauseMenuPanel; //Pause Menu Variable
    private bool isPaused;
    private UIManager _uiManager;

    
    public Button resumeGame;
    public Button backToMenu;
    

    // Use this for initialization
    void Start ()
    {
        
        resumeGame = resumeGame.GetComponent<Button>();
        //hide mouse cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }
	
	// Update is called once per frame
	void Update ()
    {


        //if escape key pressed 
        //unhide mouce cursor

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
       
        //if p key
        //pause game
        //enable pause menu

        if (Input.GetKeyDown(KeyCode.P))
        {

            isPaused =! isPaused;

            if (isPaused)
            {
                ActivatePauseMenu();
               
                backToMenu.enabled = true;
                    resumeGame.enabled = true;
            }

            else {

                DeactivatePauseMenu();
               
            }
            
        }
        if (zombiesSpawnedInRound < zombiesInRound)
        {
            if (zombieSpawnTimer > 1)
            {
                SpawnZombie();
                zombieSpawnTimer = 0;
            }
            else
            {
                zombieSpawnTimer += Time.deltaTime;
            }
        }
    }

    void ActivatePauseMenu()
    {
        
        _pauseMenuPanel.SetActive(true);
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        Time.timeScale = 0;




        //AudioListener.pause = true;
    }

    void DeactivatePauseMenu() {

        Time.timeScale = 1;
        _pauseMenuPanel.SetActive(false);
        AudioListener.pause = false;
        isPaused = false;
       
    }
    public void ResumeGame()
    {
        _pauseMenuPanel.SetActive(false);
        resumeGame.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

    }
    // Back to main menu
    public void BackToMainMenu()
    {

        _pauseMenuPanel.SetActive(false);
        SceneManager.LoadScene(0);



    }

    void SpawnZombie()
    {
        Vector3 randomSpawnPoint = zombieSpawnPoints[Random.Range(0, zombieSpawnPoints.Length)].position;
        // Vector3 position = new Vector3(Random.Range(-10f, 10f), Random.Range(-3f, 3f), Random.Range(-10f, 10f));
        Instantiate(zombieEnemy, randomSpawnPoint, Quaternion.Euler(0, 0, 0));
        zombiesSpawnedInRound++;
    }



    

}
