using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

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
    List<GameObject> shuffleDeck;

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
            GameObject inst = Instantiate(card, new Vector3((canvas.GetComponent<RectTransform>().sizeDelta.x/2),380+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
            clubs.Add(inst);
        }

        for (int i=1; i<14; i++) {
            header.text = "diamonds " + i.ToString();
            main.text = "diamonds " + i.ToString();
            header.color = Color.red;
            main.color = Color.red;
            GameObject inst = Instantiate(card, new Vector3((canvas.GetComponent<RectTransform>().sizeDelta.x/2),380+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
            diamonds.Add(inst);
        }

        for (int i=1; i<14; i++) {
            header.text = "spades " + i.ToString();
            main.text = "spades " + i.ToString();
            header.color = Color.black;
            main.color = Color.black;
            GameObject inst = Instantiate(card, new Vector3((canvas.GetComponent<RectTransform>().sizeDelta.x/2),380+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
            spades.Add(inst);
        }

        //sth wrong here...
        for (int i=1; i<14; i++) {
            header.text = "hearts " + i.ToString();
            main.text = "hearts " + i.ToString();
            header.color = Color.red;
            main.color = Color.red;
            GameObject inst = Instantiate(card, new Vector3((canvas.GetComponent<RectTransform>().sizeDelta.x/2),380+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
            hearts.Add(inst); //probably here, not sure
        }

        //create deck
        deck = clubs.Concat(diamonds).Concat(hearts).Concat(spades).ToList();
        /*for(int i=0; i<deck.Count; i++){
            Debug.Log(deck[i].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        }*/
        
        ShuffleDeck();
    }

    void Update()
    {
        if(gameStarted)
        {
            /*if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Over UI elements");
            }*/

            GameObject[] cards = GameObject.FindGameObjectsWithTag("CardSample");//improve for the right below card, not all
            for(int i=0; i< cards.Length; i++) {
                localMousePosition = cards[i].GetComponent<RectTransform>().InverseTransformPoint(Input.mousePosition);
                    if (cards[i].GetComponent<RectTransform>().rect.Contains(localMousePosition) && Input.GetMouseButton(0))
                {
                    cards[i].transform.position = Input.mousePosition;
                }
            }

            //check if the last card chars are numbers, if is a 1, you can move it to the foundation
            //else you can move it to the freecell only

            //check if the card is black o red
            //check if you're moving it over one of the same color
            
        }   
    }

    public void ShuffleDeck() {
        //shuffle deck
        //shuffleDeck = deck.OrderBy( x => Random.value ).ToList(); //not actually working
        for (int i = 0; i < deck.Count; i++) {
            var temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
        shuffleDeck = deck;
        
        /*for(int i=0; i<shuffleDeck.Count; i++){
            Debug.Log(shuffleDeck[i].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text);
        }*/
        SpawnCards();
    }

    void SpawnCards() {
        if (gameStarted) {
            //remove prevoiusly instantiated cards
            foreach (GameObject card in GameObject.FindGameObjectsWithTag("CardSample")) {
                Destroy(card);
            }
        }

        //create columns
        firstColumn = shuffleDeck.GetRange(0,7);
        secondColumn = shuffleDeck.GetRange(7,7);
        thirdColumn = shuffleDeck.GetRange(14,7);
        fourthColumn = shuffleDeck.GetRange(21,7);
        fifthColumn = shuffleDeck.GetRange(28,6);
        sixthColumn = shuffleDeck.GetRange(34,6);
        seventhColumn = shuffleDeck.GetRange(40,6);
        eighthColumn = shuffleDeck.GetRange(46,6);

        for(int i=0; i<firstColumn.Count; i++) { 
            //Debug.Log(firstColumn[i].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text);
            Instantiate(firstColumn[i], new Vector3(-525+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }
        for(int i=0; i<secondColumn.Count; i++) {
            //Debug.Log(secondColumn[i].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text); 
            Instantiate(secondColumn[i], new Vector3(-375+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }
        for(int i=0; i<thirdColumn.Count; i++) { 
            Instantiate(thirdColumn[i], new Vector3(-225+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }
        for(int i=0; i<fourthColumn.Count; i++) { 
            Instantiate(fourthColumn[i], new Vector3(-75+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }
        for(int i=0; i<fifthColumn.Count; i++) { 
            Instantiate(fifthColumn[i], new Vector3(75+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }
        for(int i=0; i<sixthColumn.Count; i++) { 
            Instantiate(sixthColumn[i], new Vector3(225+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }
        for(int i=0; i<seventhColumn.Count; i++) { 
            Instantiate(seventhColumn[i], new Vector3(375+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }
        for(int i=0; i<eighthColumn.Count; i++) { 
            Instantiate(eighthColumn[i], new Vector3(525+(canvas.GetComponent<RectTransform>().sizeDelta.x/2),157-(20*i)+(canvas.GetComponent<RectTransform>().sizeDelta.y/2),0), Quaternion.identity, canvas.transform);
        }

        gameStarted = true;
    }
}
