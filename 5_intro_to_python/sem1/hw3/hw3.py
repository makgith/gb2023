
n = int(input("Input N: "))

pows = [f"{2**i}," for i in range(n) if 2**i < n]

print(*pows, sep="")