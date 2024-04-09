using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = .5f;
    Animator myAnimator;
   
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Moves the object forward two units.
            this.transform.Translate(new Vector3(0, 0, 2f) * Time.deltaTime * speed);
            myAnimator.SetBool("isRurning", true);

        }
        else
        {
            myAnimator.SetBool("isRurning", false);
        }
    }
}
