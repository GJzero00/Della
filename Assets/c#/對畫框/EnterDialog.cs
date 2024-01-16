using UnityEngine;

public class EnterDialog : MonoBehaviour
{
    public GameObject enterDialog;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" )
        {
            enterDialog.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            enterDialog.SetActive(false);
        }
    }
}
