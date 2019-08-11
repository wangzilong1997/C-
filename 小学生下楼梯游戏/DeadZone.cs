using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("玩家")) {
            Player.isDead = true;
            //Debug.Break();
        }
    }
}
