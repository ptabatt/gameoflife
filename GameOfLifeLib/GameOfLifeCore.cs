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
        GameOfLifeCell[,] _colCells;

        public GameOfLifeCore(int iRowLength, int iColumnLength)
        {
            _iRowLength = iRowLength;
            _iColumnLength = iColumnLength;
            _colCells = new GameOfLifeCell[iColumnLength, iRowLength];

            for (int i = 0; i < _iColumnLength; i++)
            {
                for (int j = 0; j < _iRowLength; j++)
                {
                    _colCells[i, j] = new GameOfLifeCell();
                }
            }
        }
        
        public void SetGlider()
        {
            _colCells[1, 2].IsAlive = true;
            _colCells[2, 3].IsAlive = true;
            _colCells[3, 1].IsAlive = true;
            _colCells[3, 2].IsAlive = true;
            _colCells[3, 3].IsAlive = true;
        }

        public void SetRepeater()
        {
            _colCells[1, 1].IsAlive = true;
            _colCells[2, 1].IsAlive = true;
            _colCells[3, 1].IsAlive = true;
        }

        public void SetTardigrade()
        {
            _colCells[1, 1].IsAlive = true;
            _colCells[2, 1].IsAlive = true;
            _colCells[1, 2].IsAlive = true;
            _colCells[2, 2].IsAlive = true;
        }

        public void SetDodoBird()
        {
            _colCells[3, 3].IsAlive = true;
        }
        
        public void LiveLifeSegment()
        {
            // Go through the 2d array and mark which ones should live 
            // and which should die
            for (int i = 0; i < _iColumnLength; i++)
            {
                for (int j = 0; j < _iRowLength; j++)
                {
                    int iTotalLivingNeighbors = 0;

                    if (i - 1 >= 0 && j - 1 >= 0)
                    {
                        if (_colCells[i - 1, j - 1].IsAlive)
                            iTotalLivingNeighbors++;
                    }

                    if (i - 1 >= 0)
                    {
                        if (_colCells[i - 1, j].IsAlive)
                            iTotalLivingNeighbors++;
                    }

                    if (i - 1 >= 0 && j + 1 < _iRowLength)
                    {
                        if (_colCells[i - 1, j + 1].IsAlive)
                            iTotalLivingNeighbors++;
                    }

                    if (j - 1 >= 0)
                    {
                        if (_colCells[i, j - 1].IsAlive)
                            iTotalLivingNeighbors++;
                    }

                    if (j + 1 < _iRowLength)
                    {
                        if (_colCells[i, j + 1].IsAlive)
                            iTotalLivingNeighbors++;
                    }

                    if (i + 1 < _iColumnLength && j - 1 >= 0)
                    {
                        if (_colCells[i + 1, j - 1].IsAlive)
                            iTotalLivingNeighbors++;
                    }

                    if (i + 1 < _iColumnLength)
                    {
                        if (_colCells[i + 1, j].IsAlive)
                            iTotalLivingNeighbors++;
                    }

                    if (i + 1 < _iColumnLength && j + 1 < _iColumnLength)
                    {
                        if (_colCells[i + 1, j + 1].IsAlive)
                            iTotalLivingNeighbors++;
                    }

                    if (_colCells[i, j].IsAlive)
                    {
                        if (iTotalLivingNeighbors < 2)
                            _colCells[i, j].KillOrRevive = true;

                        else if (iTotalLivingNeighbors > 3)
                            _colCells[i, j].KillOrRevive = true;
                    }
                    else
                    {
                        if (iTotalLivingNeighbors == 3)
                            _colCells[i, j].KillOrRevive = true;
                    }
                }
            }

            // Go through the 2d array and "Kill or Revive" the ones marked
            for (int i = 0; i < _iColumnLength; i++)
            {
                for (int j = 0; j < _iRowLength; j++)
                {
                    if (_colCells[i, j].KillOrRevive)
                    {
                        _colCells[i, j].IsAlive = !_colCells[i, j].IsAlive;
                        _colCells[i, j].KillOrRevive = false;
                    }
                }
            }
        }

        public void PrintStateOfLife()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int i = 0; i < _iColumnLength; i++)
            {
                for (int j = 0; j < _iRowLength; j++)
                {
                    if (_colCells[i, j].IsAlive)
                        Console.Write(" ■ ");
                    else
                        Console.Write(" □ ");
                }

                Console.WriteLine();
            }
        }

        public GameOfLifeCell[,] ReturnGameState()
        {
            return _colCells;
        }
    }
}