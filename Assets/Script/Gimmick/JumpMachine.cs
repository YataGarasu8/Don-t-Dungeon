using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMachine : MonoBehaviour
{
    public Player _player;
    public float jumpForce;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _player.GetComponent<Rigidbody>().AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }
}
