using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float health;
    public float speed;
    public float score;
    public float sprint;
    
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI sprintText;
    public Button damage;
    public Button healing;
    public Button spacePressed;

    private void Start()
    {
        InitializeUIValues();
    }

    private void InitializeUIValues()
    {
        health = 100;
        score = 10000;
        speed = 0;
        sprint = 0;
    }

    private void UpdateHealthText()
    {
        healthText.text = "Health: " + health; 
    }
    
    private void UpdateSpeedText()
    {
        speedText.text = "Speed: " + speed; 
    }
    
    private void UpdateSprintText()
    {
        sprintText.text = "Sprint: " + sprint; 
    }
    
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; 
    }
    
    // boton izq mouse presionado
    // Reducir health en 5
    // Reducir score en 100
    // Cambiar el color del boton Damage a rojo
    
    
    // Suscribirse a LeftMouseButtonPressed
    // Cuando presione el boton izquierdo del mouse
    // llamar a LeftMouseButtonPressed
    public void LeftMouseButtonPressed()
    {
        health -= 5;
        UpdateHealthText();
        score -= 100;
        UpdateScoreText();
    }
    
    
    // Botón derecho del mouse presionado
    // Aumentar health en 5
    // Aumentar score en 100
    // Cambiar el color del boton Healing a verde
    // Sonido de coin en Play
    // Tecla espacio presionada
    // Aumentar speed en 1
    // Si el valor de Speed es múltiplo de 5, asignar ese valor a Sprint
    // Cambiar el color del boton Space Pressed a Azul
    // Sonido de step en Play

}
