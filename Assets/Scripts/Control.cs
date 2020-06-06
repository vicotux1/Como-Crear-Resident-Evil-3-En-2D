using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{

    public GameObject botEsc;   
    public GameObject botPist;

    public Sprite escopeta;
    public Sprite pistola;

   public Vector2 Position_Escopeta;
    public Vector2 Position_Pistola;

    public Player pScript;
    public GameObject pObj;

    // Start is called before the first frame update
    void Start()
    {
        
        pObj = GameObject.FindObjectOfType<Player>().gameObject;
        pScript = pObj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pistola()
    {
        pScript.apunP = true;
        pScript.apunE = false;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = pistola;
        transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        transform.localPosition=Position_Pistola;
        pScript.anim.SetTrigger("ApunP");

    }

    public void Escopeta()
    {
        pScript.apunP = false;
        pScript.apunE = true;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = escopeta;
        transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        transform.localPosition=Position_Escopeta;
        pScript.anim.SetTrigger("ApunE");
    }
}
