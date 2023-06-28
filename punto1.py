
weeks = []
week_temp = []
week_dic = {
    0: "MARTES", 1: "MIERCOLES", 2: "JUEVES", 3: "VIERNES", 4: "SABADO", 5: "DOMINGO"
}
while True:
    day = float(input())
    if day == -1:
        break
    week_temp.append(day)
    if len(week_temp) % 6 == 0:
        weeks.append(week_temp)
        week_temp = []

for week in weeks:
    index_min = 0
    minimum = week[0]
    index_max = 0
    maximum = week[0]
    sum = 0
    for numday, sale_day in enumerate(week):
        if sale_day > maximum:
            maximum = sale_day
            index_max = numday
        elif sale_day < minimum:
            minimum = sale_day
            index_min = numday
        sum += sale_day

    print(week_dic[index_max], week_dic[index_min],"SI" if sum/6 < week[5] else "NO")
