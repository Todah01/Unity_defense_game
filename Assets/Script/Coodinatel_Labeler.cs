using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class Coodinatel_Labeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    private void Awake() {
        label = this.GetComponent<TextMeshPro>();  
        DisplayCoodinates();  
    }
    private void Update() {
        if(!Application.isPlaying){
            DisplayCoodinates();
            UpdateObjectName();
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
