using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    public GameObject explosion;
    void OnCollisionEnter(){
     GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
     
 }
}
