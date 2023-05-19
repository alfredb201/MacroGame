using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAnimator != null)
        {
            if (Input.GetButton("Fire1"))
            {
                playerAnimator.SetTrigger("AttackOn");
                playerAnimator.SetTrigger("AttackOff");
            }
        }
    }
}
