using Newtonsoft.Json;
using VCard.Helpers;
using VCard.Models;

class Program
{
    public static void Main()
    {
        var vCard = FileHelper.GetDataFromApi();
        Console.WriteLine("Yaratmaq istediyiniz VCard sayini daxil edin : ");
        int countVCard = int.Parse(Console.ReadLine());

        for (int i = 0; i < countVCard; i++)
        {
            if (vCard is not null)
            {
                var responseCreate = FileHelper.CreateVCard(vCard);
                if (responseCreate.IsSuccess)
                {
                    Console.WriteLine(responseCreate.Message);

                    var responseSave = FileHelper.SaveVCard(responseCreate.Data);
                    Console.WriteLine(responseSave.Message);
                }
                else
                {
                    Console.WriteLine(responseCreate.Message);
                }
            }
            else
            {
                Console.WriteLine("Məlumat tapılmadı.");
            }
        }
    }
}
