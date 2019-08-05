using UnityEngine;
using System.Collections;

public class Drive : MonoBehaviour {

    float speed = 5.0F;
    float rotationSpeed = 100.0F;
    Animator anim;

    void Start()
    {
    	anim = this.GetComponent<Animator>();
    }
    void Update() 
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        if(translation != 0)
        {
        	anim.SetBool("isWalking",true);
        }
        else
        {
        	anim.SetBool("isWalking",false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == strings.LEATHAL)
        {
            CapsuleCollider ownerCollider = GetComponent<CapsuleCollider>();
            ownerCollider.direction = 2;
            anim.SetBool(strings.IS_DYING, true);
            this.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
}
