namespace ClinicManagement.Services.SendSms
{
    public interface ISendSms
    {
        //kevehnegar for example
        void SendSms(string message , string phoneNumber);
    }
}
