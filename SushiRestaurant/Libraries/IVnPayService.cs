using ECommerceSysCore.Models.DTO;

namespace ECommerceSysCore.Libraries
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(PaymentInformationModel model, HttpContext context);
        PaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
