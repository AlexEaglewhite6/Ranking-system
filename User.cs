using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranking_system
{
    internal class User
    {
        public int[] Rank = { -8, -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7, 8 };
        public int rank { get; set; }
        public int progress { get; set; }
        int added = 0;
        public User() {
            rank = -8;
            progress = 0;
        }
        public void UpdateRank() 
        {
            
            rank += progress / 100;
            if(rank == 0) rank = 1;
            if (rank >= 8)
            {
                rank = 8;
                progress = 0;
            }
        }
        public void UpdateProgress(int tRank)
        {
            if (rank >= 8) { added = 0; progress = added; }
            else if (tRank == rank) { added = 3; progress += added; }
            else if (tRank == rank - 1) { added = 1; progress += added; }
            else if (tRank > rank)
            {

                int d = tRank - rank;
                if (rank == -1) --d;
                added = 10 * d * d;
                progress += added;

            }
            else added = 0;
            if(progress >= 100)
            {
                while(progress >= 100) 
                {
                    UpdateRank();
                    progress%=100;
                }
            }
        }

        public int getAddedProgress()
        {
            return added;
        }

    }
}
