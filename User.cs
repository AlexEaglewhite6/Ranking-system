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
            if (rank >= 8) progress = 0;
            else if (tRank == rank) progress += 3;
            else if(tRank == rank - 1) progress += 1;
            else if(tRank > rank)
            {
                
                int d = tRank - rank;
                if (rank == -1) --d;
                progress += 10*d*d;
            }
            if(progress >= 100)
            {
                while(progress >= 100) 
                {
                    UpdateRank();
                    progress%=100;
                }
            }
        }

    }
}
