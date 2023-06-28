def find_circumcenter(x1, y1, x2, y2, x3, y3):

    # Step 1: Calculate midpoints
    x_mab = (x1 + x2) / 2
    y_mab = (y1 + y2) / 2

    x_mbc = (x2 + x3) / 2
    y_mbc = (y2 + y3) / 2
    print("x1", x_mab)
    print("y1", y_mab)
    print("x2", x_mbc)
    print("y2", x_mbc)
    # Step 2: Calculate slopes of the lines
    slope_ab = (y2 - y1) / (x2 - x1)
    slope_bc = (y3 - y2) / (x3 - x2)

    # Step 3: Calculate perpendicular bisector slopes
    slope_perp_ab = -1 / slope_ab
    slope_perp_bc = -1 / slope_bc
    print(slope_perp_ab)
    print(slope_perp_bc)
    # Step 4: Calculate circumcenter coordinates
    x = (slope_perp_ab * x_mab - slope_perp_bc * x_mbc +
         y_mbc - y_mab) / (slope_perp_ab - slope_perp_bc)
    y = slope_perp_ab * (x - x_mab) + y_mab

    # Step 5: Return the circumcenter coordinates
    return x, y


# Example usage
x1, y1 = -4, 0

x2, y2 = 0, 4

x3, y3 = 4, 0


x1, y1
x2, y2
x3, y3

circumcenter = find_circumcenter(x1, y1, x2, y2, x3, y3)
print("Circumcenter:", circumcenter)
