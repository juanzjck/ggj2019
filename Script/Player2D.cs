using DG.Tweening;
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
    public GameObject[] vidas;
    int vida;
    public GameObject candale;
    public bool encendido;
    public float scalaMaxima;
    public float scalaMinima;
    public GameObject gameover;
    public int cerrillos;
    public bool llave;
    // Use this for initialization
    void Start () {
        gameover.SetActive(false);
       I = 0;
        v = 0;
        vidas = GameObject.FindGameObjectsWithTag("Vida");
        vida = vidas.Length;
    }
    public void flop() {
        if (CrossPlatformInputManager.GetAxis("Horizontal") > 0)
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
        else {
            if (CrossPlatformInputManager.GetAxis("Horizontal") < 0) {
                player.GetComponent<SpriteRenderer>().flipX = true;
            }
               
        }
    }
    public void gameOver() {
        if (vida==1) {
            gameover.SetActive(true);
            player.SetActive(false);
            Destroy(vidas[0]);
        }
    }
	// Update is called once per frame
	void Update () {

       
        if (Input.GetKeyDown(KeyCode.Space) && encendido==false) {
            if (cerrillos>0) {
                encender();
            }
           
         
            encendido = true;
        }
        if (candale.transform.localScale==new Vector3(scalaMaxima, scalaMaxima, scalaMaxima)) {
            candale.transform.DOScaleX(scalaMinima, 10);
            candale.transform.DOScaleY(scalaMinima, 10);
            candale.transform.DOScaleZ(scalaMinima, 10);
            

        }
        if (candale.transform.localScale == new Vector3(scalaMinima, scalaMinima, scalaMinima)) {
            encendido = false;
        }
        flop();
        control();
        gameOver();
        I = CrossPlatformInputManager.GetAxis("Vertical");
        v = CrossPlatformInputManager.GetAxis("Horizontal");
    }
   
    public void OnTriggerEnter2D(Collider2D other)
    {

         if (other.gameObject.tag=="Pared") {
           Debug.Log("OnCollisionEnter2D");
            tipoPared= other.gameObject.GetComponent<Pared>().tipo;
        }
        if (other.gameObject.tag == "Obstaculo") {
            Debug.Log("restar");
            vidaRestar();
        }
    }
    public void vidaRestar() {
        vidas = GameObject.FindGameObjectsWithTag("Vida");
        vida = vidas.Length;
        Destroy(vidas[vida-1]);
        vidas = GameObject.FindGameObjectsWithTag("Vida");
        vida = vidas.Length;
    }
    public void OnTriggerExit2D(Collider2D other)
    {
     
            Debug.Log("out");
            tipoPared = 0;

    }
    public void encender() {
        candale.transform.DOScaleX(scalaMaxima, 1);
        candale.transform.DOScaleY(scalaMaxima, 1);
        candale.transform.DOScaleZ(scalaMaxima, 1);
        cerrillos --;
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
