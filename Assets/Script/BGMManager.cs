using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BGMManager : MonoBehaviour
{
    public AudioSource audi;
    private void Awake()
    {
        audi = GetComponent<AudioSource>();
        audi.Play();
    }
}
