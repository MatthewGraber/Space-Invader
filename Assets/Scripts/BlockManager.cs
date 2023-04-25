using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

namespace Assets.Scripts
{
    public class BlockManager : MonoBehaviour
    {
        public static BlockManager Instance;
        List<Block> blocks = new List<Block>();
        List<ScriptableItem> _items;


        public int blockSize;
        public int y;

        // Use this for initialization
        void Start()
        {
            Instance = this;
            _items = Resources.LoadAll<ScriptableItem>("Items").ToList();
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void SpawnBlocks()
        {
            blocks = new List<Block>();
            SpawnBlockSet(-40);
            SpawnBlockSet(-20);
            SpawnBlockSet(0);
            SpawnBlockSet(20);
            SpawnBlockSet(40);

        }


        void SpawnBlockSet(int x)
        {
            NewBlock().transform.position = new Vector3(x, y, 1.0f);
            NewBlock().transform.position = new Vector3(x - blockSize, y, 1.0f);
            NewBlock().transform.position = new Vector3(x + blockSize, y, 1.0f);
            NewBlock().transform.position = new Vector3(x, y + blockSize, 1.0f);
            NewBlock().transform.position = new Vector3(x - blockSize, y - blockSize, 1.0f);
            NewBlock().transform.position = new Vector3(x + blockSize, y - blockSize, 1.0f);

        }


        Block NewBlock()
        {
            var blockPrefab = _items.Where(u => u.itemType == ItemType.Block).First().ItemPrefab;
            var newBlock = (Block)Instantiate(blockPrefab);
            blocks.Add(newBlock);
            return newBlock;
        }
    }
}