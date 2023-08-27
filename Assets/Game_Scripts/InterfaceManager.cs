using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    Player player;
    public GameObject YouWin;
    public GameObject YouLose;

    private void Start()
    {
        Time.timeScale = 0;
        player = FindAnyObjectByType<Player>();
    }

    private void Update()
    {
        if (player.currentHealth < 0)
        {
            Time.timeScale = 0;
            YouLose.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

        if (player.cheeseCounter == 16)
        {
            Time.timeScale = 0;
            YouWin.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Play()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
