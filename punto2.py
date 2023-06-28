import math

x = []
y = []

while True:

    coordinate = input()

    if coordinate == "":
        break

    pair = coordinate.split(" ")
    x.append(int(pair[0]))
    y.append(int(pair[1]))

    if len(x) == 3:

        try:
            x1 = (x[0]+x[1])/2
            y1 = (y[0]+y[1])/2

            x2 = (x[1]+x[2])/2
            y2 = (y[1]+y[2])/2

            m1 = -1 / ((y[0]-y[1])/(x[0]-x[1]))
            m2 = -1 / ((y[1]-y[2])/(x[1]-x[2]))

            xSol = (m1 * x1 - m2 * x2+y2-y1) / (m1-m2)
            ySol = (m1 * (xSol-x1)+y1)
            print(xSol, ySol)
        except:
            print("Imposible")

        x = []
        y = []
