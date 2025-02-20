using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MudBlazor;
using Newtonsoft.Json;
using PanelingSystem.Models;

namespace PanelingSystem.Commons
{
    public static class Extensions
    {
        public static void ShowAlert(string message, Variant variant, ISnackbar snackbarService, Severity severityType)
        {
            snackbarService.Clear();
            snackbarService.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
            snackbarService.Configuration.SnackbarVariant = variant;
            snackbarService.Configuration.MaxDisplayedSnackbars = 10;
            snackbarService.Configuration.VisibleStateDuration = 2000;
            snackbarService.Add($"{message}", severityType);
        }
        public static string GetEnumDescription(Enum value)  
        {  
            var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();  
            var descriptionAttribute =  
                enumMember == null  
                    ? default(DescriptionAttribute)  
                    : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;  
            return  
                descriptionAttribute == null  
                    ? value.ToString()  
                    : descriptionAttribute.Description;  
        }
        public static string FormatPassword(string password, char symbol = '●')
        {
            // Create a character array to store the formatted password
            char[] formattedPassword = new char[password.Length];
            
            // Fill the array with the specified symbol
            for (int i = 0; i < password.Length; i++)
            {
                formattedPassword[i] = symbol;
            }
            
            // Convert the character array back to a string
            return new string(formattedPassword);
        }
        public static T Clone<T>(T source)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var serialized = JsonConvert.SerializeObject(source, settings);
            return JsonConvert.DeserializeObject<T>(serialized, settings);
        }

        public static void NewtonsoftLog<T>(T t)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(t, Newtonsoft.Json.Formatting.Indented));
        }
        public static async Task<byte[]> ToByteArrayAsync(IBrowserFile file)
        {
            // Check if the file is null
            if (file == null)
                return null;

            // Read the content of the file as a byte array
            using (var memoryStream = new MemoryStream())
            {
                await file.OpenReadStream(209715200).CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
        public static async Task Download(byte[] file, string fileName, IJSRuntime JSRuntime)
        {
            await JSRuntime.InvokeVoidAsync("downloadFile", Convert.ToBase64String(file), fileName);
        }
        public static double CalculateGPA(List<MembersModel> GroupMembers)
        {
            double totalAverage = GroupMembers.Sum(member =>
                (member.TitleGrade + member.PreOralGrade + member.FinalGrade) / 3);
            
            int totalMembers = GroupMembers.Count;
            double GPA = totalMembers > 0 ? totalAverage / totalMembers : 0;

            return GPA;
        }
        public static MemoryStream ConvertToStream(byte[] byteArray)
        {
            // Create a MemoryStream using the byte array
            return new MemoryStream(byteArray);
        }
        private static readonly Dictionary<string, string> MimeTypes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { ".jpg", "image/jpeg" },
            { ".jpeg", "image/jpeg" },
            { ".png", "image/png" },
            { ".gif", "image/gif" },
            { ".bmp", "image/bmp" },
            { ".tiff", "image/tiff" },
            { ".webp", "image/webp" },
            { ".svg", "image/svg+xml" },
            { ".pdf", "application/pdf" },
            { ".doc", "application/msword" },
            { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { ".xls", "application/vnd.ms-excel" },
            { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
            { ".ppt", "application/vnd.ms-powerpoint" },
            { ".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation" },
            { ".txt", "text/plain" },
            { ".csv", "text/csv" },
            { ".html", "text/html" },
            { ".css", "text/css" },
            { ".js", "application/javascript" },
            { ".xml", "application/xml" },
            { ".zip", "application/zip" },
            { ".mp4", "video/mp4" },
            { ".mp3", "audio/mpeg" },
            { ".wav", "audio/wav" },
            { ".json", "application/json" },
            { ".exe", "application/x-msdownload" }
            // Add more file types as needed
        };
        public static string GetContentType(this string filename)
        {
            // Extract file extension (without the dot)
            var extension = System.IO.Path.GetExtension(filename)?.ToLowerInvariant();
            
            // Return corresponding MIME type, or "application/octet-stream" if not found
            return extension != null && MimeTypes.TryGetValue(extension, out var mimeType) 
                ? mimeType 
                : "application/octet-stream";
        }
    }
}