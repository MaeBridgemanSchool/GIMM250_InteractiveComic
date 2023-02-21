using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMover : MonoBehaviour
{

    public enum Type {Proton, Neutron, Electron, All}
    public Type type;
    public GameObject particles;

    public InteractionManager im;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<InteractiveArea>() != null)
        {
            InteractiveArea area = collision.transform.GetComponent<InteractiveArea>();
            if (area.accepts == type || area.accepts == Type.All)
            {
                Match();
            }
        }
    }

    bool held;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            held = true;
        }
    }

    void Update()
    {
        if (held)
        {
            transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, 0);
            if (Input.GetMouseButtonUp(0)) held = false;
        }
    }

    public void Match()
    {
        //particles
        GameObject p = Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(p, 5f);
        im.NewMatch();
        Destroy(this.gameObject);
    }
}
