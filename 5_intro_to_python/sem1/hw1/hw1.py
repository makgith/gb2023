
n = int(input("Input number of coins "))

heads = 0
tails = 0

for i in range(n):
    pos = int(input(f"Input side (0 or 1) for coint {i} "))
    if pos:
        heads += 1
    else:
        tails += 1

print(f"Required number of coins to flip: {min(heads, tails)}")