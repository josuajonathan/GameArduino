using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(GameManager).Name;
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion singleton

    private void Start()
    {
        HandlePlay();
    }

    private void Update()
    {
        CheckLose();
    }

    public void CheckLose()
    {
        if (CountDown.Instance.Time <= 0)
        {
            HandlePause();
            LoseHandle();
        }
    }

    public void WinHandle()
    {
        HandlePause();
        CountDown.Instance.StopTimer();
        GameUI.Instance.Win();
    }

    public void LoseHandle()
    {
        HandlePause();
        CountDown.Instance.StopTimer();
        GameUI.Instance.Lose();
    }

    public void HandlePause()
    {
        CountDown.Instance.StopTimer();
        Time.timeScale = 0f;
    }

    public void HandlePlay()
    {
        CountDown.Instance.StartTimer();
        Time.timeScale = 1f;
    }
}
