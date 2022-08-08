import json
import csv


left = set()
right = set()
with open("kanji2radical_left_right.json","r",encoding="UTF_8") as read:
    data = json.load(read)
for values in data.values():
    left.add(values[0])
    right.add(values[1])


csv_ = []
left=list(left)
right=list(right)


y = 1
for keys,values in data.items():
    l = left.index(values[0]) + 1
    r = right.index(values[1]) + 1
    x = [y,keys,l,left[l-1],r,right[r-1]]
    print(x)
    csv_.append(x)
    y+=1

print(x)

with open("return1.csv","w",encoding="UTF8") as write:
    csv.writer(write).writerows(csv_)


    


