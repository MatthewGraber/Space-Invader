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

        // Total distances basic enemies travel along the x and y planes
        int pathWidth = 40;
        int pathHeight = 20;

        // How far we move along the x and y each time we update
        int xIncrement = 2;
        int yIncrement = 2;

        // Current coordiantes for the group
        int initialX = -30;
        int initialY = 0;
        public int x;
        public int y;
        bool goingRight = true;

        // How often the enemies move
        public float initialPeriod = 5f;
        public float period;
        public float lastMove;

        // Enemy spacing
        int spaceBetweenEnemies = 5;
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

        }

        // Update is called once per frame
        void Update()
        {
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
            for (int i = 0; i < columnsOfEnemies; i++)
            {
                for (int j = 0; j < rowsOfEnemies; j++)
                {
                    // Get an enemy prefab
                    // TODO: Make it systematic, not random
                    var enemyPrefab = _items.Where(u => u.itemType == ItemType.BasicEnemy).OrderBy(o => UnityEngine.Random.value).First().ItemPrefab;
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
            Debug.Log("Moving enemies to " + x + ", " + y);

            foreach (var enemy in enemies)
            {
                enemy.SetPosition(x, y);
            }
        }


        // Returns current state
        public int CurrentState()
        {
            if (y > initialY - pathHeight && enemies.Count > 0)
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