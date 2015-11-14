using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour
{
    public static AudioController controller;

    public AudioClip collectSound;
    AudioSource audio;

    void Awake()
    {
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void CollectGem()
    {
        audio.PlayOneShot(collectSound);
    }
}
