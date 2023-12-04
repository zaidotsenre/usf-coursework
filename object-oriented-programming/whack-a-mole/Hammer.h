#ifndef HAMMER_H
#define HAMMER_H

#include "sprite2.h"
#include "hole.h"

class Hammer : public sprite
{
    public:

    Hammer (int x, int y, int l, int w, screen* canvas) : sprite (x, y, l, w, canvas)
    {
       
    }

    void MoveToHole (Hole& hole)
    {
        setpos (hole.xpos + 4, hole.ypos + 5);
        paint_sprite (*myscreenptr);
    }

    private:
};

#endif