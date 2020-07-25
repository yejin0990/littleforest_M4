using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BambooBgm : MonoBehaviour
{
    public AudioSource Bamboobackmusic;
    public static BambooBgm instance = null;

    void Awake()
    {
        Bamboobackmusic = GetComponent<AudioSource>();        
    }
    // Start is called before the first frame update
    void Start()
    {
        Backgroundm.instance.AudioSource.Stop();
        Bamboobackmusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void bamboobgmstop()
    {
        Bamboobackmusic.Stop();
    }
    public void bambooMusicPlay()
    {
        Bamboobackmusic.Play();
    }
}
