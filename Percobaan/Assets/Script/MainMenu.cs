using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
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
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion singleton

    [SerializeField] GameObject m_MainPanel;
    [SerializeField] GameObject m_OptionPanel;
    [SerializeField] GameObject m_CreditPanel;

    private void Start()
    {
        m_MainPanel.SetActive(true);
        m_OptionPanel.SetActive(false);
        m_CreditPanel.SetActive(false);
    }

    public void Play()
    {
        SceneHandler.Instance.NextScene();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
