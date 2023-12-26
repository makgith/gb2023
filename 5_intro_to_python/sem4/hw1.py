set1 = set([int(i) for i in input("Input 1st array: ").split()])
set2 = set([int(i) for i in input("Input 2nd array: ").split()])
intersection = set1.intersection(set2)

if len(intersection):
    print(*intersection)
else:
    print("No repeating values!")