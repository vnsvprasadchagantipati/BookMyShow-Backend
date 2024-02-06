using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.IO;

[ApiController]
[Route("api/tickets")]
public class TicketsController : ControllerBase
{
    private readonly IConverter _pdfConverter;

    public TicketsController(IConverter pdfConverter)
    {
        _pdfConverter = pdfConverter;
    }

    [HttpGet("generate")]
    public IActionResult GenerateTicket(string movieName, string seatNumber)
    {
        var htmlContent = $"<html><body><h1>Movie: {movieName}</h1><p>Seat: {seatNumber}</p></body></html>";

        var globalSettings = new GlobalSettings
        {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
        };

        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = htmlContent,
            WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "styles", "styles.css") },
            HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
            FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Footer Text" }
        };

        var pdf = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };

        var file = _pdfConverter.Convert(pdf);

        return File(file, "application/pdf", "movie_ticket.pdf");
    }
}

