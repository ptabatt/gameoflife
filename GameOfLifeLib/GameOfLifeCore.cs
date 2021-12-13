using System;

namespace GameOfLifeLib
{
    /// <summary>
    /// Core Implementation of Conway's Game of Life
    /// Rules:
    /// Any live cell with fewer than two live neighbours dies, as if by underpopulation.
    /// Any live cell with two or three live neighbours lives on to the next generation.
    /// Any live cell with more than three live neighbours dies, as if by overpopulation.
    /// Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
    /// </summary>
    public class GameOfLifeCore
    {
        int _iRowLength;
        int _iColumnLength;
        bool[,] _colCells;

        public GameOfLifeCore(int iRowLength, int iColumnLength)
        {
            _iRowLength = iRowLength;
            _iColumnLength = iColumnLength;
            _colCells = new bool[iColumnLength, iRowLength];
        }
        
        public void SetGlider()
        {
            _colCells[1, 2] = true;
            _colCells[2, 3] = true;
            _colCells[3, 1] = true;
            _colCells[3, 2] = true;
            _colCells[3, 3] = true;
        }

        public void SetRepeater()
        {
            _colCells[2, 2] = true;
            _colCells[3, 2] = true;
            _colCells[4, 2] = true;
        }

        public void SetTardigrade()
        {
            _colCells[1, 1] = true;
            _colCells[2, 1] = true;
            _colCells[1, 2] = true;
            _colCells[2, 2] = true;
        }

        public void SetDodoBird()
        {
            _colCells[3, 3] = true;
        }
        
        public void LiveLifeSegment()
        {
            bool[,] colCells = new bool[_iColumnLength, _iRowLength];

            for (int i = 1; i < _iColumnLength - 1; i++)
            {
                for (int j = 1; j < _iRowLength - 1; j++)
                {
                    int iTotalLivingNeighbors = 0;

                    for (int ii = -1; ii < 2; ii++)
                    {
                        for (int jj = -1; jj < 2; jj++)
                        {
                            if (ii == 0 && jj == 0)
                            {
                                continue;
                            }
                            else 
                            {
                                if(_colCells[i + ii, j + jj])
                                {
                                    iTotalLivingNeighbors++;
                                }
                            }
                        }
                    }

                    if (_colCells[i, j])
                    {
                        if (iTotalLivingNeighbors == 2 || iTotalLivingNeighbors == 3)
                            colCells[i, j] = true;
                    }
                    else
                    {
                        if (iTotalLivingNeighbors == 3)
                            colCells[i, j] = true;
                    }
                }
            }

            _colCells = colCells;
        }

        public void PrintStateOfLife()
        {
            for (int i = 0; i < _iColumnLength; i++)
            {
                for (int j = 0; j < _iRowLength; j++)
                {
                    if (_colCells[i, j])
                        Console.Write(" ■ ");
                    else
                        Console.Write(" □ ");
                }

                Console.WriteLine();
            }
        }

        public bool[,] ReturnGameState()
        {
            return _colCells;
        }
    }
}