using Contracts.DataTransferObject;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Services.Abstractions;

namespace Services
{
    public class PdfService : IPdfService
    {
        public void GeneratePdf(Stream stream, EstatesDto estates)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(15));

                    page.Header()
                        .Height(40)
                        .AlignCenter()
                        .Background(Colors.Grey.Lighten1)
                        .AlignMiddle()
                        .Text($"Estate")
                        .SemiBold().FontSize(20)
                        .FontColor(Colors.Black);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(10);
                            x.Item().PaddingVertical(2).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                            x.Item().Text($"\nName: {estates.Name} \nDescription:{estates.Description}\n");
                            x.Item().PaddingVertical(2).LineHorizontal(1).LineColor(Colors.Grey.Medium);

                            x.Item().Text($"Information:\nAddress: {estates.Address} \nFloor: {estates.Floor}\nNumber of rooms: {estates.NumberOfRooms}\nYear of construction: {estates.YearOfConstruction}\nFlat area: {estates.FlatArea}\nPrice: {estates.Price}\nEnd date: {estates.EndDate}");
                            x.Item().PaddingVertical(2).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            });
            document.GeneratePdf(stream);
        }
    }
}
