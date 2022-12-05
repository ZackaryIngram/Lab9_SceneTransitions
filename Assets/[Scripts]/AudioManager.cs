using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public enum TrackID
    {
        Level1,
        Ship
    }


    [SerializeField]
    AudioClip[] musicTracks;

    [SerializeField]
    AudioSource musicSource1;
    [SerializeField]
    AudioSource musicSource2;

    //Hidden Contrusctor
    private AudioManager() { }

    
    private static AudioManager instance = null;
    //Singleton instance
    public static AudioManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                SceneManager.sceneLoaded += instance.OnSceneLoadedAction;
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
        private set { instance = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        AudioManager original = Instance;

        AudioManager[] managerClones = FindObjectsOfType<AudioManager>();
        foreach(AudioManager manager in managerClones)
        {
            if(manager != original)
            {
                Destroy(manager.gameObject);

            }
        }
    }

    void OnSceneLoadedAction(Scene newScene, LoadSceneMode loadMode)
    {
        if(newScene.name == "Ship")
        {
            CrossFadeTo(TrackID.Ship);
        }
        if (newScene.name == "Level1")
        {
            CrossFadeTo(TrackID.Level1);
        }
    }

    public void PlayTrack(TrackID track)
    {
        musicSource1.Stop();
        musicSource2.Stop();

        musicSource1.clip = musicTracks[(int)track];
        musicSource1.volume = 1;
        musicSource1.Play();

    }

    public void CrossFadeTo(TrackID goalTrack, float transitionDuractionSec = 3.0f)
    {
        AudioSource oldTrackSource = musicSource1;
        AudioSource newTrackSource = musicSource2;

        if(musicSource1.isPlaying)
        {

        }
        else if(musicSource2.isPlaying)
        {
            oldTrackSource = musicSource2;
            newTrackSource = musicSource1;
        }

        newTrackSource.clip = musicTracks[(int)goalTrack];
        newTrackSource.Play();

        StartCoroutine(CrossFadeCoroutine(oldTrackSource, newTrackSource, transitionDuractionSec));

    }

    private IEnumerator CrossFadeCoroutine(AudioSource oldTrackSource, AudioSource newTrackSource, float transitionDuractionSec)
    {
        float time = 0.0f;
       while(time < transitionDuractionSec)
        {
            float tValue = Mathf.Min(time / transitionDuractionSec, 1/0f);

            newTrackSource.volume = tValue;
            oldTrackSource.volume = 1.0f - tValue;

            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        oldTrackSource.Stop();
        oldTrackSource.volume = 1.0f;
    }
}
