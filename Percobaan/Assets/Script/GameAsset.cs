using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameAsset : MonoBehaviour
{
    #region singleton
    public static GameAsset instance;
    public static GameAsset Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameAsset>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(GameAsset).Name;
                    instance = obj.AddComponent<GameAsset>();
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
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion singleton

    //  master variable
    [SerializeField] private List<Sound> m_SoundList;

    //  get variable
    public List<Sound> SoundList => m_SoundList;

    //  get from funvtion
    public AudioClip GetSound(SoundType _type)
    {
        AudioClip returnValue = null;

        switch (_type)
        {
            case SoundType.MAINMENU:
                foreach (Sound value in m_SoundList)
                {
                    if (value.type == _type) returnValue = value.sound;
                }
                break;

            case SoundType.BACKSOUND:
                foreach (Sound value in m_SoundList)
                {
                    if (value.type == _type) returnValue = value.sound;
                }
                break;

            case SoundType.button:
                foreach (Sound value in m_SoundList)
                {
                    if (value.type == _type) returnValue = value.sound;
                }
                break;

            default:
                returnValue = null;
                break;
        }

        return returnValue;
    }

    //  struct
    [System.Serializable]
    public struct Sound
    {
        public AudioClip sound;
        public SoundType type;
    }
}
