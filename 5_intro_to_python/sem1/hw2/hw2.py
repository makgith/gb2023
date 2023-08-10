def find_nums(a, b):
    discriminant = a**2 - 4 * b
    if (discriminant < 0): return "No solution in real numbers"
    y1 = (a + discriminant ** 0.5) / 2
    x1 = a - y1
    return y1, x1

sum = int(input("Input summ of 2 numbers "))
product = int(input("Input product of 2 numbers "))

# y**2 - a*y + b
print(f"Numbers are: {find_nums(sum, product)}")
