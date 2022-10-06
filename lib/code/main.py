import json
import csv

x = 1
with open("kanji2radical_left_right.json","r",encoding="UTF_8") as read:
# with open("radical2kanji_left_right.json","r",encoding="UTF_8") as read:
    data = json.load(read)
csv_ = []
for key in data.keys():
    csv_.append([x,key])
    x+=1
# print(csv_)
with open("return.csv","w",encoding="UTF_8") as write:
    csv.writer(write,delimiter="\t").writerows(csv_)

    


