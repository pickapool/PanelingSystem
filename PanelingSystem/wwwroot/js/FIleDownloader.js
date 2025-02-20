window.downloadFile = function (fileContent, fileName) {
    // Convert base64 string to blob
    var byteCharacters = atob(fileContent);
    var byteNumbers = new Array(byteCharacters.length);
    for (var i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    var byteArray = new Uint8Array(byteNumbers);
    var blob = new Blob([byteArray]);

    // Create download link
    var link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    link.download = fileName;

    // Append link to body and trigger download
    document.body.appendChild(link);
    link.click();

    // Clean up
    document.body.removeChild(link);
};

window.getBlobURL = function (fileContent, fileName) {
    // Convert base64 string to blob
    var byteCharacters = atob(fileContent);
    var byteNumbers = new Array(byteCharacters.length);
    for (var i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    var byteArray = new Uint8Array(byteNumbers);
    var blob = new Blob([byteArray]);

    // Create Blob URL
    var blobUrl = window.URL.createObjectURL(blob);
    // Return the Blob URL
    return blobUrl;
};