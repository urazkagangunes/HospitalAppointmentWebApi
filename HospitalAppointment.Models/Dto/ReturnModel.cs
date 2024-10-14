using System.Net;

namespace HospitalAppointment.Models.Dto;

public class ReturnModel<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }

    public HttpStatusCode StatusCode { get; set; }

    public override string ToString()
    {
        return $"Başarılı Mı : {Success} \n Mesaj : {Message} \n Veri : {Data} " +
            $"\n Statü : {StatusCode}";
    }
}
