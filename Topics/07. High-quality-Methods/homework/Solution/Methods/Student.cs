using System;

namespace Methods
{
    class Student
    {
        private const int BirthDateLength = 10;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = Student.GetBirthDate(this.OtherInfo);
            DateTime secondDate = Student.GetBirthDate(other.OtherInfo);
            return firstDate < secondDate;
        }

        private static DateTime GetBirthDate(string otherInfo)
        {
            if (string.IsNullOrEmpty(otherInfo))
            {
                throw new ArgumentNullException("Other info must not be null nor empty");
            }

            int birthDateStartIndex = otherInfo.Length - BirthDateLength;
            if (birthDateStartIndex < 0)
            {
                throw new ArgumentException("Other info is not valid");
            }

            string birthDateSubPart = otherInfo.Substring(birthDateStartIndex);

            DateTime birthDate;
            if(!DateTime.TryParse(birthDateSubPart, out birthDate))
            {
                throw new ArgumentException("Other info does not contain valid date");
            }

            return birthDate;
        }
    }
}
