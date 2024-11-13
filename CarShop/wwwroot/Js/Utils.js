function DownloadExcel(fileName, base64File) {

    const link = document.createElement("a");
    link.download = fileName;

    /*link.href = "data:application/octet-stream;base64," + base64File;*/

    /* link.href = "data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64," + base64File;*/

    link.href = "data:application/vnd.ms-excel;base64, " + base64File;


    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);

}