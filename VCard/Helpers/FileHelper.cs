using Newtonsoft.Json;
using System.Text;
using VCard.Models;

namespace VCard.Helpers
{
    public static class FileHelper
    {
        const string NewLine = "\r\n";
        const string Separator = ";";
        const string Header = "BEGIN:VCARD\r\nVERSION:2.1";
        const string Name = "N:";
        const string PhonePrefix = "TEL;";
        const string PhoneSubPrefix = ",VOICE:";
        const string AddressPrefix = "ADR;";
        const string AddressSubPrefix = ":;;";
        const string EmailPrefix = "EMAIL:";
        const string Footer = "END:VCARD";

        public static VCardModel GetDataFromApi()
        {
            try
            {
                VCardModel vCard = new();
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync("https://randomuser.me/api/").Result;
                    var responseStream = response.Content.ReadAsStringAsync().Result;
                    var responseData = JsonConvert.DeserializeObject<RandomUserResponseModel>(responseStream);

                    var data = responseData.Results.GetRange(0, 1).FirstOrDefault();

                    vCard = new()
                    {
                        Id = data.Id.Value,
                        FirstName = data.Name.First,
                        SurName = data.Name.Last,
                        Email = data.Email,
                        Phone = data.Phone,
                        Country = data.Location.Country,
                        City = data.Location.City
                    };
                }
                return vCard;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static ResponseModel CreateVCard(VCardModel vCard)
        {
            ResponseModel responseModel = new();
            try
            {
                StringBuilder card = new StringBuilder();
                card.Append(Header);
                card.Append(NewLine);

                //Full Name
                if (!string.IsNullOrEmpty(vCard.FirstName) || !string.IsNullOrEmpty(vCard.SurName))
                {
                    card.Append(Name);
                    card.Append(vCard.SurName);
                    card.Append(Separator);
                    card.Append(vCard.FirstName);
                    card.Append(Separator);
                    card.Append(NewLine);
                }

                //Phone
                if (!string.IsNullOrEmpty(vCard.Phone))
                {
                    card.Append(PhonePrefix);
                    card.Append(PhoneSubPrefix);
                    card.Append(vCard.Phone);
                    card.Append(NewLine);
                }

                //Email
                if (!string.IsNullOrEmpty(vCard.Email))
                {
                    card.Append(EmailPrefix);
                    card.Append(vCard.Email);
                    card.Append(NewLine);
                }

                //Country and City 
                if (!string.IsNullOrEmpty(vCard.Phone))
                {
                    card.Append(AddressPrefix);
                    card.Append(AddressSubPrefix);
                    card.Append(vCard.Country);
                    card.Append(Separator);
                    card.Append(vCard.City);
                    card.Append(NewLine);
                }

                card.Append(Footer);

                responseModel.IsSuccess = true;
                responseModel.Data = card.ToString();
                responseModel.Message = "VCard - ınız uğurla yaradılmışdır.";
                return responseModel;
            }
            catch (Exception)
            {
                responseModel.IsSuccess = false;
                responseModel.Data = null;
                responseModel.Message = "VCard yaradılan zaman xəta baş verdi.";
                return responseModel;
            }
        }
        public static ResponseModel SaveVCard(string vcardContents)
        {
            ResponseModel responseModel = new();
            try
            {
                //string folderName = "Files";
                string fileName = $"vCard_{DateTime.Now:yyyyMMdd_HHmmss}.vcf";
                string filePath = Path.Combine("C:\\Code_Academy\\VCard\\VCard\\Files", fileName);

                File.WriteAllText(filePath, vcardContents);

                responseModel.IsSuccess = true;
                responseModel.Message = $"{fileName} faylı saxlanılmışdır.";
                return responseModel;
            }
            catch
            {
                responseModel.IsSuccess = true;
                responseModel.Message = $"Faylın saxlanılması zamanı xəta baş verdi.";
                return responseModel;
            }

        }
    }
}
