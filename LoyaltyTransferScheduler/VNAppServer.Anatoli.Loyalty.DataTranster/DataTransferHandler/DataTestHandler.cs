using System;
using System.Net.Http;

namespace VNAppServer.Anatoli.Loyalty.DataTranster.DataTransferHandler
{
    public class DataTestHandler : DataHandler
    {

        public static void UploadDataToServer(HttpClient client, string serverURI, string privateOwnerId, string dataOwner, string dataOwnerCenter)
        {
            try
            {
                log.Info("Start CallServerService URI ");
                //var currentTime = DateTime.Now;
                //var lastUpload = Utility.GetLastUploadTime(ProductDataType);
                //var dbData = ProductAdapter.Instance.GetAllProducts(lastUpload);
                //{
                //    uctRequestModel request = new ProductRequestModel() { productData = dbData };
                //    JavaScriptSerializer js = new JavaScriptSerializer();
                //    js.MaxJsonLength = Int32.MaxValue;
                //    string data = js.Serialize(request);
                //    string URI = serverURI + UriInfo.SaveProductURI;// +privateOwnerQueryString;
                //    var result = ConnectionHelper.CallServerServicePost(data, URI, client, privateOwnerId, dataOwner, dataOwnerCenter);
                //}


                //Utility.SetLastUploadTime(ProductDataType, currentTime);

                log.Info("Completed CallServerService ");
            }
            catch (Exception ex)
            {
                log.Error("Failed CallServerService ", ex);
            }
        }
    }
}
