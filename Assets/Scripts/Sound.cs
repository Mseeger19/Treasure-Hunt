using UnityEngine;
using UnityEngine.Audio; 

[System.Serializable]

public class Sound 
{
    public string name; 

    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f,3f)]
    public float pitch;

    public bool loop; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
