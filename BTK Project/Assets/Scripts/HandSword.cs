using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSword : MonoBehaviour
{
    public GameObject handBone, player, spineBone;
    public bool attackState;
    public Vector3 offset, r_offset;
  

    // Start is called before the first frame update

    private void Start()
    {
        transform.parent = player.transform;
        offset = new Vector3(0, -0.05f, 0);
    }

    IEnumerator HandlingSword ()
    {
        while (true)
        {
            transform.position = handBone.transform.position;
            yield return new WaitForSeconds(0.01f);
            if (Input.GetKeyDown(KeyCode.E))
            {
                break;
            }
            
        }
    }

    IEnumerator SpineSword()
    {
        while (true)
        {
            transform.position = spineBone.transform.position + offset;
            transform.rotation = Quaternion.Euler(-180, 90, 0);
            yield return new WaitForSeconds(0.01f);
            if (Input.GetKeyDown(KeyCode.E))
            {
                break;
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (attackState == true)
            {
                StartCoroutine(SpineSword());
                attackState = false;
            }
            else
            {
                StartCoroutine(HandlingSword());
                attackState = true;
            }
        }
        
    }
}
