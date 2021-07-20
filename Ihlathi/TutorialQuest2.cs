using UnityEngine;

public class TutorialQuest2 : MonoBehaviour
{
    public QuestPointer pointer;
    private void Start()
    {
        pointer.Show(this.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Arrow")
        {
            transform.parent.GetComponent<TutorialManager>().NextQuest();
            pointer.Hide();
        }
    }
}
