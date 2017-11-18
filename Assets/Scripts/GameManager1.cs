using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour {

    // All the objects the game manager needs to see
    public PlayerController paddle1;
    public PlayerController paddle2;
    //public Ball ball1;
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

    // All private, internal fields needed
    private int player1Score;
    private int player2Score;

    // Use this for initialization
    void Start () {
        ChangeScore(1, 2);
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
        paddle1.transform.position = player1StartPosition;
        paddle2.transform.position = player2StartPosition;
        //ball1.trasform.position = ball1StartPosition;
    }

    // Restart Level
    public void RestartLevel() {
        paddle1.transform.position = player1StartPosition;
        paddle2.transform.position = player2StartPosition;
        //ball1.trasform.position = ball1StartPosition;
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
    public void OpenMenu() {

    }

    // Change Scene
    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    // Spawn New Ball
    public void SpawnBall() {
        float randX = Random.Range(leftSpawnBound, rightSpawnBound);
        float randY = Random.Range(bottomSpawnBound, topSpawnBound);

    }

}
