using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using MudBlazor;
using PanelingSystem.Models;

namespace PanelingSystem.Commons
{
    public class Extensions
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
                await file.OpenReadStream().CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
        public static async Task Download(FileModel file, IJSRuntime JSRuntime)
        {
            await JSRuntime.InvokeVoidAsync("downloadFile", Convert.ToBase64String(file.File), file.FileName);
        }
    }
}