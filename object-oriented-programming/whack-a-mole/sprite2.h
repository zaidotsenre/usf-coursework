#ifndef SPRITE_H
#define SPRITE_H

#include <fstream>
#include "screen.h"

// this is the sprite class
class sprite
{
protected: 
  int length; // length of sprite
  int width; // width of the sprite
  char image[80][24]; // image used by sprite

  
public: // this is the sprite constructor; length is currently not used

  bool visible; // is it display?
  float xpos; // the xpos of the sprite
  float ypos; // verticle position of the sprite
  screen* myscreenptr;

  explicit sprite(int x, int y, int l, int w, screen* myscnptr)
  {
    int i,j;
    length=l;
    width=w;
    xpos=x;
    ypos=y;
    visible=true;
    myscreenptr = myscnptr;
    for (i=0; i!=80;i++)
      for (j=0;j!=24;j++)
	      image[i][j] = ' ';
  }


  void setpos(int x, int y)
  {
    erase_sprite(*myscreenptr);
    xpos=x;
    ypos=y;
    paint_sprite(*myscreenptr);
  }

  // this is the method that moves the sprite up and down within limits
  void move_sprite(float xmove, float ymove, screen& localscreen)
  {
    erase_sprite(localscreen);
    if (((ypos+ymove) < 24) && (ypos+ymove+length) > 2)
      {
	ypos=ypos+ymove;
      }

    if (((xpos+xmove) > 0) && (xpos+xmove+width) < 79)
      {
	xpos=xpos+xmove;
      }
    // add logic to ensure sprite doesn't fly off screen
    paint_sprite(localscreen);
  }

  // this method erases the old sprite to prepare to paint the new one
  // from the screen class data structure
  void erase_sprite(screen& localscreen)
  {
    int x, y;

    for (x=0; x!=width; x++)
      for (y=0; y!=length; y++)
	if (image[x][y]!=' ')
	  {
	    localscreen.placechar(x+xpos,y+ypos,' ');
	  }
  }

  // this paints the current sprite into the screen data structure
  void paint_sprite(screen& localscreen)
  {
    int x, y;
	    
    if (visible)
      {
	for (x=0; x!=width; x++)
	  for (y=0; y!=length; y++)
	    if (image[x][y]!=' ')
	      {
		      localscreen.placechar(x+xpos,y+ypos,image[x][y]);
	      }
      }
  }


  void load_image (std::string filepath)
  {
    std::ifstream file(filepath, std::ifstream::in);
    std::string line;

    int i = 0;
    while (getline(file, line))
    {
      for (int j = 0; j < line.size(); j++)
      {
        image[j][i] = line[j];
      }
      i++;
    }
  }

};

#endif