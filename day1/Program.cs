// See https://aka.ms/new-console-template for more information
Submarine sub = new Submarine();
string inputFile = "input.txt";
int singleIncreasing = sub.getSingleIncreasingDepth(inputFile);
Console.WriteLine(singleIncreasing);
int tripleIncreasing = sub.getTripleIncreasingDepth2(inputFile);
Console.WriteLine(tripleIncreasing);