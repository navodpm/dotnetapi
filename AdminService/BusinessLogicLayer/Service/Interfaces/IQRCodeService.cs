using AdminService.BusinessLogicLayer.DTO;

namespace AdminService.BusinessLogicLayer.Service.Interfaces
{
    public interface IQRCodeService
    {
        QRCodeModel GenerateQRCode(QRCodeModel qRCode); 
    }
}
