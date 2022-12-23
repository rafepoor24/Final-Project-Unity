using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGranade : MonoBehaviour
{
    [SerializeField] private float throwForce = 500;
    [SerializeField] private GameObject granadePrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Throw ();
        }
    }
    public void Throw()
    {
        GameObject newGranade = Instantiate(granadePrefab, transform.position, transform.rotation);
        newGranade.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
        
    }
}
