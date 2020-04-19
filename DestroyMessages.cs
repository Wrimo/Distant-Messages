using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyMessages : MonoBehaviour
{
    void OnBecameInvisible()
    {
        GameObject.Destroy(this.gameObject);
    }
}
