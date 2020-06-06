using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velX = 10f;
    Rigidbody2D rb;
    public Animator anim;

    public bool apunP;
    public bool apunE;

    //COMO CREAR RESIDENT EVIL 3 EN 2D PARTE 4
    public float tiempoE;
    public float tiempoP;
    public bool tiro;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movX;
        movX = Input.GetAxis("Horizontal");
        anim.SetFloat("Correr", Mathf.Abs(movX));
        rb.velocity = new Vector2(velX * movX, rb.velocity.y);

        if (Input.GetButtonDown("Fire2") && apunP == true && apunE == false) anim.SetTrigger("ApunP");
        if (Input.GetButtonDown("Fire2") && apunE == true && apunP == false) anim.SetTrigger("ApunE");

        if (movX < 0) transform.localScale = new Vector3(-1, 1, 1);
        if (movX > 0) transform.localScale = new Vector3(1, 1, 1);


        //COMO CREAR RESIDENT EVIL 3 EN 2D PARTE 4

        //Para Disparar con la Escopeta
        if (Input.GetButtonDown("Fire1") && tiro == false && apunE)
        {
            anim.SetBool("AttackEsc", true);
            tiro = true;
            StartCoroutine("EsperaEscopeta");
        }
        else if (tiro )
        {
            anim.SetBool("AttackEsc", false);
        }

        //Para Dispara Con la Pistola
        if (Input.GetButtonDown("Fire1") && tiro == false && apunP)
        {
            anim.SetBool("AttackPist", true);
            tiro = true;
            StartCoroutine("EsperaPistola");
        }
        else if (tiro)
        {
            anim.SetBool("AttackPist", false);
        }


    }

    //tiempo de Espera Escopeta
    IEnumerator EsperaEscopeta()
    {
        yield return new WaitForSeconds(tiempoE);
        anim.SetBool("AttackPist", false);
        anim.SetBool("AttackEsc", false);
        tiro = false;
    }

    //tiempo de Espera Pistola
    IEnumerator EsperaPistola()
    {
        yield return new WaitForSeconds(tiempoP);
        anim.SetBool("AttackPist", false);
        anim.SetBool("AttackEsc", false);
        tiro = false;
    }

}
