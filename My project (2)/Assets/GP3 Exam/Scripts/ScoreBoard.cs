using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI scoreCountText;
    public TextMeshProUGUI WinText;
    public int score;

    public int OrbNum;
    public GameObject orbPrefab;
    public Vector2 randomXPos;
    public Vector2 randomZPos;

    void Start() 
    {
        for (int i = 0; i < OrbNum;) 
        {
            float xPos = Random.Range(randomXPos.x, randomXPos.y);
            float zPos = Random.Range(randomZPos.x, randomZPos.y);
            Vector3 rayPos = new Vector3 (xPos, 20, zPos);
            Ray ray = new Ray(rayPos, -transform.up);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 100))
            {
                Debug.Log(hitInfo.collider.gameObject.name);
                if (hitInfo.collider.gameObject.CompareTag("Floor"))
                {
                    i++;
                    Vector3 orbNewPos = new Vector3 (hitInfo.point.x, 1, hitInfo.point.z);
                    Instantiate(orbPrefab, orbNewPos, Quaternion.identity);
                }
            }
        }
    }

    public void ScoreCount() 
    {
        score++;
        scoreCountText.text = "Score: " + score;
        if (score == OrbNum) 
        {
            WinText.text = "You Win";
        }
    }


}
