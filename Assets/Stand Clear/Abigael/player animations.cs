using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;

    private bool pressedUp = true;
    private bool pressedSide = true;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        if (xInput != 0)
        {
            pressedUp = false;
            pressedSide = true;
            _animator.SetBool("walk down", false);
            _animator.SetBool("walk sideways", pressedSide);
            _animator.SetBool("walk up", pressedUp);
            _animator.SetBool("Horizontal arrow keys", pressedSide);
            _animator.SetBool("up arrow pressed", pressedUp);
            _animator.SetBool("down arrow pressed", false);
            _animator.SetBool("idle", false);
        }
        else if (yInput > 0)
        {
            pressedUp = true;
            pressedSide = false;
            _animator.SetBool("walk down", false);
            _animator.SetBool("walk sideways", pressedSide);
            _animator.SetBool("walk up", pressedUp);
            _animator.SetBool("Horizontal arrow keys", pressedSide);
            _animator.SetBool("up arrow pressed", pressedUp);
            _animator.SetBool("down arrow pressed", false);
            _animator.SetBool("idle", false);
        }
        else if (yInput < 0)
        {
            pressedUp = false;
            pressedSide = false;
            _animator.SetBool("walk down", true);
            _animator.SetBool("walk sideways", pressedSide);
            _animator.SetBool("walk up", pressedUp);
            _animator.SetBool("Horizontal arrow keys", pressedSide);
            _animator.SetBool("up arrow pressed", pressedUp);
            _animator.SetBool("down arrow pressed", true);
            _animator.SetBool("idle", false);
        }
        else
        {
            _animator.SetBool("walk down", false);
            _animator.SetBool("walk sideways", pressedSide);
            _animator.SetBool("walk up", pressedUp);
            _animator.SetBool("Horizontal arrow keys", pressedSide);
            _animator.SetBool("up arrow pressed", pressedUp);
            _animator.SetBool("down arrow pressed", false);
            _animator.SetBool("idle", true);
        }

        //if (yInput > 0 )
        // {
        // _animator.SetBool("walk up", true );
        //_animator.SetBool("up arrow pressed", true);

        // }
        // else
        // {
        // _animator.SetBool("walk up", false);
        //_animator.SetBool("up arrow pressed", false);
        //}

       // if (yInput < 0)
        //{
            //_animator.SetBool("walk down", true);
            //_animator.SetBool("down arrow pressed", true);

       // }
        //else
       // {
            //_animator.SetBool("walk down", false);
           // _animator.SetBool("down arrow pressed", false);
       // }
    }
}
