namespace EthiopianDateConverter
{
    public class EthiopianDateConverter
    {
        // Array of Ethiopian month names for use in the long date format
        private static readonly string[] EthiopianMonths =
        [
            "መስከረም",
            "ጥቅምት",
            "ህዳር",
            "ታህሳስ",
            "ጥር",
            "የካቲት",
            "መጋቢት",
            "ሚይዚያ",
            "ግንቦት",
            "ሰኔ",
            "ሐምሌ",
            "ነሐሴ",
            "ጳጉሜ"
        ];

        // Array of Ethiopian day names
        private static readonly string[] EthiopianDays =
        [
            "እሁድ",
            "ሰኞ",
            "ማክሰኞ",
            "ረቡዕ",
            "ሐሙስ",
            "ዓርብ",
            "ቅዳሜ",
            "እሁድ"
        ];

        public static string ConvertToEthiopianShort(DateTime gregorianDate)
        {
            ConvertGregorianToEthiopian(gregorianDate, out var ethiopianYear, out var ethiopianMonth, out var ethiopianDay);

            return $"{ethiopianDay:D2}/{ethiopianMonth:D2}/{ethiopianYear}";
        }

        public static string ConvertToEthiopianLong(DateTime gregorianDate)
        {
            ConvertGregorianToEthiopian(gregorianDate, out var ethiopianYear, out var ethiopianMonth, out var ethiopianDay);

            // Calculate day of the week
            var dayOfWeek = (int)gregorianDate.DayOfWeek;
            var dayName = EthiopianDays[dayOfWeek];

            var monthName = EthiopianMonths[ethiopianMonth - 1];
            return $"{dayName}, {ethiopianDay} {monthName} {ethiopianYear}";
        }

        private static void ConvertGregorianToEthiopian(DateTime gregorianDate, out int ethiopianYear, out int ethiopianMonth, out int ethiopianDay)
        {
            // Constants for the Ethiopian calendar's offset
            const int offsetYears = 8;
            const int newYearMonth = 9; // Ethiopian New Year is in September
            var newYearDay = (DateTime.IsLeapYear(gregorianDate.Year - 1)) ? 12 : 11;

            // Determine the Ethiopian year
            ethiopianYear = gregorianDate.Year - offsetYears;
            if (gregorianDate < new DateTime(gregorianDate.Year, newYearMonth, newYearDay))
            {
                ethiopianYear--;
            }

            // Calculate the difference in days from the Ethiopian New Year
            var ethiopianNewYear = new DateTime(gregorianDate.Year, newYearMonth, newYearDay);
            if (gregorianDate >= ethiopianNewYear)
            {
                ethiopianNewYear = new DateTime(gregorianDate.Year + 1, newYearMonth, newYearDay);
            }
            var differenceInDays = (gregorianDate - ethiopianNewYear.AddYears(-1)).Days;

            // Calculate the Ethiopian month and day
            ethiopianMonth = differenceInDays / 30 + 1;
            ethiopianDay = differenceInDays % 30 + 1;
        }
    }
}
