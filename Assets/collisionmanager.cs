using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class collisionmanager : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 0.5f;
    private bool hasPackage;

    [SerializeField] Color32 packagePicker = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackagePicker = new Color32(1,1,1,1);

    SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Picked up Package");
            hasPackage = true;
            _spriteRenderer.color = packagePicker;
            Destroy(other.gameObject, destroyDelay);
        }
        
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered Package");
            _spriteRenderer.color = noPackagePicker;
            hasPackage = false;
        }
    }
}
