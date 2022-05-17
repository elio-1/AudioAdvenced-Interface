using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTalk : MonoBehaviour, IUsable
{
    [SerializeField] AudioClip[] _sentences;
    private int currentSentence;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentSentence = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Use()
    {
        audioSource.PlayOneShot(_sentences[currentSentence]);
        currentSentence++;
        if (currentSentence >= _sentences.Length)
        {
            currentSentence = 0;
        }
    }
}
