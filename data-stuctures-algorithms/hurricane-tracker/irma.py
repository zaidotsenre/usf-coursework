import turtle


def irma_setup():
    """Creates the Turtle and the Screen with the map background
       and coordinate system set to match latitude and longitude.

       :return: a tuple containing the Turtle and the Screen

       DO NOT CHANGE THE CODE IN THIS FUNCTION!
    """
    import tkinter
    turtle.setup(965, 600)  # set size of window to size of map

    wn = turtle.Screen()
    wn.title("Hurricane Irma")

    # kludge to get the map shown as a background image,
    # since wn.bgpic does not allow you to position the image
    canvas = wn.getcanvas()
    turtle.setworldcoordinates(-90, 0, -17.66, 45)  # set the coordinate system to match lat/long

    map_bg_img = tkinter.PhotoImage(file="images/atlantic-basin.png")

    # additional kludge for positioning the background image
    # when setworldcoordinates is used
    canvas.create_image(-1175, -580, anchor=tkinter.NW, image=map_bg_img)

    t = turtle.Turtle()
    wn.register_shape("images/hurricane.gif")
    t.shape("images/hurricane.gif")

    return (t, wn, map_bg_img)


def irma():
    """Animates the path of hurricane Irma
    """
    (t, wn, map_bg_img) = irma_setup()

    # your code to animate Irma here
    with open("irma.csv", "r") as file:
        lines = file.readlines()
        lines.pop(0)

    hurricaneData = []
    for line in lines:
        line = line.strip()
        line = line.split(',')
        hurricaneData.append([float(line[2]), float(line[3]), int(line[4])])

    t.speed('slowest')
    t.penup()
    t.hideturtle()
    t.setpos(hurricaneData[0][1], hurricaneData[0][0])
    t.showturtle()
    t.pendown()
    for dataPoint in hurricaneData:
        if dataPoint[2] < 74:
            t.color('white')
            t.width(5)
        elif dataPoint[2] < 96:
            t.color('blue')
            t.width(10)
        elif dataPoint[2] < 111:
            t.color('green')
            t.width(15)
        elif dataPoint[2] < 130:
            t.color('yellow')
            t.width(20)
        elif dataPoint[2] < 157:
            t.color('orange')
            t.width(25)
        else:
            t.color('red')
            t.width(30)
        t.goto(dataPoint[1], dataPoint[0])

    return (t, wn, map_bg_img)

if __name__ == "__main__":
    (t, wn, map_bg_img) = irma()
    wn.exitonclick()
