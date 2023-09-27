using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    private void OnEnable() {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath(){
        path.Clear();

        GameObject[] wayPoints = GameObject.FindGameObjectsWithTag("Path");

        foreach(GameObject wayPoint in wayPoints){
            path.Add(wayPoint.GetComponent<WayPoint>());
        }
    }

    void ReturnToStart(){
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath(){
        foreach(WayPoint wayPoint in path){
            Vector3 startPosition = transform.position;
            Vector3 endPosition = wayPoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f){
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        gameObject.SetActive(false);
    }
}
