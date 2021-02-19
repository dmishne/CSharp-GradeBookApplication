using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var gradeRangeSize = (int)Math.Floor((double)Students.Count / 5);

            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var ordererdStudents = Students.OrderByDescending(student => student.AverageGrade).ToList();
            if (averageGrade >= ordererdStudents[gradeRangeSize- 1].AverageGrade) { return 'A'; }
            if (averageGrade >= ordererdStudents[gradeRangeSize * 2 - 1].AverageGrade) { return 'B'; }
            if (averageGrade >= ordererdStudents[gradeRangeSize * 3 - 1].AverageGrade) { return 'C'; }
            if (averageGrade >= ordererdStudents[gradeRangeSize * 4 - 1].AverageGrade) { return 'D'; }
            return 'F';
        }

    }
}
