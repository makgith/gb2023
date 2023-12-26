input = [1, 2, 3, 4, 5, 6, 7, 8]

max = 0
index = 0
for i in range(len(input)):
    sum = input[i - 1] + input[i] + input[0 if i == len(input) - 1 else i + 1]
    print(sum, i)
    if sum > max:
        max = sum
        index = i

print(f"Max berries: {max} from bush: {index + 1}")
