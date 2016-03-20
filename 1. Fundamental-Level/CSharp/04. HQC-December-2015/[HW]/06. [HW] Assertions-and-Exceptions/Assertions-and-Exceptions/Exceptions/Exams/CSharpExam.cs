using System;

public class CSharpExam : Exam
{
    private const int MinGrade = 0;
    private const int MaxGrade = 100;

    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < MinGrade)
            {
                throw new ArgumentOutOfRangeException("The score of the C# exam cannot be less than the minimal grade (0).");
            }

            if (value > MaxGrade)
            {
                throw new ArgumentOutOfRangeException("The score of the C# exam cannot be more than the maximal grade (100).");
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, MinGrade, MaxGrade, "Exam results calculated by score.");
    }
}