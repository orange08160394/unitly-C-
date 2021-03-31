using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorController : MonoBehaviour
{   // 宣告投影片陣列，要代入投影的Texture
    public Texture2D[] slides;  
    public int current;   // Inspector 會顯示目前投影片編號     
    Light comp;    
    void Start()
    {   // 產生 Texture2D 陣列物作件
        slides = new Texture2D[3];
        // 圖片置於 Resources 資料匣中,程式可以load出來使用
        slides[0]=Resources.Load<Texture2D>("Textures/Alita-1024x1024") ;
        slides[1] = Resources.Load<Texture2D>("Textures/Aquaman-1024x1024");
        slides[2] = Resources.Load<Texture2D>("Textures/Jessica-1024x1024") ;
        // 投影片編號設為 0
        current = 0;
        // 找到 Light Component
        comp = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            // 按下滑鼠左鍵時，選出前一張
            current = (current + slides.Length - 1) % slides.Length;
        else if (Input.GetMouseButtonDown(1))
            // 按下滑鼠右鍵時，選出下一張
            current = (current + 1) % slides.Length;
        // 將所選的投影片投射出來
        comp.cookie = slides[current];
        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        // 使用滑鼠 慢調 投影機的亮度(Range)
        // comp.range += Input.GetAxis("Mouse ScrollWheel");
        // 滑鼠滾輸 快調 投影機的亮度(Range)
        comp.range *= (Input.GetAxis("Mouse ScrollWheel") + 1.0f);

    }
}

