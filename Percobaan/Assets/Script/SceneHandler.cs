using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    #region singleton
    public static SceneHandler instance;
    public static SceneHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneHandler>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(SceneHandler).Name;
                    instance = obj.AddComponent<SceneHandler>();
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

    //  master variable
    private int m_Index;

    //  get variable
    public int Index => m_Index;

    // function
    public void SetIndex(int _index)
    {
        this.m_Index = _index;
    }

    public int GetIndex()
    {
        return this.m_Index;
    }

    public void NextScene()
    {
        m_Index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++m_Index);
    }

    public void LoadCurrentScene()
    {
        m_Index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(m_Index);
    }

    public void BackScene()
    {
        this.m_Index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(--m_Index);
    }

    public void LoadSceneInIndex(int _index)
    {
        this.m_Index = _index;
        SceneManager.LoadScene(this.m_Index);
    }

    public void LoadScenePlus(int _index)
    {
        this.m_Index += _index;
        SceneManager.LoadScene(this.m_Index);
    }

    public void LoadSceneMinus(int _index)
    {
        this.m_Index -= _index;
        SceneManager.LoadScene(this.m_Index);
    }
}
