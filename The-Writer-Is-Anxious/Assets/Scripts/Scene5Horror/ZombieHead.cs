using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHead : MonoBehaviour
{
    void OnMouseDown()
    {
        Player_Horror.instance.horrorDialogue.PrincessKillDialogue();
        Destroy(gameObject.transform.parent.gameObject);
    }
}
