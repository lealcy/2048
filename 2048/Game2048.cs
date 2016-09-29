using System;

namespace Application
{
    public class Game2048
    {
        private int width;
        private int height;
        private int[][] board;
        public bool BoardChanged;
        public int[][] Board { 
            get { 
                return board; 
            }  
            private set { 
                board = value; 
            } 
        }

        private Random rand;

        public Game2048 (int width, int height)
        {
            this.width = width;
            this.height = height;
            board = new int[width][];
            for (int x = 0; x < width; x++) {
                board [x] = new int[height];
                for (int y = 0; y < height; y++) {
                    board [x] [y] = 0;
                }
            }
            rand = new Random ();
            AddValue ();
            BoardChanged = true;
        }

        public void AddValue()
        {
            if (!IsBoardFull ()) {
                int x, y;
                do {
                    x = rand.Next (width);
                    y = rand.Next (height);
                } while (board [x] [y] != 0);
                board [x] [y] = rand.Next (4) > 2 ? 4 : 2;
            }
        }

        public bool IsBoardFull() {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    if (board [x] [y] == 0) {
                        return false;
                    }
                }
            }
            return true;
        }

        public void MoveUp() {
            bool move;
            do {
                move = false;
                for (int x = 0; x < width; x++) {
                    for (int y = 1; y < height; y++) {
                        if (board[x][y] > 0){
                            if (board[x][y - 1] == 0) {
                                swap (x, y, x, y - 1);
                                move = true;
                                BoardChanged = true;
                            } else if (board[x][y] == board[x][y - 1]) {
                                board[x][y] = 0;
                                board[x][y - 1] *= 2;
                                move = true;
                                BoardChanged = true;
                            }
                        }
                    }
                }
            } while (move == true);


        }

        public void MoveRight() {
            bool move;
            do {
                move = false;
                for (int y = 0; y < height; y++) {
                    for (int x = width - 2; x >= 0; x--) {
                        if (board[x][y] > 0){
                            if (board[x + 1][y] == 0) {
                                swap (x, y, x + 1, y);
                                move = true;
                                BoardChanged = true;
                            } else if (board[x][y] == board[x + 1][y]) {
                                board[x][y] = 0;
                                board[x + 1][y] *= 2;
                                move = true;
                                BoardChanged = true;
                            }
                        }
                    }
                }
            } while (move == true);
        }

        public void MoveDown() {
            bool move;
            do {
                move = false;
                for (int x = 0; x < width; x++) {
                    for (int y = height - 2; y >= 0; y--) {
                        if (board[x][y] > 0){
                            if (board[x][y + 1] == 0) {
                                swap (x, y, x, y + 1);
                                move = true;
                                BoardChanged = true;
                            } else if (board[x][y] == board[x][y + 1]) {
                                board[x][y] = 0;
                                board[x][y + 1] *= 2;
                                move = true;
                                BoardChanged = true;
                            }
                        }
                    }
                }
            } while (move == true);
        }

        public void MoveLeft() {
            bool move;
            do {
                move = false;
                for (int y = 0; y < height; y++) {
                    for (int x = 1; x < height; x++) {
                        if (board[x][y] > 0){
                            if (board[x - 1][y] == 0) {
                                swap (x, y, x - 1, y);
                                move = true;
                                BoardChanged = true;
                            } else if (board[x][y] == board[x - 1][y]) {
                                board[x][y] = 0;
                                board[x - 1][y] *= 2;
                                move = true;
                                BoardChanged = true;
                            }
                        }
                    }
                }
            } while (move == true);
        }


        private void swap(int x1, int y1, int x2, int y2) {
            int temp = board[x1][y1];
            board [x1] [y1] = board [x2] [y2];
            board [x2] [y2] = temp;
        }
    }
}

