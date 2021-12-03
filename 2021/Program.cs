// See https://aka.ms/new-console-template for more information
Submarine sub = new Submarine();
string inputFileDay1 = "input.txt";
int singleIncreasing = sub.getSingleIncreasingDepth(inputFileDay1);
Console.WriteLine(singleIncreasing);
int tripleIncreasing = sub.getTripleIncreasingDepth(inputFileDay1);
Console.WriteLine(tripleIncreasing);
string inputFileDay2 = "day2input.txt";
int position = sub.GetNewPosition(inputFileDay2);
Console.WriteLine(position);
int positionWithAim = sub.getNewPositionWithAim(inputFileDay2);
Console.WriteLine(positionWithAim);
long day3AnswerPart1 = sub.PowerConsumption("day3.txt");
Console.WriteLine(day3AnswerPart1);
long day3AnswerPart2 = sub.LifeSupportRating("day3.txt");
Console.WriteLine(day3AnswerPart2);
