using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };
        private readonly Random random = new Random();
        private Queue<Block> queue;
        public Block NextBlock { get => queue.Peek(); }
        public Block this[int i]
        {
            get => queue.ElementAt(i);
        }
        public int Count { get => queue.Count; }

        public BlockQueue(int blocks)
        {
            queue = new Queue<Block>();
            Block block = RandomBlock();
            queue.Enqueue(block);
            for (int i = 1; i < blocks; i++)
            {
                Block lastBlock = queue.ElementAt(queue.Count - 1);
                do
                {
                    block = RandomBlock();
                } while (block.Id == lastBlock.Id);
                queue.Enqueue(block);
            }
        }

        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        public Block GetAndUpdate()
        {
            Block block;
            Block lastBlock = queue.ElementAt(queue.Count - 1);
            do
            {
                block = RandomBlock();
            } while (block.Id == lastBlock.Id);
            queue.Enqueue(block);
            return queue.Dequeue();
        }
    }
}
