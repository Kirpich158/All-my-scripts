using UnityEngine;

public class TutorialQuest4 : MonoBehaviour
{
    public ChestObject chest;
    private bool isAnArea = false;

    public QuestPointer pointer;
    private void Start()
    {
        pointer.Show(this.transform.position);
    }

    private void Update()
    {
        if(isAnArea && Input.GetKeyDown(KeyCode.F))
        {
            transform.parent.GetComponent<TutorialManager>().NextQuest();
            pointer.Hide();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isAnArea = true;
            chest.isOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isAnArea = false;
        }
    }
}
