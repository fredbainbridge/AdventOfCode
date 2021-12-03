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
    public long PowerConsumption (string inputFile) {
        var lines = File.ReadAllLines(inputFile);
        int length = lines[0].Length;
        int[] zeros = new int[length];
        int[] ones = new int[length];
        for(int i = 0; i < length; i++) {
            foreach(var line in lines) {
                if(line[i].Equals('0')) {
                    zeros[i]++;
                }
                else {
                    ones[i]++;
                }
            }
        }
        string gammaString = "";
        string epsilonString = "";
        for(int i = 0; i < length; i++) {
            if(zeros[i] > ones[i]) {
                gammaString = gammaString + "0";
                epsilonString = epsilonString + "1";
            }
            else {
                gammaString = gammaString + "1";
                epsilonString = epsilonString + "0";
            }
            if(zeros[i] == ones[i]) {
                Console.WriteLine("TIE!!!");
            }
        }
        var answer = Convert.ToInt64(epsilonString, 2) * Convert.ToInt64(gammaString, 2);
        return answer;
        //makke an int from th e stinrg
    }

    public long LifeSupportRating(string inputFile) {
        var lines = File.ReadAllLines(inputFile);
        int length = lines[0].Length;
        string oxyRating = "";
        string co2Rating = "";
        List<int> keeperIndexes = new List<int>();
        for(int i = 0; i < lines.Count(); i++ ) {
            keeperIndexes.Add(i);
        }
        for(int i = 0; i < length; i++) {
            List<int> zeroIndexes = new List<int>();
            List<int> oneIndexes = new List<int>();
            
           //what is the most common bit?
           for(int k = 0; k < lines.Count(); k++) {
               if(!keeperIndexes.Contains(k)) {
                   continue;
               }
               if(lines[k][i].Equals('0')) {
                   zeroIndexes.Add(k);
               }
               else {
                   oneIndexes.Add(k);
               }
           }
           if(zeroIndexes.Count() == oneIndexes.Count()) {
               keeperIndexes = oneIndexes.ToList<int>();
           }
           if(zeroIndexes.Count() > oneIndexes.Count()) {
               keeperIndexes = zeroIndexes.ToList<int>();
           }
           if(zeroIndexes.Count() < oneIndexes.Count()) {
               keeperIndexes = oneIndexes.ToList<int>();
           }
           if(keeperIndexes.Count() == 1) {
               oxyRating = lines[keeperIndexes[0]];
           }
        }
        for(int i = 0; i < lines.Count(); i++ ) {
            keeperIndexes.Add(i);
        }
        for(int i = 0; i < length; i++) {
            List<int> zeroIndexes = new List<int>();
            List<int> oneIndexes = new List<int>();
            
           //what is the least common bit?
           for(int k = 0; k < lines.Count(); k++) {
               if(!keeperIndexes.Contains(k)) {
                   continue;
               }
               if(lines[k][i].Equals('0')) {
                   zeroIndexes.Add(k);
               }
               else {
                   oneIndexes.Add(k);
               }
           }
           if(zeroIndexes.Count() == oneIndexes.Count()) {
               keeperIndexes = zeroIndexes.ToList<int>();
           }
           if(zeroIndexes.Count() > oneIndexes.Count()) {
               keeperIndexes = oneIndexes.ToList<int>();
           }
           if(zeroIndexes.Count() < oneIndexes.Count()) {
               keeperIndexes = zeroIndexes.ToList<int>();
           }
           if(keeperIndexes.Count() == 1) {
               co2Rating = lines[keeperIndexes[0]];
           }
        }
        return Convert.ToInt64(oxyRating, 2) * Convert.ToInt64(co2Rating, 2);;
    }
}