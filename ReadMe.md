# Ethiopian Date Converter

## Description

The Ethiopian Date Converter is a C# application designed to convert dates from the Gregorian calendar to the Ethiopian calendar. It provides accurate conversions by considering leap years and the specific start of the Ethiopian New Year. The application offers functionalities to convert dates into both short and long Ethiopian date formats.

## Features

- Convert Gregorian dates to Ethiopian dates.
- Support for short (dd/MM/yyyy) and long date formats, including day names and month names.
- Consideration of leap years in both calendars for accurate date conversion.

## Usage

To use the Ethiopian Date Converter, include the `EthiopianDateConverter.cs` class in your C# project. You can convert dates using the following methods:

- `ConvertToEthiopianShort(DateTime gregorianDate)` for short date format.
- `ConvertToEthiopianLong(DateTime gregorianDate)` for long date format with month and day names.

Example:
```csharp
DateTime date = new DateTime(2023, 9, 21);
string ethiopianShortDate = EthiopianDateConverter.ConvertToEthiopianShort(date);
string ethiopianLongDate = EthiopianDateConverter.ConvertToEthiopianLong(date);
