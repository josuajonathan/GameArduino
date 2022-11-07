using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    #region singleton
    public static GameUI instance;
    public static GameUI Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameUI>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(GameUI).Name;
                    instance = obj.AddComponent<GameUI>();
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
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion singleton

    [Header("UI Component")]
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject pausePanel;

    private void Start()
    {
        mainCanvas = this.gameObject.GetComponentInChildren<Canvas>();
        mainCanvas.worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        mainCanvas.sortingLayerName = "Default";
        mainCanvas.sortingOrder = 2;

        losePanel.SetActive(false);
        winPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        EscapeBack();
    }

    public void EscapeBack()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    public void Pause()
    {
        SoundManager.Instance.PlaySound(SoundType.Button);
        GameManager.Instance.HandlePause();
        pausePanel.SetActive(true);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    public void Back()
    {
        SoundManager.Instance.PlaySound(SoundType.Button);
        GameManager.Instance.HandlePlay();
        pausePanel.SetActive(false);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    public void Win()
    {
        SoundManager.Instance.PlaySound(SoundType.Win);
        pausePanel.SetActive(false);
        losePanel.SetActive(false);
        winPanel.SetActive(true);
    }

    public void Lose()
    {
        SoundManager.Instance.PlaySound(SoundType.Lose);
        pausePanel.SetActive(false);
        losePanel.SetActive(true);
        winPanel.SetActive(false);
    }
}
