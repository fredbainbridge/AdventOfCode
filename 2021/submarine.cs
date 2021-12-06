public class Submarine
{
    public int getSingleIncreasingDepth(string inputFile)
    { //day 2 part 1
        var lines = File.ReadAllLines(inputFile);
        int prevLine = -1;
        int increasing = 0;
        foreach (var line in lines)
        {
            int intLine = Int32.Parse(line);
            if (prevLine == -1)
            {
                prevLine = intLine;
                continue;
            }
            if (intLine > prevLine)
            {
                increasing++;
            }
            prevLine = intLine;
        }
        return increasing;
    }

    public int getTripleIncreasingDepth(string inputFile)
    { //day 1 part 2
        var lines = File.ReadAllLines(inputFile);
        int[] lineInts = new int[lines.Count()];
        int lineCounter = 0;
        foreach (string line in lines)
        {
            lineInts[lineCounter] = Int32.Parse(line);
            lineCounter++;
        }
        int increasing = 0;
        for (int i = 0; i < lineInts.Count(); i++)
        {
            if (i < 3)
            {
                continue;
            }
            int prevSum = lineInts[i - 1] + lineInts[i - 2] + lineInts[i - 3];
            int sum = lineInts[i] + lineInts[i - 1] + lineInts[i - 2];
            if (sum > prevSum)
            {
                increasing++;
            }
        }
        return increasing;
    }

    public int GetNewPosition(string inputFile)
    { //day2 part 1
        var lines = File.ReadAllLines(inputFile);
        int horizontal = 0;
        int depth = 0;
        foreach (var line in lines)
        {
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

    public int getNewPositionWithAim(string inputFile)
    {
        var lines = File.ReadAllLines(inputFile);
        int horizontal = 0;
        int depth = 0;
        int aim = 0;
        foreach (var line in lines)
        {
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
    public long PowerConsumption(string inputFile)
    {
        var lines = File.ReadAllLines(inputFile);
        int length = lines[0].Length;
        int[] zeros = new int[length];
        int[] ones = new int[length];
        for (int i = 0; i < length; i++)
        {
            foreach (var line in lines)
            {
                if (line[i].Equals('0'))
                {
                    zeros[i]++;
                }
                else
                {
                    ones[i]++;
                }
            }
        }
        string gammaString = "";
        string epsilonString = "";
        for (int i = 0; i < length; i++)
        {
            if (zeros[i] > ones[i])
            {
                gammaString = gammaString + "0";
                epsilonString = epsilonString + "1";
            }
            else
            {
                gammaString = gammaString + "1";
                epsilonString = epsilonString + "0";
            }
            if (zeros[i] == ones[i])
            {
                Console.WriteLine("TIE!!!");
            }
        }
        var answer = Convert.ToInt64(epsilonString, 2) * Convert.ToInt64(gammaString, 2);
        return answer;
        //makke an int from th e stinrg
    }

    public long LifeSupportRating(string inputFile)
    {
        var lines = File.ReadAllLines(inputFile);
        int length = lines[0].Length;
        string oxyRating = "";
        string co2Rating = "";
        //answeR: 5852595
        List<int> keeperOxyIndexes = new List<int>();
        List<int> keeperCO2Indexes = new List<int>();
        for (int i = 0; i < lines.Count(); i++)
        {
            keeperOxyIndexes.Add(i);
            keeperCO2Indexes.Add(i);
        }
        for (int i = 0; i < length; i++)
        {
            List<int> zeroIndexes = new List<int>();
            List<int> oneIndexes = new List<int>();

            //what is the most common bit?
            for (int k = 0; k < lines.Count(); k++)
            {
                if (!keeperOxyIndexes.Contains(k))
                {
                    continue;
                }
                if (lines[k][i].Equals('0'))
                {
                    zeroIndexes.Add(k);
                }
                else
                {
                    oneIndexes.Add(k);
                }
            }
            if (zeroIndexes.Count() == oneIndexes.Count())
            {
                keeperOxyIndexes = oneIndexes.ToList<int>();
            }
            if (zeroIndexes.Count() > oneIndexes.Count())
            {
                keeperOxyIndexes = zeroIndexes.ToList<int>();
            }
            if (zeroIndexes.Count() < oneIndexes.Count())
            {
                keeperOxyIndexes = oneIndexes.ToList<int>();
            }
            if (keeperOxyIndexes.Count() == 1)
            {
                oxyRating = lines[keeperOxyIndexes[0]];
            }
            zeroIndexes = new List<int>();
            oneIndexes = new List<int>();
            for (int k = 0; k < lines.Count(); k++)
            {
                if (!keeperCO2Indexes.Contains(k))
                {
                    continue;
                }
                if (lines[k][i].Equals('0'))
                {
                    zeroIndexes.Add(k);
                }
                else
                {
                    oneIndexes.Add(k);
                }
            }
            if (zeroIndexes.Count() == oneIndexes.Count())
            {
                keeperCO2Indexes = zeroIndexes.ToList<int>();
            }
            if (zeroIndexes.Count() > oneIndexes.Count())
            {
                keeperCO2Indexes = oneIndexes.ToList<int>();
            }
            if (zeroIndexes.Count() < oneIndexes.Count())
            {
                keeperCO2Indexes = zeroIndexes.ToList<int>();
            }
            if (keeperCO2Indexes.Count() == 1)
            {
                co2Rating = lines[keeperCO2Indexes[0]];
            }
        }
        return Convert.ToInt64(oxyRating, 2) * Convert.ToInt64(co2Rating, 2); ;
    }
    private List<int[]> getBoards(string inputFile) {
        var lines = File.ReadAllLines(inputFile);
        
        //numbers = new int[]{30,53,27,57,35};
        List<int[]> boards = new List<int[]>();
        int[] board = new int[25];
        int counter = 0;
        for(int i = 2; i < lines.Count(); i++) {
            if(string.IsNullOrEmpty(lines[i].Trim())) {
                counter = 0;
                boards.Add(board);
                board = new int[25];
                continue;
            }
            var strLines = lines[i].Split(' ');
            foreach(string s in strLines) {
                if(string.IsNullOrWhiteSpace(s)) {
                    continue;
                }
                board[counter] = Int32.Parse(s);
                counter++;
            }
        }
        boards.Add(board);
        return boards;
    }
    private int[] getBingoNumbers(string inputFile) {
        var lines = File.ReadAllLines(inputFile);
        string[] numbersStrings = lines[0].Split(',');
        int[] numbers = new int[numbersStrings.Count()];
        for (int i = 0; i< numbersStrings.Count(); i++) {
            numbers[i] = Int32.Parse(numbersStrings[i]);
        }
        return numbers;
    }
    public int BingoWinner(string inputFile) {
        var boards = getBoards(inputFile);
        var numbers = getBingoNumbers(inputFile);
        foreach(int num in numbers) {
            foreach(int[] b in boards) {
                for(int i = 0; i < b.Length; i++) {
                    if(b[i] == num) {
                        b[i] = -1;
                        if(isWinner(b)) {
                            int sum = 0;
                            for(int z = 0; z < b.Length; z++) {
                                if(b[z] != -1) {
                                    sum += b[z];
                                }
                            }
                            return sum * num;
                        }
                    }
                }
            }
        }
        return 0;
    }
    
    public int LastBingerWinner(string inputFile) {
        var boards = getBoards(inputFile);
        var numbers = getBingoNumbers(inputFile);
        List<int> winnersIndex = new List<int>();
        List<int> winnersScore = new List<int>();
        foreach(int num in numbers) {
            int boardCounter = 0;
            foreach(int[] b in boards) {
                boardCounter++;
                if(winnersIndex.Contains(boardCounter)) {
                    continue;
                }
                for(int i = 0; i < b.Length; i++) {
                    if(b[i] == num) {
                        b[i] = -1;
                        if(isWinner(b)) {
                            winnersIndex.Add(boardCounter);
                            int sum = 0;
                            for(int z = 0; z < b.Length; z++) {
                                if(b[z] != -1) {
                                    sum += b[z];
                                }
                            }
                            winnersScore.Add(sum * num);
                        }
                    }
                }
            }
        }
        return winnersScore.Last();
    }
    private bool isWinner(int[] board) {
        bool winner = true;
        for(int i = 0; i < 5; i++) {
            winner = true;
            for(int k = 0; k < 5; k++) {
                if(board[i * 5 + k] != -1) { 
                    winner = false;
                }
            }
            if(winner) {
                return true;
            }
        }
        for(int i = 0; i< 5; i++) {
            winner = true;
            for(int k = 0; k < 25; k+=5) {
                if(board[i + k] != -1) {
                    winner = false;
                }
            }
            if(winner) {
                return true;
            }
        }
        return false;
    }
    public int HydroVentsVertHorz(string inputFile) {
        List<Line> lines = getCoordinates(inputFile);
        List<Line> vhLines = getVerticalOrHorizontalLines(lines);
        var points = getPointSet(vhLines);
        int counter = 0;
        foreach(var x in points) {
            if(x.Value > 1) {
                counter++;
            }
        }
        return counter;
    }
    public int HydroVentsVertHorzDiag(string inputFile) {
        List<Line> lines = getCoordinates(inputFile);
        List<Line> allLines = getVerticalOrHorizontalLines(lines);
        List<Line> diagLines = getDiagnolLines(lines);
        allLines.AddRange(diagLines);
        var points = getPointSet(allLines);
        int counter = 0;
        foreach(var x in points) {
            if(x.Value > 1) {
                //Console.WriteLine($"count: {x.Value} x: {x.Key.x}, y: {x.Key.y}");
                counter++;
            }
        }
        return counter;
    }
    private Dictionary<Point, int> getPointSet(List<Line> lines) {
        PointEqualityComparer pEqC = new PointEqualityComparer();
        Dictionary<Point, int> points = new Dictionary<Point, int>(pEqC);
        foreach(Line l in lines) {
            //get all point in the line.
            if(l == null) {
                continue;
            }
            int dx = l.P2.x - l.P1.x;
            int dy = l.P2.y - l.P1.y;
            int start = 0; int end = 0;
            int m = 0;
            int c = 0;
            if(dx == 0) {
                start = l.P1.y; end = l.P2.y;
            }
            else if(dy == 0) {
                start = l.P1.x; end = l.P2.x;
            } 
            else {
                m = (l.P1.y - l.P2.y) / (l.P1.x - l.P2.x);
                c = l.P1.y - l.P1.x * m;
                start = l.P1.x;
                end = l.P2.x;
            }
            if(start > end) {
                int tmp = end;
                end = start;
                start = tmp;
            }
            for(int i = start; i <= end; i++) {
                Point p = new Point();
                if(dx == 0) {
                    p.x = l.P1.x;
                    p.y = i;
                }else if(dy == 0) {
                    p.x = i;
                    p.y = l.P1.y;
                }
                else {
                    p.x = i;
                    p.y = Math.Abs(m * i + c);
                }
                if(points.ContainsKey(p)) {
                    points[p]++;
                }
                else{
                    points.Add(p,1);
                }
            }
        }
        return points;
    }
    private class PointEqualityComparer : IEqualityComparer<Point> {
        public bool Equals(Point? p1, Point? p2) {
            if(p1 == null && p2 == null) {
                return true;
            }
            else if (p1 == null || p2 == null) {
                return false;
            }
            else if( p1.x == p2.x && p2.y == p2.y) {
                return true;
            }
            return false;
        }
        public int GetHashCode (Point p) {
            int hCode = 1000*(p.x + 1000) + (p.y + 1000);
            return hCode;
        }
    }
    private class Point {
        public int x {get; set;}
        public int y {get; set;}

    }
    private class Line {
        public Point P1 {get; set;}
        public Point P2 {get; set;}
        public Line() {
            P1 = new Point();
            P2 = new Point();
        }
    }

    private List<Line> getVerticalOrHorizontalLines(List<Line> lines) {
        List<Line> vertHorLines = new List<Line>();
        foreach(Line l in lines) {
            if(l.P1.x == l.P2.x || l.P1.y == l.P2.y) {
                vertHorLines.Add(l);
            }
        }
        return vertHorLines;
    }
    private List<Line> getDiagnolLines(List<Line> lines) {
        List<Line> diagLines = new List<Line>();
        foreach(Line l in lines) {
            if(Math.Abs(l.P1.x - l.P2.x) == Math.Abs(l.P1.y - l.P2.y)) {
                diagLines.Add(l);
            }
        }
        return diagLines;
    }
    private List<Line> getCoordinates(string inputFile) {
        List<Line> lines = new List<Line>();
        var linesStr = File.ReadAllLines(inputFile);
        foreach(var lineStr in linesStr) {
            var points = lineStr.Split(" -> ");
            Point p1 = new Point() {
                x = Int32.Parse(points[0].Split(',')[0]),
                y = Int32.Parse(points[0].Split(',')[1])
            };
            Point p2 = new Point() {
                x = Int32.Parse(points[1].Split(',')[0]),
                y = Int32.Parse(points[1].Split(',')[1])
            };
            Line l = new Line() {
                P1 = p1, P2 = p2
            };
            lines.Add(l);
        }
        return lines;
    }
}