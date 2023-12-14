namespace CoreApplication.ports
{
    public interface IEmailService
    {
        void SendOrderConfirmationEmail(int orderId);
    }
}
