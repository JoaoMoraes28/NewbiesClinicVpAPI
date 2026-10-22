using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace ClinicVp.Services
{
    public class Midia
    {

        readonly private Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));

        public async Task<string> GetUrlPhoto(string archive)
        {
            cloudinary.Api.Secure = true;

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(),
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = true
            };

            var response = cloudinary.Upload(uploadParams);

            return response.SecureUrl.ToString();
        }

    }
}
