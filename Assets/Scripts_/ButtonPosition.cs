using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonPosition : MonoBehaviour
{
    Scene scene;
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public RectTransform sampleListItem;
    public HorizontalLayoutGroup HLG;   
    int currentItem; 
    
    public void ButtonLocationFix()
    {
        scene = SceneManager.GetActiveScene();
        currentItem = scene.buildIndex;
        contentPanel.transform.position = new Vector3( 0-(currentItem * (sampleListItem.rect.width + HLG.spacing)),contentPanel.localPosition.y, contentPanel.localPosition.z);


    }
}
