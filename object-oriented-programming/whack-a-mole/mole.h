#ifndef MOLE_H
#define MOLE_H

#include "sprite2.h"

class Mole : public sprite
{
    public:

    Mole (int x, int y, int l, int w, screen* canvas) : sprite (x, y, l, w, canvas)
    {
        out = false;
        timetolive = 0;
    }

    bool out;
    int timetolive;

    private:
     
};

#endif