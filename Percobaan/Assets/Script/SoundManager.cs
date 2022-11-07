using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    #region singleton
    public static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(SoundManager).Name;
                    instance = obj.AddComponent<SoundManager>();
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

    [SerializeField] private AudioSource audioPlay;

    public void PlaySound(SoundType _type)
    {
        switch (_type)
        {
            case SoundType.Lose:
                audioPlay.PlayOneShot(GameAsset.Instance.GetSound(_type));
                break;

            case SoundType.Button:
                audioPlay.PlayOneShot(GameAsset.Instance.GetSound(_type));
                break;

            case SoundType.Win:
                audioPlay.PlayOneShot(GameAsset.Instance.GetSound(_type));
                break;

            case SoundType.BACKSOUND:
                audioPlay.loop = true;
                audioPlay.clip = GameAsset.Instance.GetSound(_type);
                audioPlay.Play();
                break;

            default:
                Debug.Log("Empty Sound Reference");
                break;
        }
    }

    public void EndSound()
    {
        audioPlay.Stop();
    }

    public void TransitionPlay()
    {
        audioPlay.Play();
    }
}