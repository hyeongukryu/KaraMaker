import random

random.seed(15733831)

for i in range(1000):
    key = ''
    for j in range(7):
        for k in range(5):
            key += str(random.randint(0, 9))
        key += '-'
    key = key[0:len(key) - 1]
    print(key)
