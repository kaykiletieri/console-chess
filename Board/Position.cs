﻿namespace console_chess.Board
{
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public void SetValues(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}
