namespace SimpleMAUI.Core.Models;

public class Card
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public string Text { get; set; } = "";
    public string Image { get; set; } = "";
    public ImageSource ImageSource
    {
        get
        {
            if (string.IsNullOrEmpty(Image))
            {
                // get default image if Image is null or empty
                return ImageSource.FromFile("noimage.jpg");
            }
            try
            {
                byte[] imageBytes = Convert.FromBase64String(Image);
                return ImageSource.FromStream(() => new MemoryStream(imageBytes));
            }
            catch (FormatException)
            {
                // If the Image string is not a valid Base64 string, return a default image
                return ImageSource.FromFile("noimage.jpg");
            }
        }
    }
}
