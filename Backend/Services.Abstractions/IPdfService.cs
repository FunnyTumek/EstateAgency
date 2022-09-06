using Contracts.DataTransferObject;

namespace Services.Abstractions
{
    public interface IPdfService
    {
        void GeneratePdf(Stream stream, EstatesDto estates);
    }
}
