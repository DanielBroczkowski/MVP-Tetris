using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    class Figura
    {
        private Color color = Color.White;
        private int index_figury;
        private int[] wspolrzedne_startowe;
        private int[] check_field;
        private int[] check_sides_left;
        private int[] check_sides_right;
        public Figura()
        {
            Draw_figure();
        }
        private void Draw_figure()
        {
            Random rand = new Random();
            int k = rand.Next(0, 7);
            index_figury = k;
            figura_wspolrzedne(k);
        }
        private void figura_wspolrzedne(int k)
        {
            switch (k)
            {
                case 0:
                    wspolrzedne_startowe = new int[8] { 4, 0, 4, 1, 4, 2, 4, 3 };
                    check_field = new int[2] {4,4};
                    check_sides_left = new int[8] { 3, 0, 3, 1, 3, 2, 3, 3 };
                    check_sides_right = new int[8] { 5,0,5,1,5,2,5,3,};

                    break;
                case 1:
                    wspolrzedne_startowe = new int[8] { 4, 0, 5, 0, 4, 1, 5, 1 };
                    check_field = new int[4] {4,2,5,2 };
                    check_sides_left = new int[4] {3,0,3,1};
                    check_sides_right = new int[4] {6,0,6,1};
                    break;
                case 2:
                    wspolrzedne_startowe = new int[8] { 4, 0, 3, 1, 4, 1, 5, 1 };
                    check_field = new int[6] {3,2,4,2,5,2 };
                    check_sides_left = new int[4] {3,0,2,1};
                    check_sides_right = new int[4] {5,0,6,1};
                    break;
                case 3:
                    wspolrzedne_startowe = new int[8] { 4, 0, 5, 0, 5, 1, 5, 2 };
                    check_field = new int[4] {4,1,5,3 };
                    check_sides_left = new int[6] {3,0,4,1,4,2};
                    check_sides_right = new int[6] {6,0,6,1,6,2 };
                    break;
                case 4:
                    wspolrzedne_startowe = new int[8] { 5, 0, 4, 0, 4, 1, 4, 2 };
                    check_field = new int[4] {4,3,5,1 };
                    check_sides_left = new int[6] {3,0,3,1,3,2};
                    check_sides_right = new int[6] {6,0,5,1,5,2};
                    break;
                case 5:
                    wspolrzedne_startowe = new int[8] { 4, 0, 5, 0, 5, 1, 6, 1 };
                    check_field = new int[6] {4,1,5,2,6,2 };
                    check_sides_left = new int[4] {3,0, 4,1};
                    check_sides_right = new int[4] {6,0,7,1};
                    break;
                case 6:
                    wspolrzedne_startowe = new int[8] { 5, 0, 4, 0, 4, 1, 3, 1 };
                    check_field = new int[6] {3,2,4,2,5,1 };
                    check_sides_left = new int[4] {3,0,2,1 };
                    check_sides_right = new int[4] {6,0,5,1};
                    break;

            }
        }
        public void figura_wspolrzedne_down()
        {
            for (int j =0; j < check_field.Length; j++)
            {
                j++;
                this.check_field[j] += 1;

            }
            for (int k = 0; k < check_sides_left.Length; k++)
            {
                k++;
                check_sides_left[k] = check_sides_left[k] + 1;
                check_sides_right[k] = check_sides_right[k] + 1;
            }
            for (int i = 0; i < 8; i++)
            { 
                i++;
                this.wspolrzedne_startowe[i] = wspolrzedne_startowe[i] + 1;
                
            }
        }
        public void figura_wspolrzedne_left()
        {
            for (int j = 0; j < check_sides_left.Length-1; j++)
            {
                check_sides_left[j] = check_sides_left[j] - 1;
                check_sides_right[j] = check_sides_right[j] - 1;
                j++;

            }
            for (int k = 0; k < check_field.Length; k++)
            {

                check_field[k] = check_field[k] - 1;
                k++;
            }

            for (int i = 0; i < 7; i++)
            {
                this.wspolrzedne_startowe[i] = wspolrzedne_startowe[i] -1;
                i++;
            }
        }
        public void figura_wspolrzedne_right()
        {
            for (int j = 0; j < check_sides_left.Length - 1; j++)
            {
                check_sides_left[j] = check_sides_left[j] +1;
                check_sides_right[j] = check_sides_right[j] +1;
                j++;

            }
            for (int k = 0; k < check_field.Length; k++)
            {

                check_field[k] = check_field[k] +1;
                k++;
            }

            for (int i = 0; i < 7; i++)
            {
                this.wspolrzedne_startowe[i] = wspolrzedne_startowe[i] +1;
                i++;
            }
        }

        public int[] wspolrzedne()
        {
            return wspolrzedne_startowe;
        }
        public int[] check_field_down()
        {
            return check_field;
        }
        public int[] check_sides_left_left()
        {
            return check_sides_left;
        }
        public int[] check_sides_right_right()
        {
            return check_sides_right;
        }
        public int get_index_figury()
        {
            return index_figury;
        }
            

    }
}
