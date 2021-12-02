public class Submarine {
    public int getSingleIncreasingDepth(string inputFile) {
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

    public int getTripleIncreasingDepth2(string inputFile) {
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
}