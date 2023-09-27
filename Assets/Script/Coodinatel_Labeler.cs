using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class Coodinatel_Labeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    WayPoint wayPoint;

    private void Awake() {
        label = this.GetComponent<TextMeshPro>();
        label.enabled = false;

        wayPoint = this.GetComponentInParent<WayPoint>();  
        DisplayCoodinates();
    }
    private void Update() {
        if(!Application.isPlaying){
            DisplayCoodinates();
            UpdateObjectName();
        }

        ColorCoordinates();
        ToggleLabels();
    }
    void ToggleLabels(){
        if(Input.GetKeyDown(KeyCode.C)){
            label.enabled = !label.IsActive();
        }
    }

    private void ColorCoordinates()
    {
        if(wayPoint.IsPlaceable){
            label.color = defaultColor;
        }
        else{
            label.color = blockedColor;
        }
    }

    private void DisplayCoodinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.y);
        
        label.text = coordinates.x + " , " + coordinates.y;
    }

    private void UpdateObjectName(){
        transform.parent.name = coordinates.ToString();
    }
}
