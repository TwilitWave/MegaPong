using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour {

    // Static variables
    public static bool exists;

    // All the objects the game manager needs to see
    public PlayerController paddle1;
    public PlayerController paddle2;
    public Transform defBall;
    public Text scorePlayer1;
    public Text scorePlayer2;
    

    
    // All Serializable fields
    [SerializeField]
    private Vector3 player1StartPosition;

    [SerializeField]
    private Vector3 player2StartPosition;

    [SerializeField]
    private Vector3 ball1StarPosition;

    [SerializeField]
    private float leftSpawnBound;

    [SerializeField]
    private float rightSpawnBound;

    [SerializeField]
    private float topSpawnBound;

    [SerializeField]
    private float bottomSpawnBound;

    [SerializeField]
    private float startingBallSpeed;

    // All private, internal fields needed
    private int player1Score;
    private int player2Score;
    private List<Transform> balls;

    // Use this for initialization
    void Start () {
        if (!exists) {
            DontDestroyOnLoad(this.gameObject);
            balls = new List<Transform>();
            ChangeScore(1, 2);
            StartLevel();
        } else {
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)) {
            AddToScore(1);
        } else if (Input.GetKeyDown(KeyCode.S)) {
            AddToScore(2);
        }
    }

    // Start Level
    public void StartLevel() {
        ChangeScore(0, 0);
        RestartLevel();
    }

    // Restart Level
    public void RestartLevel() {
        if (balls.Count > 0) {
            balls.ForEach(DestroyTransform);
        }
        paddle1.transform.position = player1StartPosition;
        paddle2.transform.position = player2StartPosition;
        SpawnBall();
    }

    // Add to score
    public void AddToScore(int playerId) {
        if (playerId == 1) {
            player1Score += 1;
            scorePlayer1.text = player1Score.ToString();
        } else if (playerId == 2) {
            player2Score += 1;
            scorePlayer2.text = player2Score.ToString();
        } else {
            // Throw Error
            Debug.Log("You fool, that isn't a valid player ID!");
        }
    }

    // Change score
    public void ChangeScore(int player1Score, int player2Score) {
        this.player1Score = player1Score;
        this.player2Score = player2Score;
        scorePlayer1.text = player1Score.ToString();
        scorePlayer2.text = player2Score.ToString();
    }

    // Open Menu
    public void OpenEndLevelMenu(int winnerId) {

    }

    // Change Scene
    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    // Spawn New Ball
    public void SpawnBall() {
        float randX = Random.Range(leftSpawnBound, rightSpawnBound);
        float randY = Random.Range(bottomSpawnBound, topSpawnBound);
        float dirX = Random.Range(-1.0f, 1.0f);
        while (dirX == 0) {
            dirX = Random.Range(-1.0f, 1.0f);
        }
        float dirY = Random.Range(-1.0f, 1.0f);
        Vector3 startVelocity = startingBallSpeed * (new Vector3(dirX, dirY, 0)).normalized;
        Transform newBall = Instantiate(defBall, new Vector3(randX, randY, 0), Quaternion.identity);
        Debug.Log(startVelocity);
        newBall.GetComponent<BallScript>().SetVelocity(startVelocity);
        balls.Add(newBall);
    }

    // Player Die
    public void PlayerDies(int playerId) {
        int winnerId;
        if (playerId == 1) {
            winnerId = 2;
        }
        else if (playerId == 2) {
            winnerId = 1;
        }
        else {
            // Throw Error
            winnerId = 0;
            Debug.Log("You fool, that isn't a valid player ID!");
        }
        OpenEndLevelMenu(winnerId);
        AddToScore(winnerId);
        RestartLevel();
    }

    public void DestroyTransform(Transform tranform) {
        Destroy(transform.gameObject);
    }
    
}
