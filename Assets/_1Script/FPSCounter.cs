using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text fpsText; // Thêm Text UI để hiển thị FPS
    private float deltaTime = 0.0f;

    protected void wake()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        // Tính toán FPS
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;

        // Cập nhật Text hiển thị
        fpsText.text = Mathf.Ceil(fps).ToString() + " FPS";
        
    }
}
