using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ParticleButton : MonoBehaviour {

    ParticleSystem emitter;

    void Start()
    {
        emitter = this.GetComponentInChildren<ParticleSystem>();

        
        emitter.startColor = Color.blue;
            
        
            //this.GetComponent<Image>().color;
    }

    public void OnMouseEnter()
    {
        emitter.Play();
    }

     public void OnMouseExit()
    {
        emitter.Stop();
    }


}
