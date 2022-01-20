using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.baltamstudios.stellardomination
{
    public class BGMusic : MonoBehaviour
    {
        [SerializeField]
        AudioClip menuMusic;
        [SerializeField]
        AudioClip BattleMusic;
        [SerializeField]
        AudioSource audioPlayer;

        public static BGMusic Instance //singleton
        {
            get { 
                    return instance;
                }
        }

        static BGMusic instance = null;

        // Start is called before the first frame update
        void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                instance = this;
            }
            DontDestroyOnLoad(this);
        }

        public void Start()
        {
            audioPlayer = GetComponent<AudioSource>();
        }
        public void PlayIntro()
        {
            Debug.Log("Play intro music");
            var aSource = GetComponent<AudioSource>();
            aSource.Stop();
            aSource.clip = menuMusic;
            aSource.Play();
        }

        public void PlayBattle()
        {
            audioPlayer.Stop();
            audioPlayer.clip = BattleMusic;
            audioPlayer.Play();
        }

        // Update is called once per frame
    }
}