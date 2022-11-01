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

    private void Start()
    {
        mainCanvas = this.gameObject.GetComponentInChildren<Canvas>();
        mainCanvas.worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        mainCanvas.sortingLayerName = "Default";
        mainCanvas.sortingOrder = 2;
    }
}
