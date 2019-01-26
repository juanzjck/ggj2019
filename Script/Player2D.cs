using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player2D : MonoBehaviour {
   public float velocidad;
    public GameObject player;
    public   float I;
    public float v;
    public int tipoPared;
    // Use this for initialization
    void Start () {
        I = 0;
        v = 0;
	}
    public void flop() {
        if (CrossPlatformInputManager.GetAxis("Horizontal") > 0)
        {
            player.GetComponent<Transform>().localScale = new Vector3(1,1,1);
        }
        else {
            player.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
        }
    }
	// Update is called once per frame
	void Update () {
        flop();
        control();
        I = CrossPlatformInputManager.GetAxis("Vertical");
        v = CrossPlatformInputManager.GetAxis("Horizontal");
    }
   
    public void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.tag=="Pared") {
           Debug.Log("OnCollisionEnter2D");
            tipoPared= other.gameObject.GetComponent<Pared>().tipo;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
     
            Debug.Log("out");
            tipoPared = 0;

    }
    public void control() {

        Rigidbody2D RD = player.GetComponent<Rigidbody2D>();
        if (tipoPared==1) {
            if (CrossPlatformInputManager.GetAxis("Vertical") > 0)
            {
                 RD.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * velocidad, 0f);
                
            }
            else {
                RD.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * velocidad, CrossPlatformInputManager.GetAxis("Vertical") * velocidad);
            }
          
        }
        else {
            if (tipoPared == 2)
            {
                if (CrossPlatformInputManager.GetAxis("Horizontal")>0) {
                    RD.velocity = new Vector2( 0F, CrossPlatformInputManager.GetAxis("Vertical") * velocidad);

                }
                else {
                    RD.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * velocidad, CrossPlatformInputManager.GetAxis("Vertical") * velocidad);

                }
            }
            else {
                if (tipoPared==3) {
                    if (CrossPlatformInputManager.GetAxis("Vertical")<0)
                    {

                        RD.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * velocidad, 0F);

                    }
                    else {
                        RD.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * velocidad, CrossPlatformInputManager.GetAxis("Vertical") * velocidad);

                    }
                }
                else {
                    if (tipoPared == 4)
                    {
                        if (CrossPlatformInputManager.GetAxis("Horizontal") < 0)
                        {
                            RD.velocity = new Vector2(0F, CrossPlatformInputManager.GetAxis("Vertical") * velocidad);

                        }
                        else {
                            RD.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * velocidad, CrossPlatformInputManager.GetAxis("Vertical") * velocidad);

                        }
                    }
                    else {
                        if (tipoPared == 5) {
                            if (CrossPlatformInputManager.GetAxis("Horizontal") > 0 || CrossPlatformInputManager.GetAxis("Vertical") > 0)
                            {
                                RD.velocity = new Vector2(0f,0f);

                            }
                            else {
                                RD.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * velocidad, CrossPlatformInputManager.GetAxis("Vertical") * velocidad);

                            }
                        }
                        else
                    {
                            if (tipoPared == 6)
                            {
                                if (CrossPlatformInputManager.GetAxis("Horizontal") > 0 || CrossPlatformInputManager.GetAxis("Vertical") < 0)
                                {
                                    RD.velocity = new Vector2(0f, 0f);

                                }
                                else
                                {
                                    RD.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * velocidad, CrossPlatformInputManager.GetAxis("Vertical") * velocidad);

                                }
                            }
                            else {
                                if (tipoPared == 7)
                                {
                                    if (CrossPlatformInputManager.GetAxis("Horizontal") < 0 || CrossPlatformInputManager.GetAxis("Vertical") < 0)
                                    {
                                        RD.velocity = new Vector2(0f, 0f);

                                    }
                                    else
                                    {
                                        RD.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * velocidad, CrossPlatformInputManager.GetAxis("Vertical") * velocidad);

                                    }
                                }
                                else {
                                    if (tipoPared == 8) {
                                        if (CrossPlatformInputManager.GetAxis("Horizontal") < 0 || CrossPlatformInputManager.GetAxis("Vertical") > 0)
                                        {
                                            RD.velocity = new Vector2(0f, 0f);

                                        }
                                        else
                                        {
                                            RD.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * velocidad, CrossPlatformInputManager.GetAxis("Vertical") * velocidad);

                                        }
                                    }
                                    else {
                                        RD.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * velocidad, CrossPlatformInputManager.GetAxis("Vertical") * velocidad);

                                    }

                                }

                            }

                        }

                    }

                }

            }
        }

    }
}
