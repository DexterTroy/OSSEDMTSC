import DataLoader
import ONN

a = DataLoader.load("train.txt")
b = DataLoader.load("test.txt")

print(ONN.run(a,b))