using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ParticleButton : MonoBehaviour {

    ParticleSystem emitter;
    Image buttonSprite;

    float tweenDuration = .2f;
    float hoverAlpha = .3f;

    void Start()
    {
        // set components
        emitter = this.GetComponentInChildren<ParticleSystem>();
        buttonSprite = this.GetComponent<Image>();

        // reduce alpha to zero
        buttonSprite.CrossFadeAlpha(0f, 0f, false);

        // set color
        emitter.startColor = this.GetComponent<Image>().color;

        // generic mesh altering code

        //Vector2[] verts2d = buttonSprite.sprite.vertices;

        //List<Vector3> verts3d = new List<Vector3>();

        //foreach (Vector2 point in verts2d)
        //{
        //    verts3d.Add(new Vector3(point.x, point.y, 1));
        //}

        //Mesh mesh = new Mesh();
        //mesh.SetVertices(verts3d);

        //emitter.shape.box.s

    }

    public void OnMouseEnter()
    {
        buttonSprite.CrossFadeAlpha(hoverAlpha, tweenDuration, false);

        emitter.Play();
    }

     public void OnMouseExit()
    {
        buttonSprite.CrossFadeAlpha(0f, tweenDuration, false);

        emitter.Stop();
    }


}
