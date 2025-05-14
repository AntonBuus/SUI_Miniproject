using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
// borowed from a previous project
// this class is used to create a sound object that can be played
public class Sound
{

	public string name;

	public AudioClip clip;

	[Range(0f, 10f)]
	public float volume = 1f;
	[Range(0.1f, 3f)]
	public float pitch = 1f;

	[Range(0f, 1)]
	public float spatialBlend = 1f;


    public bool loop;

	[HideInInspector]
	public AudioSource source;
}