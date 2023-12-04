// mostly from article on StackExchange

#ifndef NONBLOCKING_H
#define NONBLOCKING_H

#include <sys/ioctl.h>
#include <termios.h>

void enable_raw_mode()
{
  termios term;
  tcgetattr(0, &term);
  term.c_lflag &= ~(ICANON | ECHO); // Disable echo as well
  tcsetattr(0, TCSANOW, &term);
}

void disable_raw_mode()
{
  termios term;
  tcgetattr(0, &term);
  term.c_lflag |= ICANON | ECHO;
  tcsetattr(0, TCSANOW, &term);
}

bool kbhit()
{
  int byteswaiting;
  ioctl(0, FIONREAD, &byteswaiting);
  return byteswaiting > 0;
}

#endif