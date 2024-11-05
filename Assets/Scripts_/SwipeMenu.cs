using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Loading;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class SwipeMenu : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public RectTransform sampleListItem;
    public HorizontalLayoutGroup HLG;
    public TMP_Text nameLabel;
    public string[] itemNames;
    bool isSnapped;
    public float snapForce;
    float snapSpeed;
    int currentItem;
    
    bool flag;
    UnityEngine.SceneManagement.Scene scene;
    void Start()
    {
        flag = false;
        isSnapped = false;
        
        
       // Debug.Log(itemNames.Length);
    }

    // Update is called once per frame
    void Update()
    {
       
        scene = SceneManager.GetActiveScene();
        currentItem = Mathf.RoundToInt(0-(contentPanel.localPosition.x / (sampleListItem.rect.width + HLG.spacing)));
       
        //Debug.Log(currentItem);

        //stoping scroll on the left last
        if(contentPanel.localPosition.x > 0)
        {
            contentPanel.localPosition = new Vector3((currentItem * (sampleListItem.rect.width + HLG.spacing))+10 * Time.deltaTime,0,0);
        }

        //stopping scroll on right last
        if(contentPanel.localPosition.x <= -760)
        {
            //Debug.Log("maxxxx");
            contentPanel.localPosition = new Vector3(0-((itemNames.Length-1) * (sampleListItem.rect.width + HLG.spacing))-10 * Time.deltaTime ,0,0);
            //Debug.Log((itemNames.Length-1) * (sampleListItem.rect.width + HLG.spacing));
        }

        //
        if(scrollRect.velocity.magnitude <200 && !isSnapped)
        {
            
            SnapObject();
            
            
            Debug.Log(currentItem);

            if(contentPanel.localPosition.x ==  0-(currentItem * (sampleListItem.rect.width + HLG.spacing)))
            {
                isSnapped = true;
            }
            
        }
        if(scrollRect.velocity.magnitude > 200)
        {
            nameLabel.text = "" ;
            isSnapped = false;
            snapSpeed = 0;
        }
            
    }
    public int SnapObject()
    {
        scrollRect.velocity = Vector2.zero;
            snapSpeed += snapForce * Time.deltaTime;
            contentPanel.localPosition = new Vector3(
                Mathf.MoveTowards(contentPanel.localPosition.x, 0-(currentItem * (sampleListItem.rect.width + HLG.spacing)),snapSpeed),
                contentPanel.localPosition.y,
                contentPanel.localPosition.z);
            nameLabel.text = itemNames[currentItem];
            //
            return currentItem;
    }

    //load the scene snaped to objct on button click
    public void OnButtonClick()
    {
        if(isSnapped)
        {
            SceneManager.LoadScene(currentItem);
            
        }
    }

}
