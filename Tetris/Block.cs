using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class Block
    {
        private int block_index; // index of generated block
        private int[] current_block_cords; // coordinates of falling block
        private int[] bottom_sensor; // sensor which detects collisions from bottom
        private int[] left_sensor; // sensor which detects collisions from left side
        private int[] right_sensor; // sensor which detects collisions from right side
        private int idx;

        public Block() // calls Draw_block()
        {
            Draw_block();
        }

        private void Draw_block() // drawing a number of a new block
        {
            Random rand = new Random(); // initializing random function
            idx = rand.Next(0, 8); // drawing the naumber of a block to print
            block_index = idx; // saving the choosen number to use it further in coloring
            Block_definitions(idx); // calling a definiton of the choosen block
        }

        private void Block_definitions(int idx) // contains definitions of blocks
        {
            switch (idx)
            {
                case 0: // |*
                    current_block_cords = new int[8] {6, 0, 5, 0, 5, 1, 5, 2}; // coordinates of falling block {y1,x1,y2,x2,...,yn,xn}
                    bottom_sensor = new int[4] {5, 3, 6, 1};
                    left_sensor = new int[6] {4, 0, 4, 1, 4, 2};
                    right_sensor = new int[6] {7, 0, 6, 1, 6, 2};
                    break;

                case 1: // .:.
                    current_block_cords = new int[8] {6, 0, 5, 1, 6, 1, 7, 1};
                    bottom_sensor = new int[6] {5, 2, 6, 2, 7, 2};
                    left_sensor = new int[4] {5, 0, 4, 1};
                    right_sensor = new int[4] {7, 0, 8, 1};
                    break;

                case 2: // ::
                    current_block_cords = new int[8] {5, 0, 6, 0, 5, 1, 6, 1};
                    bottom_sensor = new int[4] {5, 2, 6, 2};
                    left_sensor = new int[4] {4, 0, 4, 1};
                    right_sensor = new int[4] {7, 0, 7, 1};
                    break;

                case 3: // *|
                    current_block_cords = new int[8] {5, 0, 6, 0, 6, 1, 6, 2};
                    bottom_sensor = new int[4] {5, 1, 6, 3};
                    left_sensor = new int[6] {4, 0, 5, 1, 5, 2};
                    right_sensor = new int[6] {7, 0, 7, 1, 7, 2};
                    break;

                case 4: // |
                    current_block_cords = new int[8] {5, 0, 5, 1, 5, 2, 5, 3};
                    bottom_sensor = new int[2] {5, 4};
                    left_sensor = new int[8] {4, 0, 4, 1, 4, 2, 4, 3};
                    right_sensor = new int[8] {6, 0, 6, 1, 6, 2, 6, 3};
                    break;

                case 5: // *:.
                    current_block_cords = new int[8] {5, 0, 6, 0, 6, 1, 7, 1};
                    bottom_sensor = new int[6] {5, 1, 6, 2, 7, 2};
                    left_sensor = new int[4] {4, 0, 5, 1};
                    right_sensor = new int[4] {7, 0, 8, 1};
                    break;

                case 6: // .:*
                    current_block_cords = new int[8] {7, 0, 6, 0, 6, 1, 5, 1};
                    bottom_sensor = new int[6] {5, 2, 6, 2, 7, 1};
                    left_sensor = new int[4] {5, 0, 4, 1 };
                    right_sensor = new int[4] {8, 0, 7, 1};
                    break;

                case 7:// .
                    current_block_cords = new int[8] {6, 0, 6, 0, 6, 0, 6, 0};
                    bottom_sensor = new int[2] {6, 1};
                    left_sensor = new int[2] {5, 0};
                    right_sensor = new int[2] {7, 0};
                    break;
            }
        }

        public void Block_coordinates_down() // moving sensors 1 position lower
        {
            for (int j =0; j < bottom_sensor.Length; j++) // moving bottom sensor 1 position lower
            {
                j++;
                bottom_sensor[j] += 1;
            }

            for (int k = 0; k < left_sensor.Length; k++)
            {
                k++;
                left_sensor[k] += 1; // moving left sensor 1 position lower
                right_sensor[k] += 1; // moving right sensor 1 position lower
            }

            for (int i = 0; i < current_block_cords.Length; i++)
            {
                i++;
                current_block_cords[i] += 1; // moving coordinates of block 1 position lower
            }
        }

        public void Block_coordinates_left() // moving sensors 1 position left
        {
            for (int k = 0; k < bottom_sensor.Length; k++)
            {
                bottom_sensor[k] -= 1; // moving bottom sensor 1 position left
                k++;
            }

            for (int j = 0; j < left_sensor.Length; j++)
            {
                left_sensor[j] -= 1; // moving left sensor 1 position left
                right_sensor[j] -= 1; // moving right sensor 1 position left
                j++;
            }

            for (int i = 0; i < current_block_cords.Length; i++)
            {
                current_block_cords[i] -= 1; // moving coordinates of block 1 position left
                i++;
            }
        }

        public void Block_coordinates_right() // moving sensors 1 position right
        {
            for (int k = 0; k < bottom_sensor.Length; k++)
            {
                bottom_sensor[k] += 1; // moving bottom sensor 1 position right
                k++;
            }

            for (int j = 0; j < left_sensor.Length; j++)
            {
                left_sensor[j] += 1; // moving left sensor 1 position right
                right_sensor[j] += 1; // moving right sensor 1 position right
                j++;
            }

            for (int i = 0; i < current_block_cords.Length; i++)
            {
                current_block_cords[i] += 1; // moving coordinates of block 1 position right
                i++;
            }
        }

        #region properties
        public int[] Return_coordinates()
        {
            return current_block_cords;
        }

        public int[] Bottom_sensor_down()
        {
            return bottom_sensor;
        }

        public int[] Right_sensor_right()
        {
            return right_sensor;
        }

        public int Get_block_index()
        {
            return block_index;
        }

        public int[] Left_sensor_left()
        {
            return left_sensor;
        }
        #endregion
    }
}
