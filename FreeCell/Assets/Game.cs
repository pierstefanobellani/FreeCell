using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Game : MonoBehaviour
{

    public GameObject card;
    Text header;
    Text main;

    List<GameObject> clubs;
    List<GameObject> diamonds;
    List<GameObject> hearts;
    List<GameObject> spades;
    List<GameObject> deck;
    public List<GameObject> shuffleDeck;

    bool gameStarted = false;
    GameObject canvas;

    Vector3 mousePos;  
    Vector2 localMousePosition;

    List<GameObject> firstColumn;
    List<GameObject> secondColumn;
    List<GameObject> thirdColumn;
    List<GameObject> fourthColumn;
    List<GameObject> fifthColumn;
    List<GameObject> sixthColumn;
    List<GameObject> seventhColumn;
    List<GameObject> eighthColumn;
    


    // Start is called before the first frame update
    void Awake()
    {
        header = card.transform.GetChild(0).GetComponent<Text>();
        main = card.transform.GetChild(1).GetComponent<Text>();
    }

    void Start() {
        canvas = GameObject.Find("Canvas");
        mousePos = Input.mousePosition;

        clubs = new List<GameObject>();
        diamonds = new List<GameObject>();
        spades = new List<GameObject>();
        hearts = new List<GameObject>();

        deck = new List<GameObject>();
        shuffleDeck = new List<GameObject>();

        firstColumn = new List<GameObject>();
        secondColumn = new List<GameObject>();
        thirdColumn = new List<GameObject>();
        fourthColumn = new List<GameObject>();
        fifthColumn = new List<GameObject>();
        sixthColumn = new List<GameObject>();
        seventhColumn = new List<GameObject>();
        eighthColumn = new List<GameObject>();

        //create subsets
        for (int i=1; i<14; i++) {
            header.text = "clubs " + i.ToString();
            main.text = "clubs " + i.ToString();
            header.color = Color.black;
            main.color = Color.black;
            clubs.Add(card);
        }

        for (int i=1; i<14; i++) {
            header.text = "diamonds " + i.ToString();
            main.text = "diamonds " + i.ToString();
            header.color = Color.red;
            main.color = Color.red;
            diamonds.Add(card);
        }

        for (int i=1; i<14; i++) {
            header.text = "spades " + i.ToString();
            main.text = "spades " + i.ToString();
            header.color = Color.black;
            main.color = Color.black;
            spades.Add(card);
        }

        for (int i=1; i<14; i++) {
            header.text = "hearts " + i.ToString();
            main.text = "hearts " + i.ToString();
            header.color = Color.red;
            main.color = Color.red;
            hearts.Add(card);
        }

        //create deck
        deck = clubs.Concat(diamonds).Concat(hearts).Concat(spades).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStarted)
        {
                localMousePosition = GameObject.FindWithTag("CardSample").GetComponent<RectTransform>().InverseTransformPoint(Input.mousePosition);
                if (GameObject.FindWithTag("CardSample").GetComponent<RectTransform>().rect.Contains(localMousePosition) && Input.GetMouseButton(0))
                {
                    Debug.Log("ciao");
                    firstColumn[firstColumn.Count-1].transform.position = Input.mousePosition;
                    //GameObject.FindWithTag("CardSample").transform.position = Input.mousePosition;
                }
         
        }   
    }

    public void ShuffleDeck() {
        //shuffle deck
        shuffleDeck = deck.OrderBy( x => Random.value ).ToList();

        SpawnCards();
    }

    void SpawnCards() {
        if (gameStarted) {
            //remove prevoiusly instantiated cards
            foreach (GameObject card in GameObject.FindGameObjectsWithTag("CardSample")) {
                Destroy(card);
            }
        }

        firstColumn = shuffleDeck.GetRange(0,7);
        secondColumn = shuffleDeck.GetRange(7,7);
        thirdColumn = shuffleDeck.GetRange(14,7);
        fourthColumn = shuffleDeck.GetRange(21,7);
        fifthColumn = shuffleDeck.GetRange(28,6);
        sixthColumn = shuffleDeck.GetRange(34,6);
        seventhColumn = shuffleDeck.GetRange(40,6);
        eighthColumn = shuffleDeck.GetRange(46,6);

        for(int i=0; i<firstColumn.Count; i++) { 
            Instantiate(shuffleDeck[i], new Vector3(-525+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }
        for(int i=0; i<secondColumn.Count; i++) { 
            Instantiate(shuffleDeck[i], new Vector3(-375+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }
        for(int i=0; i<thirdColumn.Count; i++) { 
            Instantiate(shuffleDeck[i], new Vector3(-225+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }
        for(int i=0; i<fourthColumn.Count; i++) { 
            Instantiate(shuffleDeck[i], new Vector3(-75+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }
        for(int i=0; i<fifthColumn.Count; i++) { 
            Instantiate(shuffleDeck[i], new Vector3(75+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }
        for(int i=0; i<sixthColumn.Count; i++) { 
            Instantiate(shuffleDeck[i], new Vector3(225+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }
        for(int i=0; i<seventhColumn.Count; i++) { 
            Instantiate(shuffleDeck[i], new Vector3(375+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }
        for(int i=0; i<eighthColumn.Count; i++) { 
            Instantiate(shuffleDeck[i], new Vector3(525+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }

        gameStarted = true;
    }
}
