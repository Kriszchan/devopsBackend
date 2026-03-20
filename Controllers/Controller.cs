using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace devopsBackend.Controllers
{
    [Route("")]
    [ApiController]
    public class LicensePlateController : ControllerBase
    {
        private static readonly Random _random = new Random();

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetRandomPlates()
        {
            var plates = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                plates.Add(GenerateHungarianPlate());
            }

            return Ok(plates);
        }
        private string GenerateHungarianPlate()
        {
            int num = _random.Next(1, 1000);
            string numberPart = num.ToString("D3");

            return $"{GenerateRandomLetters(2)} {GenerateRandomLetters(2)}-{numberPart}";
        }

        private string GenerateRandomLetters(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                result.Append(chars[_random.Next(chars.Length)]);
            }
            return result.ToString();
        }
    }
}