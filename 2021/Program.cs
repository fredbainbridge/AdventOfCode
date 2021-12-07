// day 1
Submarine sub = new Submarine();
string inputFileDay1 = "input.txt";
int singleIncreasing = sub.getSingleIncreasingDepth(inputFileDay1);
Console.WriteLine(singleIncreasing);
int tripleIncreasing = sub.getTripleIncreasingDepth(inputFileDay1);

// day 2
Console.WriteLine(tripleIncreasing);
string inputFileDay2 = "day2input.txt";
int position = sub.GetNewPosition(inputFileDay2);
Console.WriteLine(position);
int positionWithAim = sub.getNewPositionWithAim(inputFileDay2);
Console.WriteLine(positionWithAim);

//day 3
long day3AnswerPart1 = sub.PowerConsumption("day3.txt");
Console.WriteLine(day3AnswerPart1);
long day3AnswerPart2 = sub.LifeSupportRating("day3.txt");
Console.WriteLine(day3AnswerPart2);

//day 4
int bingWinnerSum = sub.BingoWinner("day4input.txt");
Console.WriteLine(bingWinnerSum);
int lastBingerWinnerScore = sub.LastBingerWinner("day4input.txt");
Console.WriteLine(lastBingerWinnerScore);

// day5
int numberOfRepeatPoints = sub.HydroVentsVertHorz("day5.txt");
Console.WriteLine(numberOfRepeatPoints);
int numberOfRepeatPointsWithDiags = sub.HydroVentsVertHorzDiag("day5.txt");
Console.WriteLine(numberOfRepeatPointsWithDiags);

// day 6
Console.WriteLine("Day 6");
int numFish = sub.LanternFishPopulation("inputtest.txt", 256);
Console.WriteLine(numFish);