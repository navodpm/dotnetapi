using AdminService.BusinessLogicLayer.DTO;
using AdminService.BusinessLogicLayer.Service.Interfaces;
using QRCoder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
//using iTextSharp.text.pdf.qrcode;
//using ZXing.QrCode.Internal;

namespace AdminService.BusinessLogicLayer.Service.Impl
{
    public class QRCodeService : IQRCodeService
    {
        public QRCodeModel GenerateQRCode(QRCodeModel qRCode)
        {
            QRCodeGenerator QrGenerator = new QRCodeGenerator();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(qRCode.QRCodeText, QRCodeGenerator.ECCLevel.Q);
            //QRCode QrCode = new QRCode(QrCodeInfo);
            //Bitmap QrBitmap = QrCode.GetGraphic(60);
            byte[] BitmapArray = null;//QrBitmap.BitmapToByteArray();
            string QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
            qRCode.QRCodeTextBase64 = QrUri;
            return qRCode;
        }
    }

    //Extension method to convert Bitmap to Byte Array
    public static class BitmapExtension
    {
        public static byte[] BitmapToByteArray(this Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
