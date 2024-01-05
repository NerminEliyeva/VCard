using Newtonsoft.Json;
using VCard.Helpers;
using VCard.Models;

class Program
{
    public static void Main()
    {
        var vCard = FileHelper.GetDataFromApi();
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
