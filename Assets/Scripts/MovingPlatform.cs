using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    private float _speed = 2.0f;
    private bool _reachPointB = false;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_reachPointB == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
            if(transform.position == _targetB.position)
            {
                _reachPointB = true;
            }
        }

        if(_reachPointB == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
            if(transform.position == _targetA.position)
            {
                _reachPointB = false;
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }

    }

    private void OnTriggerExit(Collider other) {

        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
