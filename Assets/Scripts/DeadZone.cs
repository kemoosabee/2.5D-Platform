using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private Vector3 _respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _respawnPoint.x = other.transform.position.x;
        }
        CharacterController cc = other.GetComponent<CharacterController>();

    }

    public float SpawnAt()
    {
        return _respawnPoint.x;
    }
}
