using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager Instance;

        public List<ScriptableItem> _items;
        public List<BasicEnemy> enemies;
        public SpecialEnemy specialEnemy;

        // Total distances basic enemies travel along the x and y planes
        public int pathWidth;
        public int pathHeight;

        // How far we move along the x and y each time we update
        int xIncrement = 2;
        int yIncrement = 2;

        // Current coordiantes for the group
        public int initialX;
        public int initialY;
        int x;
        int y;
        bool goingRight = true;

        // How often the enemies move
        public float initialPeriod;
        public float period;
        public float lastMove;

        float timeToSpecialSpawn;

        // Enemy spacing
        int spaceBetweenEnemies = 3;
        int rowsOfEnemies = 5;
        int columnsOfEnemies = 10;

        private void Awake()
        {
            Instance = this;
        }

        // Use this for initialization
        void Start()
        {
            enemies = new List<BasicEnemy>();
            _items = Resources.LoadAll<ScriptableItem>("Items").ToList();
            timeToSpecialSpawn = Random.Range(20f, 40f);
        }

        // Update is called once per frame
        void Update()
        {
            timeToSpecialSpawn -= Time.deltaTime;
            if (timeToSpecialSpawn < 0)
            {
                timeToSpecialSpawn = Random.Range(20f, 40f);
                var enemyPrefab = _items.Where(u => u.itemType == ItemType.CoolEnemy).First().ItemPrefab;
                specialEnemy = (SpecialEnemy)Instantiate(enemyPrefab);
            }
            if (Time.time > lastMove + period)
            {
                lastMove = Time.time;

                // If we hit the end of the path, turn around and move down
                if (x >= pathWidth + initialX && goingRight)
                {
                    y -= yIncrement;
                    goingRight = false;
                }
                else if (x <= initialX && !goingRight)
                {
                    y -= yIncrement;
                    goingRight = true;
                }

                // Otherwise move sideways
                else if (goingRight)
                {
                    // Move right
                    x += xIncrement;
                                        
                }
                else
                {
                    x -= xIncrement;
                    
                }
                SetPositions();
            }
        }

        public void Reset()
        {
            x = initialX;
            y = initialY;
            period = initialPeriod;
            lastMove = Time.time;
            MakeEnemies();
            SetPositions();
        }

        public void NextLevel()
        {
            x = initialX;
            y = initialY;
            period = period*0.9f;
            lastMove = Time.time;
            MakeEnemies();
            SetPositions();
            GameManager.Instance.changeState(GameState.Playing);

        }


        // Creates all eneimes and adds them to a list
        public void MakeEnemies()
        {
            if (specialEnemy != null)
            {
                Destroy(specialEnemy.gameObject);
                specialEnemy = null;
            }

            for (int i = 0; i < columnsOfEnemies; i++)
            {
                for (int j = 0; j < rowsOfEnemies; j++)
                {
                    // Get an enemy prefab
                    var enemyPrefab = _items.Where(u => u.itemType == ItemType.BasicEnemy && u.ID == (j/2)).First().ItemPrefab;
                    BasicEnemy newEnemy = (BasicEnemy)Instantiate(enemyPrefab);

                    newEnemy.xOffset = i * spaceBetweenEnemies;
                    newEnemy.yOffset = j * spaceBetweenEnemies;
                    enemies.Add(newEnemy);
                }
            }
        }

        
        // Sets enemy positions
        private void SetPositions()
        {
            //Debug.Log("Moving enemies to " + x + ", " + y);

            foreach (var enemy in enemies)
            {
                enemy.SetPosition(x, y);
            }
        }


        // Returns current state
        public int CurrentState()
        {
            if ((y < initialY - pathHeight) && enemies.Count > 0)
            {
                // Enemies win
                return -1;
            }
            else if (enemies.Count <= 0)
            {
                // Player wins
                return 1;
            }
            else
            {
                // Standard play state
                return 0;
            }
        }
    }
}