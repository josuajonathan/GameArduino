using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : HighLightUI
{
    #region singleton
    public static MainMenu instance;
    public static MainMenu Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MainMenu>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(MainMenu).Name;
                    instance = obj.AddComponent<MainMenu>();
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

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject creditPanel;

    [SerializeField] private Image playImage;
    [SerializeField] private Image creditImage;
    [SerializeField] private Image optionImage;
    [SerializeField] private Image exitImage;

    private void Start()
    {
        Time.timeScale = 1f;
        SoundManager.Instance.PlaySound(SoundType.BACKSOUND);
        mainPanel.SetActive(true);
        optionPanel.SetActive(false);
        creditPanel.SetActive(false);
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

    public void Play()
    {
        SoundManager.Instance.PlaySound(SoundType.Button);
        SceneHandler.Instance.NextScene();
    }

    public void Back()
    {
        SoundManager.Instance.PlaySound(SoundType.Button);
        mainPanel.SetActive(true);
        optionPanel.SetActive(false);
        creditPanel.SetActive(false);
    }

    public void Credit()
    {
        SoundManager.Instance.PlaySound(SoundType.Button);
        creditPanel.SetActive(true);
        mainPanel.SetActive(false);
        optionPanel.SetActive(false);
    }

    public void Option()
    {
        SoundManager.Instance.PlaySound(SoundType.Button);
        mainPanel.SetActive(false);
        optionPanel.SetActive(true);
        creditPanel.SetActive(false);
    }

    public void Quit()
    {
        SoundManager.Instance.PlaySound(SoundType.Button);
        Application.Quit();
    }

    #region Pointer Highlight
    public void PointerPlayEnter()
    {
        playImage.color = HighLightButton(playImage);
    }

    public void PointerPlayExit()
    {
        playImage.color = UnHighLightButton(playImage);
    }

    public void PointerCreditEnter()
    {
        creditImage.color = HighLightButton(creditImage);
    }

    public void PointerCreditExit()
    {
        creditImage.color = UnHighLightButton(creditImage);
    }

    public void PointerOptionEnter()
    {
        optionImage.color = HighLightButton(optionImage);
    }

    public void PointerOptionExit()
    {
        optionImage.color = UnHighLightButton(optionImage);
    }

    public void PointerQuitEnter()
    {
        exitImage.color = HighLightButton(exitImage);
    }

    public void PointerQuitExit()
    {
        exitImage.color = UnHighLightButton(exitImage);
    }

    #endregion Pointer Highlight
}
