#include <iostream>
#include <curses.h>
#include <unistd.h>
#include "nonblocking.h"
#include "screen.h"
#include "hole.h"
#include "mole.h"
#include "Hammer.h"

void PointOrNoPoint (Mole &mole, int& score);

int main ()
{
    // Start the screen
    screen* canvas = new screen;

    // Start the holes
    Hole holes[6] = {
        Hole(0, 5, 5, 11, canvas),
        Hole(35, 5, 5, 11, canvas),
        Hole(69, 5, 5, 11, canvas),
        Hole(0, 15, 5, 11, canvas),
        Hole(35, 15, 5, 11, canvas),
        Hole(69, 15, 5, 11, canvas)
    };
    for (int i = 0; i < 6; i++)
    {
        holes[i].load_image ("hole.txt");
        holes[i].paint_sprite(*canvas);
    }

    // Initialize moles
    Mole moles[6] = {
        Mole (4, 6, 3, 5, canvas),
        Mole (39, 6, 3, 5, canvas),
        Mole (73, 6, 3, 5, canvas),
        Mole (4, 16, 3, 5, canvas),
        Mole (39, 16, 3, 5, canvas),
        Mole (73, 16, 3, 5, canvas),
    };
    for (int i = 0; i < 6; i++)
    {
        moles[i].load_image("mole.txt");
    }

    // Initialize hammer
    Hammer hammer(moles[0].xpos, moles[0].ypos + 4, 3, 4, canvas);
    hammer.load_image ("hammer.txt");
    hammer.paint_sprite(*canvas);

    // Draw the screen
    canvas->display();

    // Needed to select holes at random
    srand(time(NULL));

    int timer = 0;
    int score = 0;
    char input;
    int hammerpos = 0;
    while (timer <= 60)
    {
        if (timer % 3 == 0)
        {
            for (int i = 0; i < 6; i++)
            {   
                if ((rand () % 2) == 1)
                {
                    moles[i].erase_sprite(*canvas);
                    moles[i].out = false;
                }
                else 
                {
                    moles[i].paint_sprite(*canvas);
                    moles[i].out = true;
                }
            }
        }
        if (kbhit())
        {
                input = getchar();
                tcflush(0, TCIFLUSH);
            
            switch (input)
            {
                case 'a':
                    hammerpos--;
                    break;
                case 'd':
                    hammerpos++;
                    break;
                case 's':
                    hammerpos += 3;
                    break;
                case 'w':
                    hammerpos -= 3;
                    break;
                case ' ':
                    PointOrNoPoint(moles[hammerpos], score);
                    break;
                default:
                    break;
            }
            if (hammerpos < 0)
            {
                hammerpos = 0;
            }
            if (hammerpos >= 6)
            {
                hammerpos = 5;
            }
            hammer.MoveToHole (holes[hammerpos]);
        }
        timer++;
        std::string currenttime = std::to_string(timer);
        for (int i = 0; i < currenttime.size(); i++)
        {
            canvas->placechar(i, 0, currenttime[i]);
        }
        std::string currentscore = std::to_string(score);
        for (int i = 0; i < currentscore.size(); i++)
        {
            canvas->placechar(i, 1, currentscore[i]);
        }
        canvas->display();
        sleep(1);
    }
    endwin();
    std::cout << "Your score: " << score << std::endl;
}


void PointOrNoPoint (Mole &mole, int& score)
{
    if (mole.out)
    {
        score++;
    }
}