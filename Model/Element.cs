using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoreographySimulator
{
    public class Element
    {
        private int id;
        private String name;
        private String color;
        private int spawnX;
        private int spawnY;
        private List<Move> moves = new List<Move> { };

        public Element(int id_, String name_, String color_, int spawnX_, int spawnY_)
        {
            this.id = id_;
            this.name = name_;
            this.color = color_;
            this.spawnX = spawnX_;
            this.spawnY = spawnY_;
        }

        public void AddMove(Move move) { this.moves.Append(move); }
        public void RemoveLastMove() { this.moves.RemoveAt(this.moves.Count - 1); }
        public int GetCountMoves() { return this.moves.Count; }
        public Move GetMove(int index) { return moves[index]; }

        //getter
        public int GetId() { return id; }
        public String GetName() { return name; }
        public String GetColor() { return color; }
        public int GetSpawnX() { return spawnX; }
        public int GetSpawnY() { return spawnY; }

        //setter
        public void SetId(int id_) { id = id_; }
        public void SetName(String name_) { name = name_; }
        public void SetColor(String color_) { color = color_; }
        public void SetSpawnX(int spawnX_) { spawnX = spawnX_; }
        public void SetSpawnY(int spawnY_) { spawnY = spawnY_; }
    }
}
