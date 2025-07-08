//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MetaXPorter.Api.Models.Foundations.ExternalPersons;
using OfficeOpenXml;

namespace MetaXPorter.Api.Brokers.Sheets
{
    public partial class SheetBroker
    {
        public async ValueTask<List<ExternalPerson>> ReadAllExternalPersonPetsAsync(FileInfo file)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var externalPersons = new List<ExternalPerson>();
            int row = 2, column = 1;

            using var excelPackage =
                new ExcelPackage(file);

            ExcelWorksheet workSheet =
                excelPackage.Workbook.Worksheets[PositionID: 0];

            await excelPackage.LoadAsync(file);

            while (!IsTrailingFinalRow(row, column, workSheet))
            {
                ExternalPerson externalPerson = new ExternalPerson
                {
                    PersonName = workSheet.Cells[row, column].Value.ToString(),
                    Age = int.Parse(workSheet.Cells[row, column + 1].Value.ToString()),
                    PetOne = workSheet.Cells[row, column + 2].Value.ToString(),
                    PetOneType = workSheet.Cells[row, column + 3].Value.ToString(),
                    PetTwo = workSheet.Cells[row, column + 4].Value.ToString(),
                    PetTwoType = workSheet.Cells[row, column + 5].Value.ToString(),
                    PetThree = workSheet.Cells[row, column + 6].Value.ToString(),
                    PetThreeType = workSheet.Cells[row, column + 7].Value.ToString()
                };

                externalPersons.Add(externalPerson);
                row++;
            }

            return externalPersons;

            static bool IsTrailingFinalRow(int row, int column, ExcelWorksheet workSheet) =>
                String.IsNullOrEmpty(workSheet.Cells[row, column].Value?.ToString());
        }
    }
}
