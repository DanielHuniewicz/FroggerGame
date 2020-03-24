using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FrogPlayer : MonoBehaviour
{
    // Klasa postaci sterowanej przez gracza

    // Sprite postaci, jego pozycja oraz warunek czy jest zywy
    public Sprite frogLeft, frogRight, frogUp, frogDown, hurtSprite;
    public Vector2 spawnPosition;
    private bool isAlive = true;

    // Komponenty zwiazane z czasem i punktami
    public float setTime;
    private Timer timer;
    private UI ui;
    private Score sco;

    // Dołączone obiekty graficzne UI
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Dołączone obiekty graficzne UI
    public int points;
    public int numOfPoints;
    public Image[] pointsImg;
    public Sprite fullPoints;
    public Sprite emptyPoints;

    // Dołączone pliki, obiekty audio
    public AudioClip MusicClip_Jump;
    public AudioSource MusicSource_Jump;
    public AudioClip MusicClip_Death;
    public AudioSource MusicSource_Death;
    public AudioClip MusicClip_Hurt;
    public AudioSource MusicSource_Hurt;


    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        sco = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        MusicSource_Death.clip = MusicClip_Death;
        MusicSource_Jump.clip = MusicClip_Jump;
        MusicSource_Hurt.clip = MusicClip_Hurt;
    }

    void Update()
    {
        if (isAlive) 
        {
            Checkcol();
            UpdatePosition();
        }
        Health();
        Points();
    }

    // Funkcja sprawdzajaca pozycje gracza i zmieniajaca ją przy uzyciu klawiszy sterowania
    // funkcja ustala takze granice mozliwosci poruszania sie po mapie przez gracza oraz
    // generuje dzwieki i zmiane spritow przy wykonywaniu
    private void UpdatePosition() 
    {
        Vector2 pos = transform.localPosition;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().sprite = frogLeft;
            if (pos.x > -20) 
            {
                pos = pos + Vector2.left * 2;
                MusicSource_Jump.Play();
            }
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().sprite = frogRight;
            if (pos.x < 20)
            {
                pos = pos + Vector2.right * 2;
                MusicSource_Jump.Play();
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pos = pos + Vector2.up * 2;
            MusicSource_Jump.Play();
            GetComponent<SpriteRenderer>().sprite = frogUp;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<SpriteRenderer>().sprite = frogDown;
            pos = pos + Vector2.down * 2;
            MusicSource_Jump.Play();
        }
        transform.localPosition = pos;
    }

    // Funkcja wykonująca polecenia przy wejsciu w kolizje z punktem zwyciestwa (ląka)
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "victory") 
        {
            points -= 1;
            Debug.Log("Zdobyto punkt");
            Score.totallPointAmount += Score.pointAmount;
            Score.pointAmount = 0;
            sco.SpawnPoints();
            timer.maxTime = setTime;
            timer.timeLeft = setTime;
            transform.localPosition = spawnPosition;
        }
    }

    // Funkcja sprawdzajaca na jakim podlozu gracz sie znajduje, sprawdza ona czy gracz znajduje sie
    // w bezpiecznym polu, jesli nie nastepuje wykonanie funkcji LoseLife
    // Jesli podloze na ktorym gracz sie znajduje jest poruszajaca sie klodą bądz zółwiem to graczowi
    // nadaje sie pęd i kierunek tego obiektu
    private void Checkcol() 
    {
        bool isSafe = true;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("ColObject");

        foreach (GameObject go in gameObjects)
        {
            ObjectCol colObject = go.GetComponent<ObjectCol>();

            if (colObject.IsColliding(this.gameObject)) 
            {
                if (colObject.isSafe) 
                {
                    isSafe = true;

                    if (colObject.isLog) 
                    {
                        Debug.Log("Log");

                        Vector2 pos = transform.localPosition;

                        if (colObject.GetComponent<MovingObject>().moveRight)
                        {
                            pos.x += colObject.GetComponent<MovingObject>().moveSpeed * Time.deltaTime;
                        }
                        else
                        {
                            pos.x -= colObject.GetComponent<MovingObject>().moveSpeed * Time.deltaTime;
                        }

                        transform.localPosition = pos;
                    }
                    break;
                }
                else
                {
                    Debug.Log("River");
                    isSafe = false;
                }
            }
        }
        if (!isSafe)
        {
            LoseLife();
        }
    }

    // Funkcja zarządzania punktami zdrowia gracza
    // jesli gracz utraci N żyć aktywuje sie funcja Die()
    public void Health() {

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        if (health <= 0)
        {
            health = 0;
            Die();
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    // Funkcja zarządzania punktami zwyciestwa gracza analogiczna do punktow zycia
    // jesli gracz zdobedzie N punktów zwyciestwa aktywuje sie funkcja Win()
    public void Points()
    {
        if (points > numOfPoints)
        {
            points = numOfPoints;
        }

        if (points <= 0)
        {
            points = 0;
            Win();
        }

        for (int i = 0; i < pointsImg.Length; i++)
        {
            if (i < points)
            {
                pointsImg[i].sprite = fullPoints;
            }
            else
            {
                pointsImg[i].sprite = emptyPoints;
            }

            if (i < numOfPoints)
            {
                pointsImg[i].enabled = true;
            }
            else
            {
                pointsImg[i].enabled = false;
            }
        }
    }

    // Funkcja wykonująca polecenia w przypadku uplywu czasu
    public void TimeUp() 
    {
        Debug.Log("TimeUp");
        MusicSource_Hurt.Play();
        health -= 1;
        GetComponent<SpriteRenderer>().sprite = frogUp;
        transform.localPosition = spawnPosition;
        timer.maxTime = setTime;
        timer.timeLeft = setTime;
        sco.SpawnPoints();
        Score.pointAmount = 0;
    }

    // Funkcja wykonująca polecenia w przypadku utraty zdrowia
    public void LoseLife() 
    {
        Debug.Log("Hurt");
        isAlive = false;
        GetComponent<SpriteRenderer>().sprite = hurtSprite; 
        MusicSource_Hurt.Play();
        health -= 1;
        ExecuteAfterTime();
        sco.SpawnPoints();
        Score.pointAmount = 0;
        StartCoroutine(ExecuteAfterTime());
    }

    // Funkcja wykonująca polecenia z zapasem czasowym
    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(1);
        isAlive = true;
        GetComponent<SpriteRenderer>().sprite = frogUp;
        transform.localPosition = spawnPosition;
        timer.maxTime = setTime;
        timer.timeLeft = setTime;
        Debug.Log("Spwan");  
    }

    // Funkcja aktywująca panel game over
    public void Die() 
    {
        Debug.Log("Game over");
        ui.LosePanel();
        isAlive = false;
        transform.localPosition = spawnPosition;
    }

    // Funkcja aktywująca panel Win
    public void Win()
    {
        Debug.Log("Super");
        ui.WinGamePanel();
    }
}

