public class Submarine {
    public int getSingleIncreasingDepth(string inputFile) { //day 2 part 1
        var lines = File.ReadAllLines(inputFile);
        int prevLine = -1;
        int increasing = 0;
        foreach(var line in lines) {
            int intLine = Int32.Parse(line);
            if(prevLine == -1) {
                prevLine = intLine;
                continue;
            }
            if(intLine > prevLine) {
                increasing++;
            }
            prevLine = intLine;
        }
        return increasing;
    }

    public int getTripleIncreasingDepth(string inputFile) { //day 1 part 2
        var lines = File.ReadAllLines(inputFile);
        int[] lineInts = new int[lines.Count()];
        int lineCounter = 0;
        foreach(string line in lines) {
            lineInts[lineCounter] = Int32.Parse(line);
            lineCounter++;
        }
        int increasing = 0;
        for(int i = 0; i< lineInts.Count(); i++) {
            if(i < 3) {
                continue;
            }
            int prevSum = lineInts[i-1] + lineInts[i-2] + lineInts[i-3];
            int sum = lineInts[i] + lineInts[i-1] + lineInts[i-2];
            if(sum > prevSum) {
                increasing++;
            }
        }
        return increasing;
    }

    public int GetNewPosition(string inputFile) { //day2 part 1
        var lines = File.ReadAllLines(inputFile);
        int horizontal = 0;
        int depth = 0;
        foreach(var line in lines) {
            string[] values = line.Split(" ");
            switch (values[0])
            {
                case "forward":
                    horizontal += Int32.Parse(values[1]);
                    break;
                case "down": 
                    depth += Int32.Parse(values[1]);
                    break;
                case "up":
                    depth -= Int32.Parse(values[1]);
                    break;
                default:
                    break;
            }
        }
        return depth * horizontal;
    }

    public int getNewPositionWithAim(string inputFile) {
        var lines = File.ReadAllLines(inputFile);
        int horizontal = 0;
        int depth = 0;
        int aim = 0;
        foreach(var line in lines) {
            string[] values = line.Split(" ");
            switch (values[0])
            {
                case "forward":
                    horizontal += Int32.Parse(values[1]);
                    depth += aim * Int32.Parse(values[1]);
                    break;
                case "down": 
                    aim += Int32.Parse(values[1]);
                    break;
                case "up":
                    aim -= Int32.Parse(values[1]);
                    break;
                default:
                    break;
            }
        }
        return horizontal * depth;
    }
}