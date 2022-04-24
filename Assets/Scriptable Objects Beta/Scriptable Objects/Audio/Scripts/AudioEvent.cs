using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using System;

public abstract class AudioEvent : ScriptableObject
{
	public abstract void Play(AudioSource source);
}
