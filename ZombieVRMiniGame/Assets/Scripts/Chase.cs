using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chase : MonoBehaviour
{
    float RotationSpeed = 1f;
    Animator anim;
    
    bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        if (this.gameObject.tag == "zombie")
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.45f, this.transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            anim.SetTrigger("hit");
            dead = true;
            this.GetComponent<Collider>().enabled = false;
            IsShot();
            Destroy(other.gameObject);
            Destroy(this.gameObject,3);
            

        }
        if (other.gameObject.tag == "Player")
        {
            ScoreManager.instance.LoseLife();
            Destroy(this.gameObject,0.1f); 
        }
    }
    public void IsShot()
    {
        ScoreManager.instance.AddScore(1);
    }
    // Update is called once per frame
    void Update()
    {

        if (dead) return;
        Vector3 direction = Camera.main.transform.position - this.transform.position;
        direction.y = 0f;
        
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction),RotationSpeed*Time.deltaTime);
    }
}
