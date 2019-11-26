using Assets.Scripts.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject A_grass;
    public GameObject a_roadcross2;
    public GameObject b_roadendhor1;
    public GameObject c_roadendhor1left;
    public GameObject D_grassflower1;
    public GameObject d_roadendhor2;
    public GameObject E_grassflower2;
    public GameObject e_roadendhor2;
    public GameObject f_roadendver1;
    public GameObject G_grassmushrooms;
    public GameObject g_roadendver1down;
    public GameObject h_roadendver2;
    public GameObject H_tree;
    public GameObject i_roadendver2down;
    public GameObject I_treemagical;
    public GameObject j_roadmiddlehor;
    public GameObject J_treerock;
    public GameObject K_treerockautum;
    public GameObject k_roadmiddlehor2;
    public GameObject l_roadmiddlever1;
    public GameObject L_treerockmagical;
    public GameObject m_roadmiddlever2;
    public GameObject M_treestump;
    public GameObject N_twotrees;
    public GameObject O_twotreesautum;
    public GameObject P_twotreesmagical;
    public GameObject Q_twotreestreestumps;
    public GameObject R_roadcorner;
    public GameObject T_roadcornerright;
    public GameObject W_roadcorner2;
    public GameObject X_roadcorner2left;
    public GameObject Z_roadcross;
    public GameObject PlayerPrefab;
    public GameObject MorahPrefab;
    public GameObject LionelPrefab;
    public GameObject YuyuPrefab;
    public GameObject Enemy1Prefab;
    public GameObject ChestBananaPrefab;
    public GameObject ChestCherryPrefab;
    public GameObject ChestGrapePrefab;
    public GameObject ChestLemonPrefab;
    public GameObject ChestOrangePrefab;
    public GameObject ChestSeaweedPrefab;

    private Dictionary<char, GameObject> TilesPrefabs;
    private Dictionary<string, GameObject> CharactersPrefabs;
    private Dictionary<string, GameObject> ItemsPrefabs;

    private void Awake()
    {
        TilesPrefabs = new Dictionary<char, GameObject>
        {
            { 'A', A_grass},
            { 'a', a_roadcross2},
            { 'b',  b_roadendhor1},
            { 'c',  c_roadendhor1left},
            { 'D',  D_grassflower1},
            { 'd',  d_roadendhor2},
            { 'E',  E_grassflower2},
            { 'e',  e_roadendhor2},
            { 'f',  f_roadendver1},
            { 'G',  G_grassmushrooms},
            { 'g',  g_roadendver1down},
            { 'h',  h_roadendver2},
            { 'H',  H_tree},
            { 'i',  i_roadendver2down},
            { 'I',  I_treemagical},
            { 'j',  j_roadmiddlehor},
            { 'J',  J_treerock},
            { 'K',  K_treerockautum},
            { 'k',  k_roadmiddlehor2},
            { 'l',  l_roadmiddlever1},
            { 'L',  L_treerockmagical},
            { 'm',  m_roadmiddlever2},
            { 'M',  M_treestump},
            { 'N',  N_twotrees},
            { 'O',  O_twotreesautum},
            { 'P',  P_twotreesmagical},
            { 'Q',  Q_twotreestreestumps},
            { 'R',  R_roadcorner},
            { 'T',  T_roadcornerright},
            { 'W',  W_roadcorner2},
            { 'X',  X_roadcorner2left},
            { 'Z',  Z_roadcross}
        };

        CharactersPrefabs = new Dictionary<string, GameObject>
        {
            { "Player", PlayerPrefab },
            { "Morah", MorahPrefab },
            { "Lionel", LionelPrefab },
            { "Yuyu", YuyuPrefab },
            { "Enemy1", Enemy1Prefab }
        };

        ItemsPrefabs = new Dictionary<string, GameObject>
        {
            { "ChestBanana", ChestBananaPrefab },
            { "ChestCherry", ChestCherryPrefab },
            { "ChestGrape", ChestGrapePrefab },
            { "ChestLemon", ChestLemonPrefab },
            { "ChestOrange", ChestOrangePrefab },
            { "ChestSeaweed", ChestSeaweedPrefab }
        };
    }

    XmlDocument xmlDoc;
    // Start is called before the first frame update
    void Start()
    {
        Game.CurrentLevel = new Level();

        xmlDoc = new XmlDocument();
        
        xmlDoc.LoadXml(Resources.Load<TextAsset>("Level1").text);

        InitializeMap();
        LoadMap(0, 71, 0, 40);
        LoadCharacters();
        LoadItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeMap()
    {
        XmlNode mapNode = xmlDoc.SelectSingleNode("/level/map");
        Game.CurrentLevel.Map = new Map(
            System.Convert.ToInt32(mapNode.Attributes["width"].Value), 
            System.Convert.ToInt32(mapNode.Attributes["height"].Value), 
            System.Convert.ToInt32(mapNode.Attributes["tilewidth"].Value), 
            System.Convert.ToInt32(mapNode.Attributes["tileheight"].Value));
    }

    public void LoadMap(int xFrom, int xTo, int yFrom, int yTo)
    {
        int xFromCopy = xFrom;
        Tile newTile;
        foreach(XmlNode currentNode in xmlDoc.SelectNodes(string.Format("//level/map/row[position() >= {0} and position() <= {1}]", yFrom, yTo)))
        {
            for(xFrom = xFromCopy; xFrom <= xTo; xFrom++)
            {
                newTile = new Tile(TilesPrefabs[currentNode.InnerText[xFrom]], currentNode.InnerText[xFrom] + "," + xFrom.ToString() + "," + yFrom, xFrom, yFrom);
                Game.CurrentLevel.Map.Tiles.Add(newTile);
            }
            yFrom++;
        }
    }

    public void LoadCharacters()
    {
        Game.CurrentLevel.Characters = new List<Character>();

        Character newCharacter;
        foreach (XmlNode currentNode in xmlDoc.SelectNodes("//level/characters/character"))
        {
            newCharacter = new Character(System.Convert.ToInt32(currentNode.Attributes["id"].Value),
                                    currentNode.Attributes["prefabName"].Value,
                                    currentNode.Attributes["tag"].Value,
                                    CharactersPrefabs[currentNode.Attributes["prefabName"].Value],
                                    currentNode.Attributes["uniqueObjectName"].Value,
                                    System.Convert.ToSingle(currentNode.Attributes["posX"].Value),
                                    System.Convert.ToSingle(currentNode.Attributes["posY"].Value));
            Game.CurrentLevel.Characters.Add(newCharacter);
        }
    }

    public void LoadItems()
    {
        Game.CurrentLevel.Items = new List<Item>();

        Item newItem;
        foreach (XmlNode currentNode in xmlDoc.SelectNodes("//level/items/item"))
        {
            newItem = new Item(System.Convert.ToInt32(currentNode.Attributes["id"].Value),
                                    currentNode.Attributes["prefabName"].Value,
                                    currentNode.Attributes["tag"].Value,
                                    ItemsPrefabs[currentNode.Attributes["prefabName"].Value],
                                    currentNode.Attributes["uniqueObjectName"].Value,
                                    System.Convert.ToSingle(currentNode.Attributes["posX"].Value),
                                    System.Convert.ToSingle(currentNode.Attributes["posY"].Value));
            Game.CurrentLevel.Items.Add(newItem);
        }
    }
}
