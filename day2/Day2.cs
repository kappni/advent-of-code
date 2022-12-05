public class Day2 : IDay
{
    public async Task<string> Execute1()
    {
        IEnumerable<Round> lines = (await AOCHelper.GetFile("2")).Select(x => new Round(x[0], x[2]));
        return lines.Sum(x => x.getPoints()).ToString();
        
    }

    public async Task<string> Execute2()
    {
        IEnumerable<Round> lines = (await AOCHelper.GetFile("2")).Select(x => new Round(x[0], x[2], true));
        return lines.Sum(x => x.getPoints()).ToString();
    }
}

public struct Round {
    public Round(char opponent, char you) {
        opponentPick = Round.convert(opponent);
        yourPick = Round.convert(you);
    }

    public Round(char opponent, char you, bool isSecond) {
        opponentPick = Round.convert(opponent);
        yourPick = Round.convert(opponent, you);
    }
    public string opponentPick;
    public string yourPick;

    private static string convert(char c){
         switch(c) {
            case 'A':
            case 'X':
                return "Rock";
            case 'B':
            case 'Y':
                return "Paper";
            case 'C':
            case 'Z':
                return "Scissor";
            
        }
        throw new ArgumentException();
    }

    private static string convert(char opponent, char you) {
        if(you == 'Y') return Round.convert(opponent);
        if(you == 'X') {
            if(opponent == 'A') return "Scissor";
            if(opponent == 'B') return "Rock";
            if(opponent == 'C') return "Paper";
        }
        if(you == 'Z') {
            if(opponent == 'A') return "Paper";
            if(opponent == 'B') return "Scissor";
            if(opponent == 'C') return "Rock";
        }

        throw new ArgumentException();
    }

    public int getPointsForSelected(){
        switch(yourPick) {
            case "Rock":
                return 1;
            case "Paper":
                return 2;
            case "Scissor":
                return 3;
        }
        throw new ArgumentException();
    }

    public int getPointsForResult() {
        if(opponentPick.Equals(yourPick)) return 3;
        if(yourPick == "Rock" && opponentPick == "Scissor") return 6;
        if(yourPick == "Paper" && opponentPick == "Rock") return 6;
        if(yourPick == "Scissor" && opponentPick == "Paper") return 6;
        return 0;
    }

    public int getPoints() {
        return getPointsForSelected() + getPointsForResult();
    }
}


