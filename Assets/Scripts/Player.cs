using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 6.0f;
    [SerializeField]
    private float _jumpSpeed = 8.0f;
    [SerializeField]
    private float _gravity = 20.0f;
    private bool _jumpSwitch = false;
    [SerializeField]
    private int _lives = 3;
    private CharacterController _controller;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 _spawnPlace = new Vector3(-8,0,0);
    private UIManager _um;
    private DeadZone _deadZone;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _um = GameObject.Find("Canvas").GetComponent<UIManager>();
        _deadZone = GameObject.Find("DeadZone").GetComponent<DeadZone>();
        transform.position = _spawnPlace;
    }

    // Update is called once per frame
    void Update()
    {
        if(_controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"),0.0f,0.0f);
            moveDirection *= _speed;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = _jumpSpeed;
                _jumpSwitch = true;
            }
        }
        else if(_jumpSwitch == true && Input.GetKeyDown(KeyCode.Space))
        {
            moveDirection.y += _jumpSpeed * 1.3f;
            _jumpSwitch = false;
        }

        moveDirection.y -= _gravity * Time.deltaTime;
        _controller.Move(moveDirection * Time.deltaTime);
        UpdatePlayerLive();
    }

    void UpdatePlayerLive()
    {
        if(transform.position.y <= -10)
        {
            _controller.enabled = false;
            transform.position = new Vector3(_deadZone.SpawnAt(),10,0);
            StartCoroutine(CCEnableRoutine(_controller));
            _lives--;
            _um.MinusHP(_lives);
        }
    }

    IEnumerator CCEnableRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(0.5f);
        controller.enabled = true;
    }
}
