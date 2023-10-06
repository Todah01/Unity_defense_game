using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class Coodinatel_Labeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;

    private void Awake() {
        gridManager = FindObjectOfType<GridManager>();
        label = this.GetComponent<TextMeshPro>();
        label.enabled = false;

        DisplayCoodinates();
    }
    private void Update() {
        if(!Application.isPlaying){
            DisplayCoodinates();
            UpdateObjectName();
            label.enabled = true;
        }

        SetLabelColor();
        ToggleLabels();
    }
    void ToggleLabels(){
        if(Input.GetKeyDown(KeyCode.C)){
            label.enabled = !label.IsActive();
        }
    }

    private void SetLabelColor()
    {
        if(gridManager == null){ return; }

        Node node = gridManager.GetNode(coordinates);

        if(node == null){ return; }

        if(!node.isWalkable){
            label.color = blockedColor;
        }
        else if(node.isPath){
            label.color = pathColor;
        }
        else if(node.isExplored){
            label.color = exploredColor;
        }
        else{
            label.color = defaultColor;
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
