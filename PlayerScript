//# Unity-Game-Code
//Zig_Zag_Clone_Game

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour {

    public float speed;

    private Vector3 dir;

    public GameObject ps;

    private bool isDead;

    public GameObject resetBtn;

    private int score = 0;

    public Text scoreText;

    public Animator gameOverAnim;

   // public Text lastScoreText;

   // public Text bestText;

    public Text newHighScore;

    public Image background;

    public Text[] scoreTexts;

    public LayerMask whatIsGround;

    private bool isPlaying = false; 

    public Transform contactPoint; 


    // Use this for initialization
    void Start()
    {

       
        isDead = false;
        dir = Vector3.zero;


    }

    // Update is called once per frame
    void Update()
    {

        if (!IsGrounded() && isPlaying)
        {

             isDead = true;

             GameOver();

             resetBtn.SetActive(true);

            if (transform.childCount > 0)
            {
                 transform.GetChild(0).transform.parent = null;
            }

        }


        if (Input.GetMouseButtonDown(0) && !isDead)
        {

            isPlaying = true; 
            score++;
            scoreText.text = score.ToString();

            if (dir == Vector3.forward)
            {
                dir = Vector3.left;
            }
            else
            {
                dir = Vector3.forward;
            }
        }


        float amountToMove = speed * Time.deltaTime;
        transform.Translate(dir * amountToMove);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.identity);
            score += 3;
            scoreText.text = score.ToString();
            CombatTextManager.Instance.CreateText(other.transform.position, "+3", Color.magenta);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //if (other.tag == "Tile")
        //{
        //    RaycastHit hit;

        //    Ray downRay = new Ray(transform.position, -Vector3.up);

        //    if (!Physics.Raycast(downRay, out hit))
        //    {
        //        isDead = true;

        //        GameOver();

        //        resetBtn.SetActive(true);

        //        if (transform.childCount > 0)
        //        {
        //            transform.GetChild(0).transform.parent = null;
        //        }
                  
        //    }
        //}
    }


    private void GameOver()
    {
        gameOverAnim.SetTrigger("GameOver");

        scoreTexts[1].text = score.ToString(); 

       

        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            newHighScore.gameObject.SetActive(true);
            background.color = new Color32(255, 188, 246, 255);
            foreach (Text txt in scoreTexts)
            {
                txt.color = Color.white; 

            }
        }

        scoreTexts[3].text = PlayerPrefs.GetInt("BestScore",0).ToString();
    }

    private bool IsGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(contactPoint.position, .5f, whatIsGround);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                return true;

            }

        }

        return false; 

    }

}

